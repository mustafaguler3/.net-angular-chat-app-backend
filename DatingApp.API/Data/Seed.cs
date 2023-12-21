using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using DatingApp.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
	public class Seed
	{
		public static async Task SeedUsers(UserManager<User> userManager,RoleManager<AppRole> roleManager)
		{
			
			if (await userManager.Users.AnyAsync()) return;

			var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");
			var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
			var users = JsonSerializer.Deserialize<List<User>>(userData);

			var roles = new List<AppRole>
			{
				new AppRole{Name = "Member"},
				new AppRole{Name = "Admin"},
				new AppRole{Name = "Moderator"}
			};
                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(role);
                }

                foreach (var user in users)
                {
                    user.UserName = user.UserName.ToLower();
                    await userManager.CreateAsync(user, "password");
                    await userManager.AddToRoleAsync(user, "Member");
                }

                var admin = new User
                {
                    UserName = "admin"
                };

                await userManager.CreateAsync(admin, "password");
                await userManager.AddToRolesAsync(admin, new[] { "Admin", "Moderator" });
            
			
        }
	}
}


using System;
using Microsoft.AspNetCore.Identity;

namespace DatingApp.API.Entities
{
	public class AppRole : IdentityRole<int>
	{
		public ICollection<UserRole> UserRoles { get; set; }
	}
}


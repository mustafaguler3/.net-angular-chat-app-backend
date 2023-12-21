using System;
using Microsoft.AspNetCore.Identity;

namespace DatingApp.API.Entities
{
	public class UserRole : IdentityUserRole<int>
	{
		public User User { get; set; }
		public AppRole Role { get; set; }
	}
}


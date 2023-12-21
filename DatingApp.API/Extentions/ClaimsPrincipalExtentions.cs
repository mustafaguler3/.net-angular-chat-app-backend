using System;
using System.Security.Claims;

namespace DatingApp.API.Extentions
{
	public static class ClaimsPrincipalExtentions
	{
		public static string GetUsername(this ClaimsPrincipal principal)
		{
			return principal.FindFirst(ClaimTypes.Name)?.Value;
		}

        public static int GetUserId(this ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}


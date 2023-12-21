using System;
using DatingApp.API.Entities;

namespace DatingApp.API.Interfaces
{
	public interface ITokenService
	{
		Task<string> CreateToken(User user);
	}
}


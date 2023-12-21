using System;
using DatingApp.API.DTOs;
using DatingApp.API.Entities;
using DatingApp.API.Helpers;

namespace DatingApp.API.Interfaces
{
	public interface IUserRepository
	{
		void Update(User user);
		Task<bool> SaveAllAsync();
		Task<IEnumerable<User>> GetUsersAsync();
		Task<User> GetUserByIdAsync(int id);
		Task<User> GetUserByUsernameAsync(string username);

		Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);

		Task<MemberDto> GetMemberAsync(string username);
		Task<string> GetUserGender(string username);
	}
}


using System;
using DatingApp.API.DTOs;
using DatingApp.API.Entities;
using DatingApp.API.Helpers;

namespace DatingApp.API.Interfaces
{
	public interface ILikesRepository
	{
		Task<UserLike> GetUserLike(int sourceUserId, int targetUserId);
		Task<User> GetUserWithLikes(int userId);
		Task<PagedList<LikeDto>> GetUserLikes(LikesParam likesParam);
	}
}


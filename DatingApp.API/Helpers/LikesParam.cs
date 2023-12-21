using System;
namespace DatingApp.API.Helpers
{
	public class LikesParam : PaginationParams
	{
		public int UserId { get; set; }
		public string Predicate { get; set; }
	}
}


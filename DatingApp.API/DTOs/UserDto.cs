﻿using System;
namespace DatingApp.API.DTOs
{
	public class UserDto
	{
		public int UserId { get; set; }
		public string Username { get; set; }
		public string Token { get; set; }
		public string PhotoUrl { get; set; }
		public string KnownAs { get; set; }
		public string Gender { get; set; }
	}
}


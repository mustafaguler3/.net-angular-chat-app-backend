using System;
namespace DatingApp.API.Extentions
{
	public static class DateTimeExtentions
	{
		public static int CalculateAge(this DateOnly dob)
		{
			var today = DateOnly.FromDateTime(DateTime.UtcNow);

			var age = today.Year - dob.Year;

			if (dob > today.AddYears(-age)) age--;

			return age;
		}
	}
}


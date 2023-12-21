using System;
using DatingApp.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
	[ServiceFilter(typeof(LogUserActivity))]
	[Route("api/[controller]")]
	[ApiController]
	public class BaseController : ControllerBase
	{
	}
}


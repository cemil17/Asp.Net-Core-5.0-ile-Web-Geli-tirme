using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Controllers
{
	[AllowAnonymous]
	public class ErrorPagesController : Controller
	{
		public IActionResult Page401()
		{
			return View();
		}
		public IActionResult Page404()
		{
			return View();
		}
		public IActionResult Page405()
		{
			return View();
		}
	}
}

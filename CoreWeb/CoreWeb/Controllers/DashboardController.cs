using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

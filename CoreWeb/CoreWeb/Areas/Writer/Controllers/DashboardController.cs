using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Areas.Writer.Controllers
{
	[Area("Writer")]
	[Route("Writer/[controller]/[action]")]

	public class DashboardController : Controller
	{
		private readonly UserManager<WriterUser> _userManager;

		public DashboardController(UserManager<WriterUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IActionResult> MainPanel()
		{
			var getName = await _userManager.FindByNameAsync(User.Identity.Name);
			ViewBag.Name = getName.Name + " " + getName.Surname;

			//Statistics 
			Context context = new Context();

			ViewBag.card1 = context.MessageSwitchingSystems.Where(x => x.Receiver == getName.Email).Count();
			ViewBag.card2 = context.Announcements.Count();
			ViewBag.card3 = context.Users.Count();
			ViewBag.card4 = context.MessageSwitchingSystems.Where(x => x.Sender == getName.Email).Count();

			return View();
		}

	}
}

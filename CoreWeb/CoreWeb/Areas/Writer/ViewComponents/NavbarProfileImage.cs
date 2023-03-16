using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Areas.Writer.ViewComponents
{
	public class NavbarProfileImage : ViewComponent
	{
		private readonly UserManager<WriterUser> _userManager;

		public NavbarProfileImage(UserManager<WriterUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			ViewBag.profile = values.ImageURL; 
			return View();
		}
	}
}

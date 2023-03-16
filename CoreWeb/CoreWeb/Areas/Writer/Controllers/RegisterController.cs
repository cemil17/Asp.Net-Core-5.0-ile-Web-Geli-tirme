using CoreWeb.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Areas.Writer.Controllers
{
	[AllowAnonymous]

	[Area("Writer")]
	[Route("Writer/[controller]/[action]")]

	public class RegisterController : Controller
	{
		private readonly UserManager<WriterUser> _userManager;

		public RegisterController(UserManager<WriterUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult RegisterNow()
		{
			return View(new UserRegisterViewModel());
		}
		[HttpPost]
		public async Task<IActionResult> RegisterNow(UserRegisterViewModel userRegister)
		{
			try
			{
				if (ModelState.IsValid)
				{
					WriterUser user = new WriterUser()
					{
						Name = userRegister.Name,
						Surname = userRegister.Surname,
						Email = userRegister.Mail,
						UserName = userRegister.UserName,
						ImageURL = userRegister.ImageURL
					};
					if (userRegister.Password == userRegister.ConfirmPassword)
					{
						var results = await _userManager.CreateAsync(user, userRegister.Password);

						if (results.Succeeded)
						{
							return RedirectToAction("Index", "Login");
						}
						else
						{
							foreach (var item in results.Errors)
							{
								ModelState.AddModelError("", item.Description);
							}
						}
					}
				}
				return View();

			}
			catch (Exception e)
			{
				throw e;
			}
		}
	}
}
//123456A+a
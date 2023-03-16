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

	public class LoginController : Controller
	{
		private readonly SignInManager<WriterUser> _signInManager;

		public LoginController(SignInManager<WriterUser> signInManager)
		{
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View(new UserLoginViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> Index(UserLoginViewModel userLogin)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(userLogin.Username, userLogin.Password, true, true);

				if (result.Succeeded)
				{
					return RedirectToAction("MainPanel", "Dashboard");
				}
				else
				{
					ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
				}
			}
			return View();
		}
		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Login");
		}

	}
}

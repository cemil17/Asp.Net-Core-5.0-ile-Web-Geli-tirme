using CoreWeb.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Areas.Writer.Controllers
{
	[AllowAnonymous]

	[Area("Writer")]

	public class ProfileController : Controller
	{
		private readonly UserManager<WriterUser> _userManager;

		public ProfileController(UserManager<WriterUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			try
			{
				var getUserInfo = await _userManager.FindByNameAsync(User.Identity.Name);
				UserEditViewModel viewModel = new UserEditViewModel();
				viewModel.Name = getUserInfo.Name;
				viewModel.Email = getUserInfo.Email;
				viewModel.Surname = getUserInfo.Surname;
				viewModel.PictureURL = getUserInfo.ImageURL;
				//viewModel.Password = getUserInfo.PasswordHash.
				//viewModel.PasswordConfirm = getUserInfo.PasswordHash();
				ViewBag.profile = viewModel.PictureURL;

				return View(viewModel);
			}
			catch (Exception e)
			{
				throw e;
			}

		}

		public async Task<IActionResult> Index(UserEditViewModel userEdit)
		{
			try
			{
				var update = await _userManager.FindByNameAsync(User.Identity.Name);

				if (userEdit.Picture != null)
				{
					var resource = Directory.GetCurrentDirectory();
					var extension = Path.GetExtension(userEdit.Picture.FileName);
					var imageName = Guid.NewGuid() + extension;
					var saveLocation = resource + "/wwwroot/userImage/" + imageName;
					var stream = new FileStream(saveLocation, FileMode.Create);
					await userEdit.Picture.CopyToAsync(stream);
					update.ImageURL = imageName;
				}

				update.Name = userEdit.Name;
				//update.Surname = userEdit.Surname;
				update.Email = userEdit.Email;
				update.PasswordHash = _userManager.PasswordHasher.HashPassword(update, userEdit.Password);
				//update.ImageURL = userEdit.PictureURL;
				ViewBag.profile = update.ImageURL;
				var results = await _userManager.UpdateAsync(update);

				if (results.Succeeded)
				{
					var url = Url.RouteUrl("areas", new { controller = "[Author]", action = "Index", area = "[Writer]" });
					return View(url);
					//return RedirectToAction("Index", "", new { area = "" });
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

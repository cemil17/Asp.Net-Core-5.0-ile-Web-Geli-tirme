using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Data;

namespace CoreWeb.Controllers
{
	[Authorize(Roles = "Admin")]

	public class AboutController : Controller
	{
		AboutManager aboutManager = new AboutManager(new EFAboutDal());

		[HttpGet]
		public IActionResult Index()
		{
			var values = aboutManager.GetByID(2);
			ViewBag.profile = values.ImageURL;
			return View(values);
		}
		[HttpPost]
		public IActionResult Index(About about)
		{
			AboutValidator validations = new AboutValidator();
			ValidationResult result = validations.Validate(about);

			if (result.IsValid)
			{
				aboutManager.TUpdate(about);

				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}
	}
}

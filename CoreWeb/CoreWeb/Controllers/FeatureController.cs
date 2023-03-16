using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CoreWeb.Controllers
{
	[Authorize(Roles = "Admin")]

	public class FeatureController : Controller
	{
		FeatureManager featureManager = new FeatureManager(new EFFeatureDal());

		[HttpGet]
		public IActionResult Index()
		{
			var getFeature = featureManager.GetByID(1);
			return View(getFeature);
		}
		[HttpPost]
		public IActionResult Index(Feature feature)
		{
			FeatureValidator validations = new FeatureValidator();
			ValidationResult result = validations.Validate(feature);

			if (result.IsValid)
			{
				featureManager.TUpdate(feature);
				return View();
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

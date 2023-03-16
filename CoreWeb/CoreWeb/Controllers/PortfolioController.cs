using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Controllers
{
	public class PortfolioController : Controller
	{
		PortfolioManager portfolioManager = new PortfolioManager(new EFPortfolioDal());
		public IActionResult Index()
		{
			var listed = portfolioManager.TGetList();
			return View(listed);
		}

		public IActionResult PortfolioStatusToFalse(int id)
		{
			var values = portfolioManager.GetByID(id);
			portfolioManager.TDelete(values);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult PortfolioAdd()
		{
			return View();
		}
		[HttpPost]
		public IActionResult PortfolioAdd(Portfolio portfolio)
		{
			PortfolioValidator validations = new PortfolioValidator();
			ValidationResult result = validations.Validate(portfolio);

			if (result.IsValid)
			{
				portfolioManager.TAdd(portfolio);
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

		[HttpGet]
		public IActionResult PortfolioUpdate(int id)
		{
			var getProject = portfolioManager.GetByID(id);
			return View(getProject);

		}

		[HttpPost]
		public IActionResult PortfolioUpdate(Portfolio portfolio)
		{
			PortfolioValidator validations = new PortfolioValidator();
			ValidationResult result = validations.Validate(portfolio);

			if (result.IsValid)
			{
				portfolioManager.TUpdate(portfolio);
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

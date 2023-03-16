using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Controllers
{
	public class ServiceController : Controller
	{
		ServiceManager serviceManager = new ServiceManager(new EFServiceDal());
		public IActionResult Index()
		{
			var listed = serviceManager.TGetList();
			return View(listed);
		}

		public IActionResult ServiceDelete(int id) 
		{
			var result = serviceManager.GetByID(id);
			serviceManager.TDelete(result);
			return RedirectToAction("Index");
		}
		
		[HttpGet]
		public IActionResult ServiceAdd()
		{
			return View();
		}

		[HttpPost]
		public IActionResult ServiceAdd(Service	service)
		{
			ServiceValidator validations = new ServiceValidator();
			ValidationResult result = validations.Validate(service);

			if (result.IsValid)
			{
				serviceManager.TAdd(service);
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
		public IActionResult ServiceUpdate(int id)
		{
			var values = serviceManager.GetByID(id);
			return View(values);
		}
		[HttpPost]
		public IActionResult ServiceUpdate(Service service)
		{
			ServiceValidator validations = new ServiceValidator();
			ValidationResult result = validations.Validate(service);

			if (result.IsValid)
			{
				serviceManager.TUpdate(service);
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

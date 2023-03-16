using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Controllers
{
	public class ExperienceController : Controller
	{
		ExperienceManager experienceManager = new ExperienceManager(new EFExperienceDal());
		public IActionResult Index()
		{
			var listed = experienceManager.TGetList();
			return View(listed);
		}

		public IActionResult ExperienceDelete(int id)
		{
			var result = experienceManager.GetByID(id);
			experienceManager.TDelete(result);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult ExperienceAdd()
		{
			return View();
		}
		[HttpPost]
		public IActionResult ExperienceAdd(Experience experience)
		{
			experienceManager.TAdd(experience);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult ExperienceUpdate(int id)
		{
			var getExperience = experienceManager.GetByID(id);
			return View(getExperience);
		}
		[HttpPost]
		public IActionResult ExperienceUpdate(Experience experience)
		{
			experienceManager.TUpdate(experience);
			return RedirectToAction("Index");
		}
	}
}

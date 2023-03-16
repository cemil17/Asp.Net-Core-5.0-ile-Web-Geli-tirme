using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Controllers
{
	public class SkillController : Controller
	{
		SkillManager skillManager = new SkillManager(new EFSkillDal());
		public IActionResult Index()
		{
			var listed = skillManager.TGetList();
			return View(listed);
		}

		public IActionResult SkillDelete(int id)
		{
			var values = skillManager.GetByID(id);
			skillManager.TDelete(values);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult SkillAdd()
		{
			return View();
		}

		[HttpPost]
		public IActionResult SkillAdd(Skill skill)
		{
			skillManager.TAdd(skill);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult SkillUpdate(int id)
		{
			var values = skillManager.GetByID(id);
			return View(values);
		}
		[HttpPost]
		public ActionResult SkillUpdate(Skill skill)
		{
			skillManager.TUpdate(skill);
			return RedirectToAction("Index");
		}

	}
}

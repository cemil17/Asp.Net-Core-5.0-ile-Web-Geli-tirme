using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreWeb.Controllers
{
	public class AjaxTransactionsController : Controller
	{
		//AjaxTransactions

		ExperienceManager experienceManager = new ExperienceManager(new EFExperienceDal());
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult ListExperience()
		{
			var getExperience = JsonConvert.SerializeObject(experienceManager.TGetList());
			return Json(getExperience);
		}

		[HttpPost]
		public IActionResult AddExperience(Experience experience)
		{
			experienceManager.TAdd(experience);
			var added = JsonConvert.SerializeObject(experience);
			return Json(added);
		}

		public IActionResult GetByID(int ExperienceID)
		{
			var findValue = experienceManager.GetByID(ExperienceID);
			var getValue = JsonConvert.SerializeObject(findValue);
			return Json(getValue);
		}
		
		public IActionResult DeleteExperience(int id)
		{
			var getValue = experienceManager.GetByID(id);
			experienceManager.TDelete(getValue);			
			return NoContent();
		}
	}
}

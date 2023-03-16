using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Controllers
{
	public class DefaultFieldController : Controller
	{
		//DefaultField
		DefaultFieldManager fieldManager = new DefaultFieldManager(new EFDefaultFieldDal());
		public IActionResult Index()
		{
			var getValues = fieldManager.TGetList();
			return View(getValues);
		}
		public IActionResult DeleteRow(int id) 
		{
			var delete = fieldManager.GetByID(id);
			fieldManager.TDelete(delete);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult AddMotivation()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddMotivation(DefaultField p)
		{
			fieldManager.TAdd(p);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult EditMotivation(int id)
		{
			var getValues = fieldManager.GetByID(id);
			return View(getValues);
		}
		[HttpPost]
		public IActionResult EditMotivation(DefaultField p)
		{
			fieldManager.TUpdate(p);
			return RedirectToAction("Index");
		}
	}
}

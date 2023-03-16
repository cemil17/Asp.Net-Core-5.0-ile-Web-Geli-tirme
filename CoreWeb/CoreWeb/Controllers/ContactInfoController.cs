using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Controllers
{
	public class ContactInfoController : Controller
	{
		ContactManager contactManager = new ContactManager(new EFContactDal());
		[HttpGet]
		public IActionResult Index()
		{
			var values = contactManager.GetByID(1);
			return View(values);
		}
		[HttpPost]
		public IActionResult Index(Contact p)
		{
			contactManager.TUpdate(p);
			return View();
		}

	}
}

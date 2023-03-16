using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CoreWeb.Controllers
{
	[AllowAnonymous]

	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public PartialViewResult HeaderTagPartial()
		{
			return PartialView();
		}
		public PartialViewResult NavbarPartial()
		{
			return PartialView();
		}

		[HttpGet]
		public PartialViewResult SendMessage()
		{
			return PartialView();
		}
		[HttpPost]
		public IActionResult SendMessage(Message p)
		{
			MessageManager messageManager = new MessageManager(new EFMessageDal());

			if (ModelState.IsValid)
			{
				p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
				p.Status = false;

				messageManager.TAdd(p);

				var added = JsonConvert.SerializeObject(p);
				Json(added);
				return RedirectToAction("Index");
			}
			return View();

			//MessageManager messageManager = new MessageManager(new EFMessageDal());
			//p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			//p.Status = false;
			//messageManager.TAdd(p);

			////var added = JsonConvert.SerializeObject(p);
			////return Json(added);
			//return RedirectToAction("Index");


		}

	}
}


//kzv!TYw9 - Cyrus
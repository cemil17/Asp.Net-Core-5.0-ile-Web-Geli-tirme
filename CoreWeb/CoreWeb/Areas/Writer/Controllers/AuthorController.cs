using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreWeb.Areas.Writer.Controllers
{
	[Area("Writer")]
	[Authorize]
	[Route("Writer/[controller]/[action]")]

	public class AuthorController : Controller
	{
		AnnouncementManager announcementManager = new AnnouncementManager(new EFAnnouncementDal());
		public IActionResult Index()
		{
			var listed = announcementManager.TGetList();
			return View(listed);
		}
		public IActionResult GetByID(int id)
		{
			var findValue = announcementManager.GetByID(id);
			var getValue = JsonConvert.SerializeObject(findValue);
			return Json(getValue);
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Add(Announcement announcement)
		{
			announcementManager.TAdd(announcement);					
			return RedirectToAction("Index");
		}


		[HttpGet]
		public IActionResult AnnouncementDetails(int id)
		{
			Announcement announcement = announcementManager.GetByID(id);
			return View(announcement);
		}

	}
}

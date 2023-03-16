using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Controllers
{
	//SocialMedia
	public class SocialMediaController : Controller
	{
		SocialMediaManager socialMediaManager = new SocialMediaManager(new EFSocialMediaDal());
		public IActionResult Index()
		{
			var getSocial = socialMediaManager.TGetList();
			return View(getSocial);
		}
		[HttpGet]
		public IActionResult AddMedia()
		{
			return View();	
		}
		[HttpPost]
		public IActionResult AddMedia(SocialMedia p)
		{
			socialMediaManager.TAdd(p);
			return RedirectToAction("Index");
		}
		public IActionResult DeleteMedia(int id)
		{
			var delete = socialMediaManager.GetByID(id);
			socialMediaManager.TDelete(delete);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult UpdateMedia(int id)
		{
			var updetedValues = socialMediaManager.GetByID(id);
			return View(updetedValues);
		}
		[HttpPost]
		public IActionResult UpdateMedia(SocialMedia p)
		{
			socialMediaManager.TUpdate(p);
			return RedirectToAction("Index");
		}
	}
}

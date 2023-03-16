using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreWeb.Controllers
{
	public class WriterUserController : Controller
	{
		WriterUserManager userManager = new WriterUserManager(new EFWriterUserDal());

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult UserList()
		{
			var values = JsonConvert.SerializeObject(userManager.TGetList());
			return Json(values);
		}
		[HttpPost]
		public IActionResult AddUsers(WriterUser p)
		{
			userManager.TAdd(p);
			var values = JsonConvert.SerializeObject(p);
			return Json(values);	
		}
	}

}

using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Controllers
{
	public class AdminController : Controller
	{
		public PartialViewResult PartialSideBar()
		{
			return PartialView();
		}
		public PartialViewResult PartialFooter()
		{
			return PartialView();
		}
		public PartialViewResult PartialNavbar()
		{
			return PartialView();
		}
		public PartialViewResult PartialHeader()
		{
			return PartialView();
		}
		public PartialViewResult PartialScripts()
		{
			return PartialView();
		}
		public PartialViewResult PartialNavigation()
		{
			return PartialView();
		}
		public PartialViewResult PartialNotifications()
		{

			return PartialView();
		}
	}
}

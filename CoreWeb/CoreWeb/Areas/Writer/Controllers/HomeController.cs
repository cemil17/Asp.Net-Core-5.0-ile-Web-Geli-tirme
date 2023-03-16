using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Areas.Writer.Controllers
{
	public class HomeController : Controller
	{
		public PartialViewResult SideBarPartial()
		{
			return PartialView();
		}
		public PartialViewResult HeadPartial()
		{
			return PartialView();
		}
		public PartialViewResult NavbarPartial()
		{
			return PartialView();
		}
		public PartialViewResult FooterPartial()
		{
			return PartialView();
		}
		public PartialViewResult ScriptPartial()
		{
			return PartialView();
		}
	}
}

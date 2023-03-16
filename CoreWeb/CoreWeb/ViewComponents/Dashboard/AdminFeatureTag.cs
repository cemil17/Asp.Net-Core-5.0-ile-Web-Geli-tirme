using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.ViewComponents.Dashboard
{
	public class AdminFeatureTag : ViewComponent
	{
		Context context = new Context();
		public IViewComponentResult Invoke()
		{
			ViewBag.Tag1 = context.Skills.Count();
			ViewBag.Tag2 = context.Messages.Where(x => x.Status == false).Count();
			ViewBag.Tag3 = context.Messages.Where(x => x.Status == true).Count();
			ViewBag.Tag4 = context.Portfolios.Count();

			return View();
		}
	}
}

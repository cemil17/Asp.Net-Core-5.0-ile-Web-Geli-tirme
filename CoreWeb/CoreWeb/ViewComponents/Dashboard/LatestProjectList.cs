using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.ViewComponents.Dashboard
{
	public class LatestProjectList : ViewComponent
	{
		Context context = new Context();
		public IViewComponentResult Invoke()
		{
			var lastProjects = context.Portfolios.OrderByDescending(x=>x.PortfolioID).Take(5).ToList();
			return View(lastProjects);
		}
	}
}

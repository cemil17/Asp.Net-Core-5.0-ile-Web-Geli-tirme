using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.ViewComponents.About
{
	public class AboutList: ViewComponent
	{
		AboutManager aboutManager = new AboutManager(new EFAboutDal());
		public IViewComponentResult Invoke()
		{
			var values = aboutManager.TGetList();
			return View(values);
		}
	}
}

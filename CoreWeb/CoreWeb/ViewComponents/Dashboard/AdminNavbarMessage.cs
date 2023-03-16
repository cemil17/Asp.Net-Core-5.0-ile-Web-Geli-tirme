using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.ViewComponents.Dashboard
{
	public class AdminNavbarMessage : ViewComponent
	{
		Context c = new Context();
		MessageManager messageManager = new MessageManager(new EFMessageDal());

		public IViewComponentResult Invoke()
		{
			
			var getMessage = messageManager.TGetList().OrderByDescending(x => x.Date).Take(3).ToList();

			var value = c.Messages.Where(x => x.Status == false).Count().ToString();
			//ViewBag.result = value;

			return View(getMessage);
		}		
	}
}

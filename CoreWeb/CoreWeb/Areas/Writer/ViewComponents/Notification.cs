using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreWeb.Areas.Writer.ViewComponents
{
	public class Notification : ViewComponent
	{
		AnnouncementManager announcementManager = new AnnouncementManager(new EFAnnouncementDal());
		public IViewComponentResult Invoke()
		{
			var values = announcementManager.TGetList().OrderByDescending(x=>x.ID).Take(3).ToList();
			return View(values);
		}
	}
}

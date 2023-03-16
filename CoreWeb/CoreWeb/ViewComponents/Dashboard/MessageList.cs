using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.ViewComponents.Dashboard
{
	public class MessageList : ViewComponent
	{
		MessageManager messageManager = new MessageManager(new EFMessageDal());
		public IViewComponentResult Invoke()
		{
			var listed = messageManager.TGetList().Take(2).OrderByDescending(x => x.Date).ToList();
			return View(listed);
		}
	}
}

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.ViewComponents.Contact
{
	public class ContactDetails : ViewComponent
	{
		ContactManager contactManager = new ContactManager(new EFContactDal());
		public IViewComponentResult Invoke()
		{
			var values = contactManager.TGetList();
			return View(values);
		}
	}
}

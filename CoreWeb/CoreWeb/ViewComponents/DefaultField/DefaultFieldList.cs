using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.ViewComponents.DefaultField
{
	public class DefaultFieldList:ViewComponent
	{
		DefaultFieldManager fieldManager = new DefaultFieldManager(new EFDefaultFieldDal());

		public IViewComponentResult Invoke()
		{
			var values= fieldManager.TGetList();
			return View(values);	
		}
	}
}

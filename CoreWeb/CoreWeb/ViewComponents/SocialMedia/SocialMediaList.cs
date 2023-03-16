using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.ViewComponents.SocialMedia
{
	public class SocialMediaList : ViewComponent
	{
		SocialMediaManager mediaManager = new SocialMediaManager(new EFSocialMediaDal());

		public IViewComponentResult Invoke()
		{
			var values = mediaManager.TGetListByQuery();
			return View(values);
		}
	}
}

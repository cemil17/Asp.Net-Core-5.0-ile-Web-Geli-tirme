using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.ViewComponents.Feature
{
	public class FeatureList : ViewComponent
	{
		FeatureManager featureManager = new FeatureManager(new EFFeatureDal());
		public IViewComponentResult Invoke()
		{
			var values = featureManager.TGetList();
			return View(values);
		}
	}
}

using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class SocialMediaManager : ISocialMediaService
	{
		ISocialMediaDal _socialMediaDal;

		public SocialMediaManager(ISocialMediaDal socialMediaDal)
		{
			_socialMediaDal = socialMediaDal;
		}

		public SocialMedia GetByID(int id)
		{
			return _socialMediaDal.GetByID(id);
		}

		public void TAdd(SocialMedia t)
		{
			t.Status = true;
			_socialMediaDal.Insert(t);
		}

		public void TDelete(SocialMedia t)
		{
			t.Status = false;
			_socialMediaDal.Update(t);
		}

		public List<SocialMedia> TGetList()
		{
			return _socialMediaDal.GetList();
		}

        public List<SocialMedia> TGetListByQuery()
        {
			return _socialMediaDal.GetList().Where(x => x.Status == true).ToList();
        }

        public void TUpdate(SocialMedia t)
		{
			t.Status=true;
			_socialMediaDal.Update(t);
		}
	}
}

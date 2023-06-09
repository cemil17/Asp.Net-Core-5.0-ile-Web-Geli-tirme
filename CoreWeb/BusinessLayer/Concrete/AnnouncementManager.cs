﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class AnnouncementManager : IAnnouncementService
	{
		IAnnouncementDal _announcementDal;

		public AnnouncementManager(IAnnouncementDal announcementDal)
		{
			_announcementDal = announcementDal;
		}

		public Announcement GetByID(int id)
		{
			return _announcementDal.GetByID(id);
		}

		public void TAdd(Announcement t)
		{
			_announcementDal.Insert(t);
		}

		public void TDelete(Announcement t)
		{
			throw new NotImplementedException();
		}

		public List<Announcement> TGetList()
		{
			return _announcementDal.GetList();
		}

        public List<Announcement> TGetListByQuery()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Announcement t)
		{
			throw new NotImplementedException();
		}
	}
}

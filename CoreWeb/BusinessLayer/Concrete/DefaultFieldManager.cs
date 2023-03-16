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
	public class DefaultFieldManager : IDefaultFieldService
	{
		IDefaultFieldDal _defaulFieldDal;

		public DefaultFieldManager(IDefaultFieldDal defaulFieldDal)
		{
			_defaulFieldDal = defaulFieldDal;
		}

		public DefaultField GetByID(int id)
		{
			return _defaulFieldDal.GetByID(id);
		}

		public void TAdd(DefaultField t)
		{
			_defaulFieldDal.Insert(t);
		}

		public void TDelete(DefaultField t)
		{
			_defaulFieldDal.Delete(t);
		}

		public List<DefaultField> TGetList()
		{
			return _defaulFieldDal.GetList();
		}

        public List<DefaultField> TGetListByQuery()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(DefaultField t)
		{
			_defaulFieldDal.Update(t);
		}
	}
}

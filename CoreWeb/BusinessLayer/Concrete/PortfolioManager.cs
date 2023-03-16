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
	public class PortfolioManager : IPortfolioService
	{
		IPortfolioDal _portfolioDal;

		public PortfolioManager(IPortfolioDal portfolioDal)
		{
			_portfolioDal = portfolioDal;
		}

		public Portfolio GetByID(int id)
		{
			return _portfolioDal.GetByID(id);
		}

		public void TAdd(Portfolio t)
		{
			t.Status = true;
			_portfolioDal.Insert(t);
		}

		public void TDelete(Portfolio t)
		{
			t.Status = false;
			_portfolioDal.Update(t);
		}

		public List<Portfolio> TGetList()
		{
			return _portfolioDal.GetList();
		}

        public List<Portfolio> TGetListByQuery()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Portfolio t)
		{
			_portfolioDal.Update(t);
		}
	}
}

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
	public class ToDoListManager : ITodoListService
	{
		ITodoListDal _todoListDal;

		public ToDoListManager(ITodoListDal todoListDal)
		{
			_todoListDal = todoListDal;
		}

		public ToDoList GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public void TAdd(ToDoList t)
		{
			throw new NotImplementedException();
		}

		public void TDelete(ToDoList t)
		{
			throw new NotImplementedException();
		}

		public List<ToDoList> TGetList()
		{
			return _todoListDal.GetList();
		}

        public List<ToDoList> TGetListByQuery()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(ToDoList t)
		{
			throw new NotImplementedException();
		}
	}
}

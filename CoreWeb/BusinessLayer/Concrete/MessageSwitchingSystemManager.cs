using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class MessageSwitchingSystemManager : IMessageSwitchingSystemService
	{
		IMessageSwitchingSystemDal _messageswitchingSystemDal;

		public MessageSwitchingSystemManager(IMessageSwitchingSystemDal messageswitchingSystemDal)
		{
			_messageswitchingSystemDal = messageswitchingSystemDal;
		}

		public MessageSwitchingSystem GetByID(int id)
		{
			return _messageswitchingSystemDal.GetByID(id);
		}

		public List<MessageSwitchingSystem> GetListReceiverMessage(string p)
		{
			return _messageswitchingSystemDal.GetByQuery(x => x.Receiver == p);
		}

		public List<MessageSwitchingSystem> GetListSenderMessage(string p)
		{
			return _messageswitchingSystemDal.GetByQuery(x => x.Sender == p);
		}

		public void TAdd(MessageSwitchingSystem t)
		{
			t.Status = false;
			_messageswitchingSystemDal.Insert(t);
		}

		public void TDelete(MessageSwitchingSystem t)
		{
			_messageswitchingSystemDal.Delete(t);
		}

		public List<MessageSwitchingSystem> TGetList()
		{
			throw new NotImplementedException();
		}

		public List<MessageSwitchingSystem> TGetListByQuery()
		{
			throw new NotImplementedException();
		}

		public void TUpdate(MessageSwitchingSystem t)
		{
			t.Status = true;
			_messageswitchingSystemDal.Update(t);
		}
	}
}

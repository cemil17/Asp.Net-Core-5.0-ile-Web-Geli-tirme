using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IMessageSwitchingSystemService : IGenericService<MessageSwitchingSystem>
	{
		List<MessageSwitchingSystem> GetListSenderMessage(string p);
		List<MessageSwitchingSystem> GetListReceiverMessage(string p);
	}
}

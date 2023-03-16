using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CoreWeb.Controllers
{
	[Authorize(Roles = "Admin")]

	public class AdminMessageController : Controller
	{
		MessageSwitchingSystemManager messageManager = new MessageSwitchingSystemManager(new EFMessageSwitchingSystemDal());
		string adminMail = "admin@gmail.com";

		[HttpGet]
		public IActionResult SendBox()
		{
			return View();
		}
		[HttpPost]
		public IActionResult SendBox(MessageSwitchingSystem p)
		{
			p.Sender = adminMail;
			p.SenderName = "Admin";
			p.Date = DateTime.Now;

			Context c = new Context();
			var fullName = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
			p.ReceiverName = fullName;

			messageManager.TAdd(p);

			return RedirectToAction("SenderMessageBox");
		}

		public IActionResult ReceiverMessageBox()
		{
			//adminMail = "admin@gmail.com";
			var getValue = messageManager.GetListReceiverMessage(adminMail).OrderByDescending(x => x.Date).ToList();
			return View(getValue);
		}
		public IActionResult SenderMessageBox()
		{
			var getValue = messageManager.GetListSenderMessage(adminMail).OrderByDescending(x => x.Date).ToList();
			return View(getValue);
		}
		public IActionResult Details(int id)
		{
			var getMessage = messageManager.GetByID(id);
			return View(getMessage);
		}
		public IActionResult DeleteMessage(int id)
		{
			var deleteMessage = messageManager.GetByID(id);
			messageManager.TDelete(deleteMessage);

			if (deleteMessage.Sender != adminMail)
			{
				return RedirectToAction("ReceiverMessageBox");
			}

			else
			{
				return RedirectToAction("SenderMessageBox");
			}
		}
		public IActionResult RecitedMessage(int id)
		{
			var values = messageManager.GetByID(id);
			messageManager.TUpdate(values);

			if (values.Sender != adminMail)
			{
				return RedirectToAction("ReceiverMessageBox");
			}

			else
			{
				return RedirectToAction("SenderMessageBox");
			}
		}
	}
}

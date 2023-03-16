using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Areas.Writer.Controllers
{
	[Area("Writer")]
	[Route("Writer/Message")]

	public class MessageController : Controller
	{
		private readonly UserManager<WriterUser> _userManager;

		MessageSwitchingSystemManager messageManager = new MessageSwitchingSystemManager(new EFMessageSwitchingSystemDal());

		public MessageController(UserManager<WriterUser> userManager)
		{
			_userManager = userManager;
		}
		[Route("")]
		[Route("ReceiverMessage")]
		public async Task<IActionResult> ReceiverMessage(string p)
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			p = values.Email;

			var messageList = messageManager.GetListReceiverMessage(p);
			return View(messageList);
		}
		[Route("ReceiverMessageDetails/{id}")]

		public IActionResult ReceiverMessageDetails(int id)
		{
			MessageSwitchingSystem messageSwitching = messageManager.GetByID(id);
			return View(messageSwitching);
		}
		[Route("")]
		[Route("SenderMessage")]
		public async Task<IActionResult> SenderMessage(string p)
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			p = values.Email;

			var messageList = messageManager.GetListSenderMessage(p);
			return View(messageList);
		}
		[Route("SenderMessageDetails/{id}")]
		public IActionResult SenderMessageDetails(int id)
		{
			MessageSwitchingSystem messageSwitching = messageManager.GetByID(id);
			return View(messageSwitching);
		}
		[HttpGet]
		[Route("")]
		[Route("SendMessage")]
		public IActionResult SendMessage()
		{
			return View();
		}
		[HttpPost]
		[Route("")]
		[Route("SendMessage")]
		public async Task<IActionResult> SendMessage(MessageSwitchingSystem p)
		{
			try
			{
				var values = await _userManager.FindByNameAsync(User.Identity.Name);
				string mail = values.Email;
				string name = values.Name + " " + values.Surname;

				p.Status = true;
				p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
				p.Sender = mail;
				p.SenderName = name;

				Context c = new Context();
				var fullName = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
				p.ReceiverName = fullName;

				messageManager.TAdd(p);

				//var url = Url.RouteUrl("areas", new { controller = "[Message]", action = "SenderMessage", area = "[Writer]" });
				//return View(url);

				return RedirectToAction("SenderMessage");
			}
			catch (Exception e)
			{

				throw e;
			}

		}
	}
}

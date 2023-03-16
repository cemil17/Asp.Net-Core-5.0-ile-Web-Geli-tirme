using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        MessageManager messageManager = new MessageManager(new EFMessageDal());
        public IActionResult Index()
        {
            var messageList = messageManager.TGetList().OrderByDescending(x => x.Date).ToList();
            return View(messageList);
        }
        public IActionResult DeleteMessage(int id)
        {
            var deleteMessage = messageManager.GetByID(id);
            messageManager.TDelete(deleteMessage);
            return RedirectToAction("Index");
        }
        public IActionResult Recited(int id)
        {
            var values = messageManager.GetByID(id);
            messageManager.TUpdate(values);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var getMessage = messageManager.GetByID(id);
            return View(getMessage);
        }
    }
}

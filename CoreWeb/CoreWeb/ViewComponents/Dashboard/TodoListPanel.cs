using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.ViewComponents.Dashboard
{
	public class TodoListPanel : ViewComponent
	{
		ToDoListManager toDoListManager = new ToDoListManager(new EFTodoListDal());
		Context context = new Context();
		public IViewComponentResult Invoke()
		{
			var values = context.ToDoLists.OrderByDescending(x=>x.ID).ToList();
			return View(values);
		}
	}
}

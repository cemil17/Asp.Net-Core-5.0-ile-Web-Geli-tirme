using CoreProject_API.DataAccessLayer.ApiContext;
using CoreProject_API.DataAccessLayer.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetCategoryList()
		{
			using var c = new Context();
			return Ok(c.Categories.ToList());
		}
		[HttpGet("{id}")]
		public IActionResult GetByID(int id)
		{
			using var c = new Context();
			var value = c.Categories.Find(id);

			if (value == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(value);
			}
		}
		[HttpPost]
		public IActionResult Add(Category category)
		{
			using var c = new Context();
			c.Add(category);
			c.SaveChanges();

			return Created("", category);
		}
		[HttpDelete]
		public IActionResult Delete(int id)
		{
			using var c = new Context();
			var deleted = c.Categories.Find(id);

			if (deleted == null)
			{
				return NotFound();
			}
			else
			{
				c.Remove(deleted);
				c.SaveChanges();
				return  NoContent();	
			}
		}
		[HttpPut]
		public IActionResult Update(Category category) 
		{
			using var c = new Context();
			var updated = c.Find<Category>(category.ID);

			if (updated == null)
			{
				return NotFound();
			}
			else
			{
				updated.CategoryName = category.CategoryName;
				c.Categories.Update(updated);
				c.SaveChanges();
				return Ok(updated);
			}
		}
	}
}

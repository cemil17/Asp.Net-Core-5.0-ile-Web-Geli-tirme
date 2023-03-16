using System.ComponentModel.DataAnnotations;

namespace CoreProject_API.DataAccessLayer.Entity
{
	public class Category
	{
		[Key]
        public int ID { get; set; }
        public string CategoryName { get; set; }

    }
}

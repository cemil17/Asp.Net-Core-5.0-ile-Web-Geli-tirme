using CoreProject_API.DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace CoreProject_API.DataAccessLayer.ApiContext
{
	public class Context : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=KI2544200421; Database= CoreWebProjectAPI; Integrated Security=True; ");
		}

        public DbSet<Category> Categories { get; set; }
    }
}

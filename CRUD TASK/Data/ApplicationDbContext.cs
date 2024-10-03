using CRUD_TASK.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_TASK.Data
{
	public class ApplicationDbContext:DbContext

	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
		{ 
		}
		public DbSet<Home> table { get; set; }
	}
}
	

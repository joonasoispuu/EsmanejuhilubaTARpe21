using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EsmaneJuhilubaTARpe21JÕ.Models;

namespace EsmaneJuhilubaTARpe21JÕ.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<EsmaneJuhilubaTARpe21JÕ.Models.Driving_Exam> Driving_Exam { get; set; }
	}
}
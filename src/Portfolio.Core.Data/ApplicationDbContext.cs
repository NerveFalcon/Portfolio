using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Core.Data;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
	public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options ) : base( options ) { }

	public DbSet<Student>          Students           { get; set; }
	public DbSet<Teacher>          Teachers           { get; set; }
	public DbSet<ActivityCategory> ActivityCategories { get; set; }
	public DbSet<Activity>         Activities         { get; set; }
	public DbSet<Link>             Links              { get; set; }

	protected override void OnModelCreating( ModelBuilder builder )
	{
		base.OnModelCreating( builder );

		builder.Ignore<DbEntity>();

		builder.Entity<Student>();

		builder.Entity<Teacher>();

		builder.Entity<ActivityCategory>();

		builder.Entity<Activity>();

		builder.Entity<Link>();
	}
}
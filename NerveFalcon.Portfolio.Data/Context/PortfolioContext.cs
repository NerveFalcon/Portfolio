using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
// ReSharper disable ClassNeverInstantiated.Global
#pragma warning disable CS8618

namespace NerveFalcon.Portfolio.Data.Context;

public class PortfolioContext : DbContext
{
	public PortfolioContext( DbContextOptions options ) : base( options ) { }

	public DbSet<Activity>       Activities       { get; set; }
	public DbSet<Person>         Persons          { get; set; }
	public DbSet<PersonActivity> PersonActivities { get; set; }

	protected override void ConfigureConventions( ModelConfigurationBuilder configurationBuilder )
	{
		base.ConfigureConventions( configurationBuilder );

		configurationBuilder.Properties<Link>()
							.HaveConversion<LinkConversion>();

		configurationBuilder.Properties<Mark>()
							.HaveConversion<MarkConversion>();
	}
}

public class MarkConversion : ValueConverter<Mark, int>
{
	public MarkConversion() : base( m => m.Value, i => new Mark( i ) ) { }
}

public class LinkConversion : ValueConverter<Link, string>
{
	public LinkConversion() : base( l => l.Value.AbsoluteUri, s => new Link( s ) ) { }
}
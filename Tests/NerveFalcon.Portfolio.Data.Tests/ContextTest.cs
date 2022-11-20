using Microsoft.EntityFrameworkCore;
using NerveFalcon.Portfolio.Data.Context;

namespace NerveFalcon.Portfolio.Data.Tests;

public class ContextTest
{
	private const string DbConnect
		= "Host=46.183.163.171;Port=9756;Database=test_portfolio;Username=alekonuser;Password=x&jIBnutwG;Pooling=true;Timeout=300;Command Timeout = 300";
	[ Fact ]
	public void DbInit()
	{
		// Arrange
		var builder = new DbContextOptionsBuilder().UseNpgsql( DbConnect );

		var ctx = new PortfolioContext( builder.Options );

		// Act
		ctx.Database.EnsureDeleted();
		ctx.Database.EnsureCreated();

		// Assert
		var activity = new Activity()
		{
			Title = "Title", Description = "Description",
		};

		ctx.Activities.Add( activity );
	}
}
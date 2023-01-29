using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Data;
using Portfolio.UI;
using Portfolio.UI.Server;
using Portfolio.UI.Server.Data;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString( "DefaultConnection" );
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddPortfolio( options => options.UseSqlite( connectionString ) );

var app = builder.Build();

// Configure the HTTP request pipeline.
if( app.Environment.IsDevelopment() ) { app.UseMigrationsEndPoint(); }
else
{
	app.UseExceptionHandler( "/Error" );
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage( "/_Host" );

app.Run();

async Task Init( IHost app )
{
	using var scope = app.Services.CreateScope();

	var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

	var user = new User
	{
		UserName   = "NerveFalcon",
		FirstName  = "Олег",
		LastName   = "Сураев",
		MiddleName = "Николаевич",
	};

	var res = await userManager.CreateAsync( user, "Passw0rd" );

	if( res.Succeeded )
		await userManager.AddClaimAsync( user, new Claim( ClaimTypes.Role, "Student" ) );
	else
		throw new Exception( "Ошибка добавления пользователя" );
	//*/
}
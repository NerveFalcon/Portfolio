using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Data;
using Portfolio.UI.Server;
using Portfolio.UI.Server.Data;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString( "DefaultConnection" );
builder.Services.AddDbContext<ApplicationDbContext>( options => options.UseSqlite( connectionString ) );
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<User, IdentityRole<Guid>>( config => { config.Password.RequireNonAlphanumeric = false; } )
	   .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

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

// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage( "/_Host" );

app.Run();
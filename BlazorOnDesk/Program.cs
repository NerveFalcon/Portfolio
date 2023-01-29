using BlazorDesktop.Hosting;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Portfolio.UI;

var builder = BlazorDesktopHostBuilder.CreateDefault( args );

var connectionString = @"DataSource=""D:\Windows\Projects\Rider\Portfolio\src\Portfolio.UI.Server\app.db"";Cache=Shared";

builder.UseWebViewInstaller();
builder.Services.AddAuthorizationCore();
builder.Services.AddPortfolio( options => options.UseSqlite( connectionString ) );

builder.RootComponents.Add<App>( "#app" );
builder.RootComponents.Add<HeadOutlet>( "head::after" );

if( builder.HostEnvironment.IsDevelopment() ) { builder.UseDeveloperTools(); }

await builder.Build()
			 .RunAsync();
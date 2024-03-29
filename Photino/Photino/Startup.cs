using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Portfolio.UI;

namespace Photino
{
	public class Startup
	{
		public Startup( IConfiguration configuration ) { Configuration = configuration; }

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices( IServiceCollection services )
		{
			var connectionString = @"DataSource=""D:\Windows\Projects\Rider\Portfolio\src\Portfolio.UI.Server\app.db"";Cache=Shared";
			services.AddDatabaseDeveloperPageExceptionFilter();
			services.AddRazorPages();
			services.AddServerSideBlazor();
			services.AddPortfolio( options => options.UseSqlite( connectionString ) );
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
		{
			if( env.IsDevelopment() ) { app.UseDeveloperExceptionPage(); }
			else
			{
				app.UseExceptionHandler( "/Error" );
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			//[Special for DesktopLoveBlazorWeb]
			//app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints( endpoints =>
							 {
								 endpoints.MapBlazorHub();
								 endpoints.MapFallbackToPage( "/_Host" );
							 }
							);
		}
	}
}
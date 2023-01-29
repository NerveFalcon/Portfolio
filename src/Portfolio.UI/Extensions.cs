using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Core.Data;
using Portfolio.UI.Server;

namespace Portfolio.UI;

public static class Extensions
{
	public static IServiceCollection AddPortfolio( this IServiceCollection provider, Action<DbContextOptionsBuilder> optionsAction )
	{
		provider.AddDbContext<ApplicationDbContext>( optionsAction );

		provider.AddIdentity<User, IdentityRole<Guid>>( config => { config.Password.RequireNonAlphanumeric = false; } )
				.AddEntityFrameworkStores<ApplicationDbContext>();

		provider.AddScoped<ILocalStorageService, LocalStorageService>();
		provider.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

		return provider;
	}
}
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Portfolio.Core.Data;
using Portfolio.UI.Pages;
using Portfolio.UI.Server;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
	public CustomAuthenticationStateProvider( UserManager<User> userManager, ILocalStorageService storageService )
	{
		UserManager    = userManager;
		StorageService = storageService;
	}

	private UserManager<User>    UserManager    { get; set; }
	private ILocalStorageService StorageService { get; set; }

	public override async Task<AuthenticationState> GetAuthenticationStateAsync()
	{
		UserLoginInfo? login = await StorageService.GetAsync<UserLogin>( UserLogin.DictionaryKey );

		if( login is null ) return Anonymus();

		var user = await UserManager.FindByLoginAsync( login.LoginProvider, login.ProviderKey );

		if( user is null ) return Anonymus();
		var claims          = await UserManager.GetClaimsAsync( user );
		var claimsPrincipal = new ClaimsPrincipal( new ClaimsIdentity( claims, login.ProviderDisplayName ) );

		return new AuthenticationState( claimsPrincipal );
	}

	private AuthenticationState Anonymus()
	{
		var claimsPrincipal = new ClaimsPrincipal( new ClaimsIdentity() );

		return new AuthenticationState( claimsPrincipal );
	}
}
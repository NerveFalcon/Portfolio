using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Portfolio.Core.Data;
using Portfolio.UI.Server;

namespace Portfolio.UI.Pages;

public partial class Login : ComponentBase
{
	public Login() => ViewModel = new();

	[ Inject ]
	private UserManager<User> UserManager { get; set; }

	[ Inject ]
	private AuthenticationStateProvider Provider { get; set; }

	[ Inject ]
	private NavigationManager NavigationManager { get; set; }

	[ Inject ]
	private ILocalStorageService StorageService { get; set; }

	public LoginViewModel ViewModel { get; set; }

	protected async Task LoginAsync()
	{
		var user          = await UserManager.FindByNameAsync( ViewModel.UserName );
		var checkPassword = await UserManager.CheckPasswordAsync( user, ViewModel.Password );

		if( !checkPassword ) return;

		await UserManager.AddClaimsAsync( user, new Claim[] { new(ClaimTypes.Name, user.UserName), } );
		var logins = await UserManager.GetLoginsAsync( user );
		foreach ( var loginInfo in logins )
		{
			await UserManager.RemoveLoginAsync( user, loginInfo.LoginProvider, loginInfo.ProviderKey );
		}

		var login  = new UserLogin( "provider", UserManager.GenerateNewAuthenticatorKey(), "display" );
		var result = await UserManager.AddLoginAsync( user, login );

		if( result.Succeeded )
		{
			await StorageService.SetAsync( UserLogin.DictionaryKey, login );
			NavigationManager.NavigateTo( "/", true );
		}
	}
}

public class UserLogin : UserLoginInfo
{
	public const string DictionaryKey = "AuthToken";

	public UserLogin( string loginProvider, string providerKey, string providerDisplayName ) : base( loginProvider,
			 providerKey,
			 providerDisplayName
		) { }
}

public class LoginViewModel
{
	[ Required ]
	[ StringLength( 50, ErrorMessage = "Слишком длиный логин" ) ]
	public string UserName { get; set; }

	[ Required ]
	public string Password { get; set; }
}
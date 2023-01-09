using System.Text.Json;
using Microsoft.JSInterop;

namespace Portfolio.UI.Server;

public class LocalStorageService : ILocalStorageService
{
	private readonly IJSRuntime _jsRuntime;

	private readonly JsonSerializerOptions _serializerOptions;

	public LocalStorageService( IJSRuntime jsRuntime )
	{
		_jsRuntime         = jsRuntime;
		_serializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, };
	}

	#region ILocalStorageService Members

	public async Task SetAsync<T>( string key, T item ) where T : class
	{
		var data = JsonSerializer.Serialize( item, _serializerOptions );
		await _jsRuntime.InvokeVoidAsync( "set", key, data );
	}

	public async Task SetStringAsync( string key, string value ) => await _jsRuntime.InvokeAsync<string>( "set", key, value );

	public async Task<T> GetAsync<T>( string key ) where T : class
	{
		var data = await _jsRuntime.InvokeAsync<string>( "get", key );

		return string.IsNullOrEmpty( data ) ? null! : JsonSerializer.Deserialize<T>( data, _serializerOptions )!;
	}

	public async Task<string> GetStringAsync( string key ) => await _jsRuntime.InvokeAsync<string>( "get", key );

	public async Task RemoveAsync( string key ) => await _jsRuntime.InvokeAsync<string>( "remove", key );

	#endregion
}
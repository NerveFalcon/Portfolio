namespace Portfolio.Core.Data;

/// <summary>
/// Ссылка
/// </summary>
public class Link : DbEntity
{
	/// <summary>Отображаемый текст</summary>
	public string Title { get; init; }

	/// <summary>Адрес</summary>
	public Uri Uri { get; init; }
}
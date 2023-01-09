namespace Portfolio.Core.Data;

/// <summary>
/// Конкретная деятельность
/// </summary>
public class Activity
{
	/// <summary>
	/// Название события/конкретной деятельности
	/// </summary>
	public string            Title       { get; set; }
	
	/// <summary>
	/// Описание
	/// </summary>
	public string            Description { get; set; }
	
	/// <summary>
	/// Дата события/Конкретной деятельности
	/// </summary>
	public DateTime          Date        { get; set; }
	
	/// <summary>
	/// Ссылки на подтверждающие материалы
	/// </summary>
	public IEnumerable<Link> Links       { get; set; }
}

/// <summary>
/// Ссылка
/// </summary>
/// <param name="Title">Отображаемый текст</param>
/// <param name="Uri">Адрес</param>
public record Link( string Title, Uri Uri );
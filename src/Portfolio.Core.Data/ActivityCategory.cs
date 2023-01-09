namespace Portfolio.Core.Data;

/// <summary>
/// Вид деятельности
/// </summary>
public class ActivityCategory : DbEntity
{
	/// <summary>
	/// Название вида деятельности
	/// </summary>
	public string Title { get; set; }

	/// <summary>
	///	Подкатегории вида деятельности 
	/// </summary>
	public IEnumerable<ActivityCategory> SubCategories { get; set; }

	/// <summary>
	/// Конкретная деятельность
	/// </summary>
	public IEnumerable<Activity> Activities { get; set; }

	/// <summary>
	/// Есть ли подкатегории
	/// </summary>
	public bool IsCompose => SubCategories.Any();
}
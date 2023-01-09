namespace Portfolio.Core.Data;

/// <summary>
/// Данные студента
/// </summary>
public class Student : User
{
	/// <summary>
	/// Год поступления
	/// </summary>
	public DateTime AdmissionYear { get; set; }

	/// <summary>
	/// Виды деятельности
	/// </summary>
	public IEnumerable<ActivityCategory> Categories { get; set; }
}
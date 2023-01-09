namespace Portfolio.Core.Data;

/// <summary> Класс таблицы-сущности в БД </summary>
public abstract class DbEntity
{
	/// <summary> Идентификатор сущности </summary>
	public Guid Id { get; set; }
}
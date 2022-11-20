namespace NerveFalcon.Portfolio.Data;

public class Activity
{
	public Guid                  Id            { get; set; }
	public string                Title         { get; set; }
	public string                Description   { get; set; }
	public ICollection<Activity> SubActivities { get; set; }
}
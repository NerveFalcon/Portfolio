namespace NerveFalcon.Portfolio.Data;

public class PersonActivity
{
	public Guid     Id          { get; set; }
	public Person   Person      { get; set; }
	public Activity Activity    { get; set; }
	public string   Title       { get; set; }
	public string   Description { get; set; }
	public DateOnly Date        { get; set; }
	public Link     Link        { get; set; }
	public Mark     Mark        { get; set; }
	public string   Place       { get; set; }
}
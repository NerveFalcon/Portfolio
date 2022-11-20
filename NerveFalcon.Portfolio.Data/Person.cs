namespace NerveFalcon.Portfolio.Data;

public class Person
{
	public Guid     Id                 { get; set; }
	public string   FirstName          { get; set; }
	public string   MiddleName         { get; set; }
	public string   LastName           { get; set; }
	public DateTime BirthDateTime      { get; set; }
	public string   Institution        { get; set; }
	public string   Speciality         { get; set; }
	public string   MilitarySpeciality { get; set; }
	public DateTime AdmissionYear      { get; set; }
	public string   About              { get; set; }
	public UserRole Role               { get; set; }
}
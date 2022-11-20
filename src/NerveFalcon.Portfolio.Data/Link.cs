namespace NerveFalcon.Portfolio.Data;

public sealed class Link : ValueObject<string, Uri>
{
	public Link( Uri value ) : base( value ) { }

	public Link( string value ) : base( value ) { }

	protected override Uri Validate( Uri? value )
	{
		ArgumentNullException.ThrowIfNull( value );

		return value;
	}

	protected override Uri Validate( string uri ) => new(uri);

}
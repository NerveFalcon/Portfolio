namespace NerveFalcon.Portfolio.Data;

public sealed class Mark : ValueObject<int>
{
	public Mark( int value ) : base( value ) { }

	protected override int Validate( int value ) =>
		value is >= 1 and <= 5 ? value : throw new Exception( "Оценка должна быть в диапазоне от 1 до 5" );
}
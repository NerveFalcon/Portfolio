using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Value;

namespace NerveFalcon.Portfolio.Data;

public abstract class ValueObject<T> : PrivateValueObject<T>
{
	protected ValueObject( T value ) : base( value ) { }
}

public abstract class ValueObject<TIn, TReal> : PrivateValueObject<TReal>
{
	protected ValueObject( TReal value ) : base( value ) { }

	protected ValueObject( TIn value ) => Value = Validate( value );

	protected abstract TReal Validate( TIn value );
}

public abstract class PrivateValueObject<T> : ValueObject
{
	protected PrivateValueObject() { }

	protected PrivateValueObject( T value ) => Value = Validate( value );

	public T Value { get; set; }

	protected abstract T Validate( T value );
}
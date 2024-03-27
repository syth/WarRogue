using System;

namespace WarRogue
{
	public class EmptyHandException : Exception
	{
		public EmptyHandException()
		{
		}

		public EmptyHandException( string message )
			: base( message )
		{
		}

		public EmptyHandException( string message, Exception inner )
			: base( message, inner )
		{
		}
	}

	public class HandNotEmptyException : Exception
	{
		public HandNotEmptyException()
		{
		}

		public HandNotEmptyException( string message )
			: base( message )
		{
		}

		public HandNotEmptyException( string message, Exception inner)
			: base( message, inner )
		{
		}
	}



}
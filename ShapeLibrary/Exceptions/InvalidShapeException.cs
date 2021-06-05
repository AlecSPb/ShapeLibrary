using System;

namespace ShapeLibrary.Exceptions
{
	public class InvalidShapeException : Exception
	{
		public InvalidShapeException() { }

		public InvalidShapeException(string message) : base(message) { }

		public InvalidShapeException(string message, Exception inner) : base(message, inner) { }
	}
}
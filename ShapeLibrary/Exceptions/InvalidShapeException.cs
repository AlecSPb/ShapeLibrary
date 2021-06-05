using System;
using ShapeLibrary.Shapes;

namespace ShapeLibrary.Exceptions
{
	public class InvalidShapeException : Exception
	{
		public InvalidShapeException() { }
		public InvalidShapeException(string message) : base(message) { }
		public InvalidShapeException(Shape shape, string message) : base(message)
		{
			Shape = shape;
		}

		public Shape Shape { get; }
	}
}
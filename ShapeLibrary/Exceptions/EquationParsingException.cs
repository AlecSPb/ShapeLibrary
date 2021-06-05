using System;

namespace ShapeLibrary.Exceptions
{
	public class EquationParsingException : Exception
	{
		public EquationParsingException() { }
		public EquationParsingException(string message) : base(message) { }
	}
}
using System;

namespace ShapeLibrary.Exceptions
{
	public class EquationEvaluationException : Exception
	{
		public EquationEvaluationException() { }
		public EquationEvaluationException(string message) : base(message) { }
	}
}
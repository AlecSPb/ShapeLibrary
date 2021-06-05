using System;
using System.Collections.Generic;

namespace ShapeLibrary.EquationParser.Equations
{
	public class Constant : IEquation
	{
		public readonly double Value;

		public Constant(float value)
		{
			Value = value;
		}

		public double Evaluate(double[] variables, List<double> equationVariables, Action<string> errorCallback)
		{
			return Value;
		}
    }
}
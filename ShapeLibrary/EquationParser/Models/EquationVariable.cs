using System;
using System.Collections.Generic;

namespace ShapeLibrary.EquationParser.Equations
{
	public class EquationVariable : IEquation
	{
		public readonly int Index;

		public EquationVariable(int index)
		{
			Index = index;
		}

		public double Evaluate(double[] variables, List<double> equationVariables, Action<string> errorCallback)
		{
			if (Index < equationVariables.Count)
				return equationVariables[Index];

			errorCallback($"Equation variable {Index} not found");
			return default(double);

		}
	}
}
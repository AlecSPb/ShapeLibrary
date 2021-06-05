using System;
using System.Collections.Generic;

namespace ShapeLibrary.EquationParser.Equations
{
	public interface IEquation
	{
		double Evaluate(double[] variables, List<double> equationVariables, Action<string> errorCallback);
	}
}
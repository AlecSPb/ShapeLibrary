using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary.EquationParser
{
	public enum SegmentType
	{
		Number,
		Variable,
		EquationVariable,
		Constant,
		Function,
		Operator,
		Equation
	}
}
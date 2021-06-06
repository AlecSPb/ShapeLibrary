namespace LibraryDemo.Models
{
	public class Constraint
	{
		public Constraint()
		{
			AxisType = AxisConstraintType.None;
			IsStrictlyGreater = false;
			IsStrictlyLess = false;
			LowerBound = -20;
			UpperBound = 20;
		}

		public Constraint(AxisConstraintType axisType, double lowerValue, double greaterValue, bool isStrictlyGreater = false, bool isStrictlyLess = false)
		{
			AxisType = axisType;
			IsStrictlyGreater = isStrictlyGreater;
			IsStrictlyLess = isStrictlyLess;
			LowerBound = lowerValue;
			UpperBound = greaterValue;
		}

		public AxisConstraintType AxisType { get; set; }
		public bool IsStrictlyGreater { get; set; }
		public bool IsStrictlyLess { get; set; }
		public double LowerBound { get; set; }
		public double UpperBound { get; set; }
	}
}
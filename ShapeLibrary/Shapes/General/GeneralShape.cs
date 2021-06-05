using System;

namespace ShapeLibrary.Shapes.General
{
	public class GeneralShape : Shape
	{
		public event Action HandleEquation;

		public override double CalculateArea()
		{
			HandleEquation?.Invoke();
			return base.CalculateArea();
		}
	}
}
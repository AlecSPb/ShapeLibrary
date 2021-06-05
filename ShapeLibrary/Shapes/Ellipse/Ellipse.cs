using System;

namespace ShapeLibrary.Shapes.Ellipse
{
	public class Ellipse : Shape
	{
		public Ellipse()
		{
			Radius = 0.0d;
			EllipseType = EllipseType.None;
		}

		public Ellipse(double radius)
		{
			Radius = radius;
			EllipseType = EllipseType.None;
		}

		public Ellipse(double radius, EllipseType ellipseType)
		{
			Radius = radius;
			EllipseType = ellipseType;
		}

		public double Radius { get; }

		public EllipseType EllipseType { get; }

		public override ShapeType GetShapeType()
		{
			return ShapeType.Ellipse;
		}

		public override double CalculateArea()
		{
			switch (EllipseType)
			{
				case EllipseType.None:
				case EllipseType.Circle:
					return CalculateAreaForCircle();

				case EllipseType.Oval:
					return CalculateAreaForOval();

				case EllipseType.Custom:
					return CalculateAreaForCustomEllipse();

				default:
					return 0.0d;
			}
		}

		private double CalculateAreaForCircle()
		{
			return Math.PI * Math.Pow(Radius, 2);
		}

		private double CalculateAreaForOval()
		{
			return 0.0d;
		}

		private double CalculateAreaForCustomEllipse()
		{
			return 0.0d;
		}
	}
}
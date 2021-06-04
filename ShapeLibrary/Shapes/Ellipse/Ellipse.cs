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

		public override double CalculateSquare()
		{
			switch (EllipseType)
			{
				case EllipseType.None:
				case EllipseType.Circle:
					return CalculateSquareForCircle();

				case EllipseType.Oval:
					return CalculateSquareForOval();

				case EllipseType.Custom:
					return CalculateSquareForCustomEllipse();

				default:
					return 0.0d;
			}
		}

		private double CalculateSquareForCircle()
		{
			return Math.PI * Math.Pow(Radius, 2);
		}

		private double CalculateSquareForOval()
		{
			return 0.0d;
		}

		private double CalculateSquareForCustomEllipse()
		{
			return 0.0d;
		}
	}
}
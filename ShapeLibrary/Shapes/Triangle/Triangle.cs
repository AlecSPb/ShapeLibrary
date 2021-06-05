using System;
using System.Collections.Generic;

namespace ShapeLibrary.Shapes.Triangle
{
	public class Triangle : Shape
	{
		public Triangle()
		{
			LengthFirstSide = 0.0d;
			LengthSecondSide = 0.0d;
			LengthThirdSide = 0.0d;
		}

		public Triangle(double lengthFirstSide, double lengthSecondSide, double lengthThirdSide)
		{
			LengthFirstSide = lengthFirstSide;
			LengthSecondSide = lengthSecondSide;
			LengthThirdSide = lengthThirdSide;
		}

		public double LengthFirstSide { get; }
		public double LengthSecondSide { get; }
		public double LengthThirdSide { get; }

		public bool IsRectangular => CheckTriangleForSquareness();

		public override double CalculateArea()
		{
			return CalculateTriangleAreaByThreeSides();
		}

		public override ShapeType GetShapeType()
		{
			return ShapeType.Triangle;
		}

		private double CalculateTriangleAreaByThreeSides()
		{
			var semiPerimeter = (LengthFirstSide + LengthSecondSide + LengthThirdSide) / 2.0;
			var triangleArea = Math.Sqrt(semiPerimeter * (semiPerimeter - LengthFirstSide) * (semiPerimeter - LengthSecondSide) * (semiPerimeter - LengthThirdSide));

			return triangleArea;
		}

		private double GetSideValueByTitle(TriangleSideTitle triangleSideTitle)
		{
			switch (triangleSideTitle)
			{
				case TriangleSideTitle.First:
					return LengthFirstSide;

				case TriangleSideTitle.Second:
					return LengthSecondSide;

				case TriangleSideTitle.Third:
					return LengthThirdSide;

				default:
					return 0.0d;
			}
		}

		private bool CheckTriangleForSquareness()
		{
			var sideTitles = new List<TriangleSideTitle>()
			{
				TriangleSideTitle.First,
				TriangleSideTitle.Second,
				TriangleSideTitle.Third
			};

			var longestSide = TriangleSideTitle.None;
			if (LengthFirstSide > LengthSecondSide && LengthFirstSide > LengthThirdSide)
			{
				longestSide = TriangleSideTitle.First;
				sideTitles.Remove(longestSide);
			}

			if (LengthSecondSide > LengthFirstSide && LengthSecondSide > LengthThirdSide)
			{
				longestSide = TriangleSideTitle.Second;
				sideTitles.Remove(longestSide);
			}

			if (LengthThirdSide > LengthFirstSide && LengthThirdSide > LengthSecondSide)
			{
				longestSide = TriangleSideTitle.Third;
				sideTitles.Remove(longestSide);
			}

			if (sideTitles.Count != 2)
				return false;

			var firstLeg = GetSideValueByTitle(sideTitles[0]);
			var secondLeg = GetSideValueByTitle(sideTitles[1]);

			var sumLegsSquares = Math.Pow(firstLeg, 2) + Math.Pow(secondLeg, 2);
			var longestSideSquare = Math.Pow(GetSideValueByTitle(longestSide), 2);

			var isTriangleRectangular = Math.Abs(longestSideSquare - sumLegsSquares) < DoubleThreshold;

			return isTriangleRectangular;
		}
	}
}
using ShapeLibrary.Shapes.Ellipse;
using ShapeLibrary.Shapes.Triangle;

namespace ShapeLibrary
{
	public static class Common
	{
		public static double CalculateCircleSquare(double radius)
		{
			var ellipseData = new Ellipse(radius);
			return ellipseData.Square;
		}

		public static double CalculateTriangleSquare(double lengthFirstSide, double lengthSecondSide, double lengthThirdSide)
		{
			var triangleData = new Triangle(lengthFirstSide, lengthSecondSide, lengthThirdSide);
			return triangleData.Square;
		}

		public static bool DetermineWhetherTriangleIsRectangular(double lengthFirstSide, double lengthSecondSide, double lengthThirdSide)
		{
			var triangleData = new Triangle(lengthFirstSide, lengthSecondSide, lengthThirdSide);
			return triangleData.IsRectangular;
		}
	}
}
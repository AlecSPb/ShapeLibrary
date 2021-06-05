using ShapeLibrary.Shapes.Ellipse;
using ShapeLibrary.Shapes.Triangle;

namespace ShapeLibrary
{
	public static class Common
	{
		public static double CalculateCircleArea(double radius)
		{
			var ellipseData = new Ellipse(radius);
			return ellipseData.Area;
		}

		public static double CalculateTriangleArea(double lengthFirstSide, double lengthSecondSide, double lengthThirdSide)
		{
			var triangleData = new Triangle(lengthFirstSide, lengthSecondSide, lengthThirdSide);
			return triangleData.Area;
		}

		public static bool DetermineWhetherTriangleIsRectangular(double lengthFirstSide, double lengthSecondSide, double lengthThirdSide)
		{
			var triangleData = new Triangle(lengthFirstSide, lengthSecondSide, lengthThirdSide);
			return triangleData.IsRectangular;
		}
	}
}
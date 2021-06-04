using System.Collections.Generic;
using System.Windows;

namespace ShapeLibrary.Shapes.Polygon
{
	public class Polygon : Shape
	{

		public Polygon()
		{
			Points = new List<Point>();
		}

		public Polygon(IEnumerable<Point> points)
		{
			Points = points;
		}

		public IEnumerable<Point> Points { get; }

		public override ShapeType GetShapeType()
		{
			return ShapeType.Polygon;
		}

		public override double CalculateSquare()
		{
			return CalculateSquareByCoordinates();
		}

		private double CalculateDeterminant(Point first, Point second)
		{
			return first.X * second.Y - second.X * first.Y;
		}

		private double CalculateSquareByCoordinates()
		{
			var vertices = new List<Point>(Points);
			if (vertices.Count < 3)
				return 0.0d;

			var area = CalculateDeterminant(vertices[vertices.Count - 1], vertices[0]);
			for (var i = 1; i < vertices.Count; i++)
				area += CalculateDeterminant(vertices[i - 1], vertices[i]);

			return area / 2.0;
		}

		/*
		private double CalculateSquareByCoordinates()
		{
			var points = new List<Point>(Points);

			points.Add(points[0]);
			var area = Math.Abs(points.Take(points.Count - 1)
				.Select((p, i) => (points[i + 1].X - p.X) * (points[i + 1].Y + p.Y))
				.Sum() / 2.0);

			return area;
		}
		*/
	}
}
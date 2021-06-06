using System.Windows;
using System.Windows.Controls;

namespace LibraryDemo.Utils
{
	internal class Transformation
	{
		public double MinScreenX { get; set; }
		public double MinScreenY { get; set; }
		public double MinX { get; set; }
		public double MinY { get; set; }
		public double MaxScreenX { get; set; }
		public double MaxScreenY { get; set; }
		public double MaxX { get; set; }
		public double MaxY { get; set; }

		public double numPoints { get; }
		public Transformation(Canvas canvas)
		{
			MinScreenX = 0.0;
			MinScreenY = 0.0;
			MaxScreenX = canvas.ActualWidth;
			MaxScreenY = canvas.ActualHeight;
			numPoints = canvas.ActualWidth;
		}

		public void SetInterval(double minX, double maxX, double minY, double maxY)
		{
			MinX = minX;
			MaxX = maxX;
			MinY = minY;
			MaxY = maxY;
		}

		public double GetX(double x)
		{
			return MinX + x * (MaxX - MinX) / numPoints;
		}
		public double GetX(Point current)
		{
			return MinX + current.X * (MaxX - MinX) / numPoints;
		}

		public double GetY(double y)
		{
			return -(MinY + y * (MaxY - MinY) / MaxScreenY);
		}
		public double GetY(Point current)
		{
			return -(MinY + current.Y * (MaxY - MinY) / MaxScreenY);
		}

		public double GetScreenX(double x)
		{
			return (MaxScreenX - MinScreenX) * (x - MinX) / (MaxX - MinX) + MinScreenX;
		}
		public double GetScreenY(double y)
		{
			return (MinScreenY - MaxScreenY) * (y - MinY) / (MaxY - MinY) + MaxScreenY;
		}
	}
}
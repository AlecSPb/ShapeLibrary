namespace ShapeLibrary.Shapes
{
	public class Shape : IShape
	{
		public const double DoubleThreshold = 5e-4;

		public double Area => CalculateArea();
		public ShapeType ShapeType => GetShapeType();

		public virtual double CalculateArea()
		{
			return 0.0d;
		}

		public virtual ShapeType GetShapeType()
		{
			return ShapeType.None;
		}
	}
}
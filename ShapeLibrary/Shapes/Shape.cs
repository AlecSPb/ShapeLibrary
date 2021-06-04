namespace ShapeLibrary.Shapes
{
	public class Shape : IShape
	{
		public double Square => CalculateSquare();
		public ShapeType ShapeType => GetShapeType();

		public virtual double CalculateSquare()
		{
			return 0.0d;
		}

		public virtual ShapeType GetShapeType()
		{
			return ShapeType.None;
		}
	}
}
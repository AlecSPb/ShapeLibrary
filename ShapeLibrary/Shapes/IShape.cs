namespace ShapeLibrary.Shapes
{
	interface IShape
	{
		double Area { get; }
		ShapeType ShapeType { get; }
		double CalculateArea();
	}
}
namespace ShapeLibrary.Shapes
{
	interface IShape
	{
		double Square { get; }
		ShapeType ShapeType { get; }
		double CalculateSquare();
	}
}
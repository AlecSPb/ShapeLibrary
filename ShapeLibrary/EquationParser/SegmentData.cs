using ShapeLibrary.EquationParser.Equations;

namespace ShapeLibrary.EquationParser
{
	public class SegmentData
	{
		public int Index { get; }
		public string Data { get; }
		public SegmentType Type { get; }
		public IEquation Equation { get; set; }

		internal SegmentData(int index, string data, SegmentType type)
		{
			Index = index;
			Data = data;
			Type = type;
		}

		public override string ToString()
		{
			return $"[{Index}:{Type}]{Data}";
		}
    }
}
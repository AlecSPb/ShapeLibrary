namespace ShapeLibrary.EquationParser
{
	public class Equation
	{
		public string Expression { get; }

		public Equation()
		{
			Expression = string.Empty;
		}

		public Equation(string expression)
		{
			Expression = expression;
		}
	}
}
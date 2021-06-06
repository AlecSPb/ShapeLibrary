using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace LibraryDemo.Models
{
	public class Equation
	{
		public Equation()
		{
			Expression = string.Empty;
			Width = 3;
			Constraints = new List<Constraint>();
			SetColor();
		}
		public string Expression { get; set; }
		public Color Color { get; set; }
		public double Width { get; set; }
		public List<Constraint> Constraints { get; set; }

		private void SetColor()
		{
			var random = new Random();
			Color = Color.FromRgb((byte)random.Next(0, 256), (byte)random.Next(0, 256), (byte)random.Next(0, 256));
		}
	}
}
using System.ComponentModel;
using System.Windows;

namespace ShapeLibrary.Shapes.Polygon
{
	public class ObservablePoint : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public ObservablePoint()
		{
		}

		public ObservablePoint(Point point)
		{
			_point = point;
		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
			var handler = PropertyChanged;
			handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private Point _point;

		public double X
		{
			get => _point.X;
			set
			{
				if (value == _point.X || double.IsNaN(value))
					return;

				_point.X = value;
				OnPropertyChanged("X");
			}
		}

		public double Y
		{
			get => _point.Y;
			set
			{
				if (value == _point.Y || double.IsNaN(value))
					return;

				_point.Y = value;
				OnPropertyChanged("Y");
			}
		}

		public Point GetPoint()
		{
			return _point;
		}
	}
}
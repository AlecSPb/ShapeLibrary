using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using LibraryDemo.Commands;
using LibraryDemo.ViewModels.Base;
using LibraryDemo.Views;
using ShapeLibrary;

namespace LibraryDemo.ViewModels
{
	public class MainWindowViewModel : BaseViewModel
	{
		private double _lengthFirstSide;
		private double _lengthSecondSide;
		private double _lengthThirdSide;
		private bool _isTriangleRectangular;

		private double _ellipseRadius;

		private ICommand _firstTriangleSideChangedCommand;
		private ICommand _secondTriangleSideChangedCommand;
		private ICommand _thirdTriangleSideChangedCommand;

		private ICommand _ellipseRadiusChangedCommand;

		private ICommand _openWindowForCheckCustomShapeCommand;

		private double _triangleArea;
		private double _ellipseArea;

		public MainWindowViewModel()
		{
			FirstTriangleSideChangedCommand = new RelayCommand<TextChangedEventArgs>(HandleFirstTriangleSideChanged);
			SecondTriangleSideChangedCommand = new RelayCommand<TextChangedEventArgs>(HandleSecondTriangleSideChanged);
			ThirdTriangleSideChangedCommand = new RelayCommand<TextChangedEventArgs>(HandleThirdTriangleSideChanged);

			EllipseRadiusChangedCommand = new RelayCommand<TextChangedEventArgs>(HandleEllipseRadiusChanged);

			OpenWindowForCheckCustomShapeCommand = new RelayCommand(OpenWindowForCheckCustomShape);

			LengthFirstSide = 0.0;
			LengthSecondSide = 0.0;
			LengthThirdSide = 0.0;
			IsTriangleRectangular = false;

			EllipseRadius = 0.0;

			TriangleArea = 0.0;
			EllipseArea = 0.0;
		}

		public double LengthFirstSide
		{
			get => _lengthFirstSide;
			set
			{
				_lengthFirstSide = value;
				RaisePropertyChanged();
			}
		}

		public double LengthSecondSide
		{
			get => _lengthSecondSide;
			set
			{
				_lengthSecondSide = value;
				RaisePropertyChanged();
			}
		}

		public double LengthThirdSide
		{
			get => _lengthThirdSide;
			set
			{
				_lengthThirdSide = value;
				RaisePropertyChanged();
			}
		}

		public bool IsTriangleRectangular
		{
			get => _isTriangleRectangular;
			set
			{
				_isTriangleRectangular = value;
				RaisePropertyChanged();
			}
		}

		public double EllipseRadius
		{
			get => _ellipseRadius;
			set
			{
				_ellipseRadius = value;
				RaisePropertyChanged();
			}
		}

		public double TriangleArea
		{
			get => _triangleArea;
			set
			{
				_triangleArea = value;
				RaisePropertyChanged();
			}
		}

		public double EllipseArea
		{
			get => _ellipseArea;
			set
			{
				_ellipseArea = value;
				RaisePropertyChanged();
			}
		}

		public ICommand FirstTriangleSideChangedCommand
		{
			get => _firstTriangleSideChangedCommand;
			set
			{
				_firstTriangleSideChangedCommand = value;
				RaisePropertyChanged();
			}
		}

		public ICommand SecondTriangleSideChangedCommand
		{
			get => _secondTriangleSideChangedCommand;
			set
			{
				_secondTriangleSideChangedCommand = value;
				RaisePropertyChanged();
			}
		}

		public ICommand ThirdTriangleSideChangedCommand
		{
			get => _thirdTriangleSideChangedCommand;
			set
			{
				_thirdTriangleSideChangedCommand = value;
				RaisePropertyChanged();
			}
		}

		public ICommand EllipseRadiusChangedCommand
		{
			get => _ellipseRadiusChangedCommand;
			set
			{
				_ellipseRadiusChangedCommand = value;
				RaisePropertyChanged();
			}
		}

		public ICommand OpenWindowForCheckCustomShapeCommand
		{
			get => _openWindowForCheckCustomShapeCommand;
			set
			{
				_openWindowForCheckCustomShapeCommand = value;
				RaisePropertyChanged();
			}
		}

		private void HandleFirstTriangleSideChanged(TextChangedEventArgs eventArgs)
		{
			var value = eventArgs.Source as TextBox;
			var textData = ReplaceDots(value?.Text);
			if (string.IsNullOrEmpty(textData))
				return;

			if (CheckNumericSequence(textData))
				LengthFirstSide = double.Parse(textData);

			CalculateTriangleArea();
		}

		private void HandleSecondTriangleSideChanged(TextChangedEventArgs eventArgs)
		{
			var value = eventArgs.Source as TextBox;
			var textData = ReplaceDots(value?.Text);
			if (string.IsNullOrEmpty(textData))
				return;

			if (CheckNumericSequence(textData))
				LengthSecondSide = double.Parse(textData);

			CalculateTriangleArea();
		}

		private void HandleThirdTriangleSideChanged(TextChangedEventArgs eventArgs)
		{
			var value = eventArgs.Source as TextBox;
			var textData = ReplaceDots(value?.Text);
			if (string.IsNullOrEmpty(textData))
				return;

			if (CheckNumericSequence(textData))
				LengthThirdSide = double.Parse(textData);

			CalculateTriangleArea();
		}

		private void HandleEllipseRadiusChanged(TextChangedEventArgs eventArgs)
		{
			var value = eventArgs.Source as TextBox;
			var textData = ReplaceDots(value?.Text);
			if (string.IsNullOrEmpty(textData))
				return;

			if (CheckNumericSequence(textData))
				EllipseRadius = double.Parse(textData);

			CalculateEllipseArea();
		}

		private void OpenWindowForCheckCustomShape()
		{
			var customShapeWindow = new CustomShapeWindow();
			customShapeWindow.Show();
		}

		private bool CheckNumericSequence(string value)
		{
			return value.All(char.IsDigit);
		}

		private string ReplaceDots(string value)
		{
			return value.Replace('.', ',');
		}

		private void CalculateTriangleArea()
		{
			TriangleArea = Common.CalculateTriangleArea(LengthFirstSide, LengthSecondSide, LengthThirdSide);
			UpdateIsTriangleRectangularState();
		}

		private void UpdateIsTriangleRectangularState()
		{
			IsTriangleRectangular = Common.DetermineWhetherTriangleIsRectangular(LengthFirstSide, LengthSecondSide, LengthThirdSide);
		}

		private void CalculateEllipseArea()
		{
			EllipseArea = Common.CalculateCircleArea(EllipseRadius);
		}
	}
}
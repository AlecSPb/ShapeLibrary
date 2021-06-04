using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LibraryDemo.Commands;
using LibraryDemo.ViewModels.Base;
using ShapeLibrary;
using ShapeLibrary.Shapes.Triangle;

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

		private double _triangleSquare;
		private double _ellipseSquare;

		public MainWindowViewModel()
		{
			FirstTriangleSideChangedCommand = new RelayCommand<TextChangedEventArgs>(HandleFirstTriangleSideChanged);
			SecondTriangleSideChangedCommand = new RelayCommand<TextChangedEventArgs>(HandleSecondTriangleSideChanged);
			ThirdTriangleSideChangedCommand = new RelayCommand<TextChangedEventArgs>(HandleThirdTriangleSideChanged);

			EllipseRadiusChangedCommand = new RelayCommand<TextChangedEventArgs>(HandleEllipseRadiusChanged);

			LengthFirstSide = 0.0;
			LengthSecondSide = 0.0;
			LengthThirdSide = 0.0;
			IsTriangleRectangular = false;

			EllipseRadius = 0.0;

			TriangleSquare = 0.0;
			EllipseSquare = 0.0;
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

		public double TriangleSquare
		{
			get => _triangleSquare;
			set
			{
				_triangleSquare = value;
				RaisePropertyChanged();
			}
		}

		public double EllipseSquare
		{
			get => _ellipseSquare;
			set
			{
				_ellipseSquare = value;
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

		private void HandleFirstTriangleSideChanged(TextChangedEventArgs eventArgs)
		{
			var value = eventArgs.Source as TextBox;
			var textData = ReplaceDots(value?.Text);
			if (string.IsNullOrEmpty(textData))
				return;

			if (CheckNumericSequence(textData))
				LengthFirstSide = double.Parse(textData);

			CalculateTriangleSquare();
		}

		private void HandleSecondTriangleSideChanged(TextChangedEventArgs eventArgs)
		{
			var value = eventArgs.Source as TextBox;
			var textData = ReplaceDots(value?.Text);
			if (string.IsNullOrEmpty(textData))
				return;

			if (CheckNumericSequence(textData))
				LengthSecondSide = double.Parse(textData);

			CalculateTriangleSquare();
		}

		private void HandleThirdTriangleSideChanged(TextChangedEventArgs eventArgs)
		{
			var value = eventArgs.Source as TextBox;
			var textData = ReplaceDots(value?.Text);
			if (string.IsNullOrEmpty(textData))
				return;

			if (CheckNumericSequence(textData))
				LengthThirdSide = double.Parse(textData);

			CalculateTriangleSquare();
		}

		private void HandleEllipseRadiusChanged(TextChangedEventArgs eventArgs)
		{
			var value = eventArgs.Source as TextBox;
			var textData = ReplaceDots(value?.Text);
			if (string.IsNullOrEmpty(textData))
				return;

			if (CheckNumericSequence(textData))
				EllipseRadius = double.Parse(textData);

			CalculateEllipseSquare();
		}

		private bool CheckNumericSequence(string value)
		{
			return value.All(char.IsDigit);
		}

		private string ReplaceDots(string value)
		{
			return value.Replace('.', ',');
		}

		private void CalculateTriangleSquare()
		{
			TriangleSquare = Common.CalculateTriangleSquare(LengthFirstSide, LengthSecondSide, LengthThirdSide);
			UpdateIsTriangleRectangularState();
		}

		private void UpdateIsTriangleRectangularState()
		{
			IsTriangleRectangular = Common.DetermineWhetherTriangleIsRectangular(LengthFirstSide, LengthSecondSide, LengthThirdSide);
		}

		private void CalculateEllipseSquare()
		{
			EllipseSquare = Common.CalculateCircleSquare(EllipseRadius);
		}
	}
}
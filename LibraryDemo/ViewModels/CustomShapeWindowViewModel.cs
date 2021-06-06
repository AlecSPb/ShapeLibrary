using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using LibraryDemo.Commands;
using LibraryDemo.Models;
using LibraryDemo.Utils;
using LibraryDemo.ViewModels.Base;
using org.mariuszgromada.math.mxparser;

namespace LibraryDemo.ViewModels
{
	public class CustomShapeWindowViewModel : BaseViewModel
	{
		private ICommand _drawEquationCommand;
		private ICommand _windowLoadedCommand;

		private Transformation _transformation;

		public CustomShapeWindowViewModel()
		{
			DrawEquationCommand = new RelayCommand(HandleDrawEquation);
			WindowLoadedCommand = new RelayCommand(WindowLoaded);
		}

		public ICommand DrawEquationCommand
		{
			get => _drawEquationCommand;
			set
			{
				_drawEquationCommand = value;
				RaisePropertyChanged();
			}
		}

		public ICommand WindowLoadedCommand
		{
			get => _windowLoadedCommand;
			set
			{
				_windowLoadedCommand = value;
				RaisePropertyChanged();
			}
		}

		public Canvas WorkspaceCanvas
		{
			get
			{
				var activeWindow = AncestorHelper.FindActiveWindow();
				return activeWindow.FindName("WorkspaceCanvas") as Canvas;
			}
		}

		private void DrawAxis(bool axis)
		{
			var axisX = new Line();
			var axisY = new Line();

			if (axis)
				axisX.Stroke = axisY.Stroke = Brushes.White;
			else
				axisX.Stroke = axisY.Stroke = Brushes.Gray;

			axisX.X1 = _transformation.MinScreenX;
			axisX.Y1 = _transformation.GetScreenY(0);
			axisX.X2 = _transformation.MaxScreenX;
			axisX.Y2 = _transformation.GetScreenY(0);

			axisY.X1 = _transformation.GetScreenX(0);
			axisY.Y1 = _transformation.MinScreenY;
			axisY.X2 = _transformation.GetScreenX(0);
			axisY.Y2 = _transformation.MaxScreenY;

			WorkspaceCanvas.Children.Add(axisX);
			WorkspaceCanvas.Children.Add(axisY);
		}

		private void DrawGrid()
		{
			var xMin = -20.0;
			var xMax = 20.0;
			var yMin = -20.0;
			var yMax = 20.0;
			var widthScreen = _transformation.MaxScreenX;
			var heightScreen = _transformation.MaxScreenY;
			var width = xMax - xMin;
			var height = yMax - yMin;
			var stepValueX = width / 14.0;
			var stepValueY = height / 10.0;

			// X axis
			if (xMin >= 0)
			{
				for (var i = xMin + stepValueX; i <= width + xMin; i += stepValueX)
				{
					var line = new Line
					{
						Stroke = Brushes.Gray,
						X1 = _transformation.GetScreenX(i),
						Y1 = _transformation.MinScreenY,
						X2 = _transformation.GetScreenX(i),
						Y2 = heightScreen
					};

					WorkspaceCanvas.Children.Add(line);
				}
			}

			if (xMin < 0 && xMax > 0)
			{
				for (var i = stepValueX; i <= width; i += stepValueX)
				{
					var line = new Line
					{
						Stroke = Brushes.Gray,
						X1 = _transformation.GetScreenX(i),
						Y1 = _transformation.MinScreenY,
						X2 = _transformation.GetScreenX(i),
						Y2 = heightScreen
					};

					WorkspaceCanvas.Children.Add(line);
				}

				for (var i = -stepValueX; i >= xMin; i -= stepValueX)
				{
					var line = new Line
					{
						Stroke = Brushes.Gray,
						X1 = _transformation.GetScreenX(i),
						Y1 = _transformation.MinScreenY,
						X2 = _transformation.GetScreenX(i),
						Y2 = heightScreen
					};

					WorkspaceCanvas.Children.Add(line);
				}
			}
			if (xMax <= 0)
			{
				for (var i = xMax - stepValueX; i >= xMin; i -= stepValueX)
				{
					var line = new Line
					{
						Stroke = Brushes.Gray,
						X1 = _transformation.GetScreenX(i),
						Y1 = _transformation.MinScreenY,
						X2 = _transformation.GetScreenX(i),
						Y2 = heightScreen
					};

					WorkspaceCanvas.Children.Add(line);
				}
			}

			// Y axis
			if (yMin >= 0)
			{
				for (var i = yMin + stepValueY; i <= height + yMin; i += stepValueY)
				{
					var line = new Line
					{
						Stroke = Brushes.Gray,
						X1 = _transformation.MinScreenX,
						Y1 = _transformation.GetScreenY(i),
						X2 = widthScreen,
						Y2 = _transformation.GetScreenY(i)
					};

					WorkspaceCanvas.Children.Add(line);
				}
			}

			if (yMin < 0 && yMax > 0)
			{
				for (var i = stepValueY; i <= height; i += stepValueY)
				{
					var line = new Line
					{
						Stroke = Brushes.Gray,
						X1 = _transformation.MinScreenX,
						Y1 = _transformation.GetScreenY(i),
						X2 = widthScreen,
						Y2 = _transformation.GetScreenY(i)
					};

					WorkspaceCanvas.Children.Add(line);
				}

				for (var i = -stepValueY; i >= yMin; i -= stepValueY)
				{
					var line = new Line
					{
						Stroke = Brushes.Gray,
						X1 = _transformation.MinScreenX,
						Y1 = _transformation.GetScreenY(i),
						X2 = widthScreen,
						Y2 = _transformation.GetScreenY(i)
					};

					WorkspaceCanvas.Children.Add(line);
				}
			}

			if (yMax > 0)
				return;

			for (var i = yMax - stepValueY; i >= yMin; i -= stepValueY)
			{
				var line = new Line
				{
					Stroke = Brushes.Gray,
					X1 = _transformation.MinScreenX,
					Y1 = _transformation.GetScreenY(i),
					X2 = widthScreen,
					Y2 = _transformation.GetScreenY(i)
				};

				WorkspaceCanvas.Children.Add(line);
			}
		}

		private void DrawTicks()
		{
			var xMin = -20;
			var xMax = 20;
			var yMin = -20;
			var yMax = 20;
			var width = xMax - xMin;
			var height = yMax - yMin;
			var stepValueX = width / 14.0;
			var stepValueY = height / 10.0;

			// X axis
			double yValue;
			if (yMin <= 0 && yMax > 0)
				yValue = 0;
			else if (yMin > 0)
				yValue = yMin;
			else
				yValue = yMax;

			if (xMin >= 0)
			{
				for (var i = xMin + stepValueX; i <= width + xMin; i += stepValueX)
				{
					var line = new Line
					{
						Stroke = Brushes.White,
						X1 = _transformation.GetScreenX(i),
						Y1 = _transformation.GetScreenY(yValue - stepValueY / 5),
						X2 = _transformation.GetScreenX(i),
						Y2 = _transformation.GetScreenY(yValue + stepValueY / 5)
					};

					WorkspaceCanvas.Children.Add(line);
				}
			}
			if (xMin < 0 && xMax > 0)
			{
				for (var i = stepValueX; i <= width; i += stepValueX)
				{
					var line = new Line
					{
						Stroke = Brushes.White,
						X1 = _transformation.GetScreenX(i),
						Y1 = _transformation.GetScreenY(yValue - stepValueY / 5),
						X2 = _transformation.GetScreenX(i),
						Y2 = _transformation.GetScreenY(yValue + stepValueY / 5)
					};

					WorkspaceCanvas.Children.Add(line);
				}
				for (var i = -stepValueX; i >= xMin; i -= stepValueX)
				{
					var line = new Line
					{
						Stroke = Brushes.White,
						X1 = _transformation.GetScreenX(i),
						Y1 = _transformation.GetScreenY(yValue - stepValueY / 5),
						X2 = _transformation.GetScreenX(i),
						Y2 = _transformation.GetScreenY(yValue + stepValueY / 5)
					};

					WorkspaceCanvas.Children.Add(line);
				}
			}
			if (xMax <= 0)
			{
				for (var i = xMax - stepValueX; i >= xMin; i -= stepValueX)
				{
					var line = new Line
					{
						Stroke = Brushes.White,
						X1 = _transformation.GetScreenX(i),
						Y1 = _transformation.GetScreenY(yValue - stepValueY / 5),
						X2 = _transformation.GetScreenX(i),
						Y2 = _transformation.GetScreenY(yValue + stepValueY / 5)
					};

					WorkspaceCanvas.Children.Add(line);
				}
			}

			// Y axis
			double xValue;
			if (xMin <= 0 && xMax > 0)
				xValue = 0;
			else if (xMin > 0)
				xValue = xMin;
			else
				xValue = xMax;

			if (yMin >= 0)
			{
				for (var i = yMin + stepValueY; i <= height + yMin; i += stepValueY)
				{
					var line = new Line
					{
						Stroke = Brushes.White,
						X1 = _transformation.GetScreenX(xValue - stepValueX / 5.0),
						Y1 = _transformation.GetScreenY(i),
						X2 = _transformation.GetScreenX(xValue + stepValueX / 5.0),
						Y2 = _transformation.GetScreenY(i)
					};

					WorkspaceCanvas.Children.Add(line);
				}
			}
			if (yMin < 0 && yMax > 0)
			{
				for (var i = stepValueY; i <= height; i += stepValueY)
				{
					var line = new Line
					{
						Stroke = Brushes.White,
						X1 = _transformation.GetScreenX(xValue - stepValueX / 5.0),
						Y1 = _transformation.GetScreenY(i),
						X2 = _transformation.GetScreenX(xValue + stepValueX / 5.0),
						Y2 = _transformation.GetScreenY(i)
					};

					WorkspaceCanvas.Children.Add(line);
				}
				for (var i = -stepValueY; i >= yMin; i -= stepValueY)
				{
					var line = new Line
					{
						Stroke = Brushes.White,
						X1 = _transformation.GetScreenX(xValue - stepValueX / 5.0),
						Y1 = _transformation.GetScreenY(i),
						X2 = _transformation.GetScreenX(xValue + stepValueX / 5.0),
						Y2 = _transformation.GetScreenY(i)
					};

					WorkspaceCanvas.Children.Add(line);
				}
			}

			if (yMax > 0)
				return;

			for (var i = yMax - stepValueY; i >= yMin; i -= stepValueY)
			{
				var line = new Line
				{
					Stroke = Brushes.White,
					X1 = _transformation.GetScreenX(xValue - stepValueX / 5.0),
					Y1 = _transformation.GetScreenY(i),
					X2 = _transformation.GetScreenX(xValue + stepValueX / 5.0),
					Y2 = _transformation.GetScreenY(i)
				};

				WorkspaceCanvas.Children.Add(line);
			}
		}

		private void DrawNumbers()
		{
			var xMin = -20.0;
			var xMax = 20.0;
			var yMin = -20.0;
			var yMax = 20.0;
			var width = xMax - xMin;
			var height = yMax - yMin;
			var stepValueX = width / 14.0;
			var stepValueY = height / 10.0;

			// Axis X
			double yValue;
			if (yMin < 0 && yMax > 0)
				yValue = 0;
			else if (yMin >= 0)
				yValue = yMin + 4 * (stepValueY / 5);
			else
				yValue = yMax;

			if (xMin >= 0)
			{
				for (var i = xMin + stepValueX; i <= width + xMin; i += stepValueX)
				{
					var number = new TextBlock
					{
						Text = i.ToString("#.##"),
						Foreground = new SolidColorBrush(Colors.White)
					};

					Canvas.SetLeft(number, _transformation.GetScreenX(i - stepValueX / 5));
					Canvas.SetTop(number, _transformation.GetScreenY(yValue - stepValueY / 5));
					WorkspaceCanvas.Children.Add(number);
				}
			}
			if (xMin < 0 && xMax > 0)
			{
				for (var i = stepValueX; i <= width; i += stepValueX)
				{
					var number = new TextBlock
					{
						Text = i.ToString("#.##"),
						Foreground = new SolidColorBrush(Colors.White)
					};
					Canvas.SetLeft(number, _transformation.GetScreenX(i - stepValueX / 5.0));
					Canvas.SetTop(number, _transformation.GetScreenY(yValue - stepValueY / 5.0));
					WorkspaceCanvas.Children.Add(number);
				}
				for (var i = -stepValueX; i >= xMin; i -= stepValueX)
				{
					var number = new TextBlock
					{
						Text = i.ToString("#.##"),
						Foreground = new SolidColorBrush(Colors.White)
					};
					Canvas.SetLeft(number, _transformation.GetScreenX(i - stepValueX / 5.0));
					Canvas.SetTop(number, _transformation.GetScreenY(yValue - stepValueY / 5.0));
					WorkspaceCanvas.Children.Add(number);
				}
			}
			if (xMax <= 0)
			{
				for (var i = xMax - stepValueX; i >= xMin; i -= stepValueX)
				{
					var number = new TextBlock
					{
						Text = i.ToString("#.##"),
						Foreground = new SolidColorBrush(Colors.White)
					};
					Canvas.SetLeft(number, _transformation.GetScreenX(i - stepValueX / 5.0));
					Canvas.SetTop(number, _transformation.GetScreenY(yValue - stepValueY / 5.0));
					WorkspaceCanvas.Children.Add(number);
				}
			}

			// Y axis
			double xValue;
			if (xMin <= 0 && xMax > 0)
				xValue = 0;
			else if (xMin > 0)
				xValue = xMin;
			else
				xValue = xMax - 4 * (stepValueX / 5);

			if (yMin >= 0)
			{
				for (var i = yMin + stepValueY; i <= height + yMin; i += stepValueY)
				{
					var number = new TextBlock
					{
						Text = i.ToString("#.##"),
						Foreground = new SolidColorBrush(Colors.White)
					};

					Canvas.SetLeft(number, _transformation.GetScreenX(xValue + stepValueX / 4.0));
					Canvas.SetTop(number, _transformation.GetScreenY(i + stepValueY / 5.0));
					WorkspaceCanvas.Children.Add(number);
				}
			}
			if (yMin < 0 && yMax > 0)
			{
				for (var i = stepValueY; i <= height; i += stepValueY)
				{
					var number = new TextBlock
					{
						Text = i.ToString("#.##"),
						Foreground = new SolidColorBrush(Colors.White)
					};

					Canvas.SetLeft(number, _transformation.GetScreenX(xValue + stepValueX / 4.0));
					Canvas.SetTop(number, _transformation.GetScreenY(i + stepValueY / 5.0));
					WorkspaceCanvas.Children.Add(number);
				}
				for (var i = -stepValueY; i >= yMin; i -= stepValueY)
				{
					var number = new TextBlock
					{
						Text = i.ToString("#.##"),
						Foreground = new SolidColorBrush(Colors.White)
					};

					Canvas.SetLeft(number, _transformation.GetScreenX(xValue + stepValueX / 4.0));
					Canvas.SetTop(number, _transformation.GetScreenY(i + stepValueY / 5.0));
					WorkspaceCanvas.Children.Add(number);
				}
			}

			if (yMax > 0)
				return;

			for (var i = yMax - stepValueY; i >= yMin; i -= stepValueY)
			{
				var number = new TextBlock
				{
					Text = i.ToString("#.##"),
					Foreground = new SolidColorBrush(Colors.White)
				};

				Canvas.SetLeft(number, _transformation.GetScreenX(xValue + stepValueX / 4.0));
				Canvas.SetTop(number, _transformation.GetScreenY(i + stepValueY / 5.0));
				WorkspaceCanvas.Children.Add(number);
			}
		}

		private void DrawEquations()
		{
			var previous = new Point(0, 0);

			var equation1 = new Equation
			{
				Expression = "(-1/18 * x^2) + 12",
				Constraints = new List<Constraint>()
				{
					new Constraint(AxisConstraintType.XAxis, -12, 12)
				}
			};

			var equation2 = new Equation
			{
				Expression = "(-1/8 * x^2) + 6",
				Constraints = new List<Constraint>()
				{
					new Constraint(AxisConstraintType.XAxis, -4, 4)
				}
			};

			var equation3 = new Equation
			{
				Expression = "(-1/8 * (x+8)^2) + 6",
				Constraints = new List<Constraint>()
				{
					new Constraint(AxisConstraintType.XAxis, -12, -4)
				}
			};

			var equation4 = new Equation
			{
				Expression = "(-1/8 * (x-8)^2) + 6",
				Constraints = new List<Constraint>()
				{
					new Constraint(AxisConstraintType.XAxis, 4, 12)
				}
			};

			var equation5 = new Equation
			{
				Expression = "2 * (x+3)^2 - 9",
				Constraints = new List<Constraint>()
				{
					new Constraint(AxisConstraintType.XAxis, -4, -0.3)
				}
			};

			var equation6 = new Equation
			{
				Expression = "1.5 * (x+3)^2 - 10",
				Constraints = new List<Constraint>()
				{
					new Constraint(AxisConstraintType.XAxis, -4, 0.2)
				}
			};

			var equations = new List<Equation>()
			{
				equation1,
				equation2,
				equation3,
				equation4,
				equation5,
				equation6
			};

			/*
			var test = @"x^2";
			var equations = new List<Equation>()
			{
				new Equation
				{
					Expression = test,
					Constraints = new List<Constraint>()
					{
						new Constraint(AxisConstraintType.XAxis, -20, 20)
					}
				}
			};
			*/

			foreach (var equation in equations)
			{
				Polyline polyline = new Polyline();

				polyline.Stroke = new SolidColorBrush(equation.Color);
				polyline.StrokeThickness = equation.Width;

				var points = new PointCollection();
				var function = new Function("f(x)=" + equation.Expression);
				for (var j = 0; j < _transformation.numPoints; j++)
				{
					var x = _transformation.GetX(j);

					if (!CheckXAxisAvailable(equation.Constraints, x))
						continue;

					var y = function.calculate(x);
					if (double.IsNaN(y))
						continue;

					if (((previous.Y < 0 && y > 0) && (y - previous.Y) > 1) || ((previous.Y > 0 && y < 0) && (previous.Y - y) > 1))
					{

						polyline.Points = points;
						WorkspaceCanvas.Children.Add(polyline);

						polyline = new Polyline
						{
							Stroke = new SolidColorBrush(equation.Color),
							StrokeThickness = equation.Width
						};

						points = new PointCollection();
						previous = new Point(x, y);
					}
					else
					{
						var screenX = _transformation.GetScreenX(x);
						var screenY = _transformation.GetScreenY(y);

						var point = new Point(screenX, screenY);
						previous = new Point(x, y);
						points.Add(point);
					}
				}

				polyline.Points = points;
				WorkspaceCanvas.Children.Add(polyline);
			}
		}

		private bool CheckXAxisAvailable(IReadOnlyCollection<Constraint> constraints, double value)
		{
			var isValueValid = true;

			var axisTypeExist = constraints.Any(constraint => constraint.AxisType == AxisConstraintType.XAxis);
			if (!axisTypeExist)
				return false;

			foreach (var constraint in constraints)
			{
				var isLowerBoundValid = true;
				var isUpperBoundValid = true;
				if (constraint.IsStrictlyGreater)
				{
					isLowerBoundValid = value > constraint.LowerBound;
					if (constraint.IsStrictlyLess)
						isUpperBoundValid = value < constraint.UpperBound;
					else
						isUpperBoundValid = value <= constraint.UpperBound;

					isValueValid &= (isLowerBoundValid && isUpperBoundValid);
				}
				else
				{
					isLowerBoundValid = value >= constraint.LowerBound;
					if (constraint.IsStrictlyLess)
						isUpperBoundValid = value < constraint.UpperBound;
					else
						isUpperBoundValid = value <= constraint.UpperBound;

					isValueValid &= (isLowerBoundValid && isUpperBoundValid);
				}
			}

			return isValueValid;
		}

		private void DrawCoordinateSystem()
		{
			WorkspaceCanvas.Children.Clear();
			_transformation = new Transformation(WorkspaceCanvas);
			_transformation.SetInterval(-20, 20, -20, 20);

			DrawAxis(true);
			DrawGrid();
			DrawTicks();
			DrawNumbers();
		}

		private void WindowLoaded()
		{
			DrawCoordinateSystem();
		}

		private void HandleDrawEquation()
		{
			DrawCoordinateSystem();
			DrawEquations();
		}
	}
}
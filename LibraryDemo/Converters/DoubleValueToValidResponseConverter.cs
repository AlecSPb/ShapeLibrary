using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace LibraryDemo.Converters
{
	public class DoubleValueToValidResponseConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
				return DependencyProperty.UnsetValue;

			var source = (double) value;
			if (double.IsNaN(source))
				return "Такой фигуры не существует";

			return source;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}
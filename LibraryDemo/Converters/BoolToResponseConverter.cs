using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace LibraryDemo.Converters
{
	public class BoolToResponseConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null && (bool) value)
				return "Да";

			return "Нет";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
}

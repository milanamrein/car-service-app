using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace CarService.Admin.Infrastructure.ValueConverters
{
    public class CountToVisibilityValueConverter : BaseValueConverter<CountToVisibilityValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((int)value <= 0) ? Visibility.Collapsed : Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }
    }
}

using System;
using System.Globalization;
using System.Windows;

namespace CarService.Admin.Infrastructure.ValueConverters
{
    public class IsLoadedVisibilityValueConverter : BaseValueConverter<IsLoadedVisibilityValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? Visibility.Collapsed : Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }
    }
}

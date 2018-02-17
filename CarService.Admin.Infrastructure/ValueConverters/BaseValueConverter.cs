using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace CarService.Admin.Infrastructure.ValueConverters
{
    /// <summary>
    /// Abstract Base value converter class for all value converters
    /// </summary>
    /// <typeparam name="T">The value converter class</typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {

        /// <summary>
        /// A private static instance of the value converter
        /// </summary>
        private static T _converter;

        /// <summary>
        /// Returns the private converter or if it's empty, instantiating it
        /// </summary>
        /// <returns>The converter</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ?? (_converter = new T());
        }

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}

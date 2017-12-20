using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace October.Component.Controls
{
    public class NullOrEmptyToFalseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = true;
            string inversion = null;
            if (parameter != null)
                inversion = parameter.ToString();
            if (null == value)
            {
                result = false;
            }
            else
            {
                if (value is string && string.IsNullOrWhiteSpace(value.ToString()))
                {
                    result = false;
                }
                if (value is int && (int)value == 0)
                {
                    result = false;
                }
                if (value is double && (double)value == 0.0)
                {
                    result = false;
                }
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

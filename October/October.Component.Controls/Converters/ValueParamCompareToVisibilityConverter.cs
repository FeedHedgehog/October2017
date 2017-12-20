using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace October.Component.Controls.Converters
{
    public class ValueParamCompareToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return Visibility.Collapsed;
            string a = value.ToString();
            bool hidden = false;
            bool invert = false;
            if (parameter.ToString().Contains("(Hidden)"))
            {
                parameter = parameter.ToString().Remove(parameter.ToString().Length - 8);
                hidden = true;
            }
            if (parameter.ToString().Contains("Invert"))
                invert = true;
            string[] bs = parameter.ToString().Split('*');
            if (bs.ToList().Contains(a))
                return invert == true ? Visibility.Collapsed : Visibility.Visible;
            else if (hidden)
                return invert == true ? Visibility.Visible : Visibility.Hidden;
            else
                return invert == true ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

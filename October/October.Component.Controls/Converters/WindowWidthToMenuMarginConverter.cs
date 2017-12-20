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
    public class WindowWidthToMenuMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double windowWidth = (double)value;//宽度算了DPI的,如果dpi为125%,实际是1536
            if (windowWidth >= 1920d)
            {
                return new Thickness(0, 0, 48, 0);
            }
            else if (windowWidth >= 1536d)
            {
                return new Thickness(0, 0, 30, 0);
            }
            else
            {
                return new Thickness(0, 0, 18, 0);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

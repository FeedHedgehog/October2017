using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace October.Component.Controls
{
    /// <summary>
    /// Grid上的长字符略写（当长度大于100时）
    /// </summary>
    public class CellLongValueClippingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TextBlock text = value as TextBlock;
            if (text == null)
                return value;
            if (string.IsNullOrEmpty(text.Text))
                return text;
            int length = System.Convert.ToInt16(parameter);
            if (text.Text.Length > 100)
                text.Text = text.Text.Remove(length) + "......";
            return text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class LongValueClippingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return value;
            int length = 100;
            if (parameter != null)
                length = System.Convert.ToInt16(parameter);
            if (value.ToString().Length > length)
                value = value.ToString().Remove(length) + "......";
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

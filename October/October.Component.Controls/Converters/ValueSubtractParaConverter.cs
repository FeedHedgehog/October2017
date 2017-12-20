using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace October.Component.Controls.Converters
{
    /// <summary>
    /// 值減去參數获取最终的值
    /// </summary>
    public class ValueSubtractParaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double val = System.Convert.ToDouble(value);
            if (val <= 0.0)
                return value;
            double param = System.Convert.ToDouble(parameter);
            return val - param;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

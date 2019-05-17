using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Module.Converters
{
    public class IntToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Dictionary<int, string> dic = parameter as Dictionary<int, string>;
            return dic[(int)value];
        }
        
        public object ConvertBack(object value, Type targetType, object paramter, CultureInfo culture)
        {
            throw new NotSupportedException("unexpected Convertback");
        }
    }
}

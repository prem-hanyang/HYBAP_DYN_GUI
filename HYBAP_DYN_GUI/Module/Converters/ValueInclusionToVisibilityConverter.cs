using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Module.Converters
{
    public class ValueInclusionToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (((int[])parameter).Contains((int)value))
                return System.Windows.Visibility.Visible;
                
            return System.Windows.Visibility.Collapsed;
        }
        
        public object ConvertBack(object value, Type targetType, object paramter, CultureInfo culture)
        {
            throw new NotSupportedException("unexpected Convertback");
        }
    }
}

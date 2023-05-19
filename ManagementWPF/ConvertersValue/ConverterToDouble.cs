using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ManagementWPF.ConvertersValue
{
    public class ConverterToDouble : IValueConverter
    {
        //COnvert Double To String
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return 0;

            return double.Parse(value.ToString());

            throw new InvalidOperationException("Unsupported type [" + value.GetType().Name + "], ColorToSolidColorBrushValueConverter.Convert()");
        }

        //Convert String to Double
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "";

            return value.ToString();


            throw new InvalidOperationException("Unsupported type [" + value.GetType().Name + "], ColorToSolidColorBrushValueConverter.Convert()");

        }
    }
}

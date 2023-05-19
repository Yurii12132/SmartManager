using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ManagementWPF.ConvertersValue
{
    public class ConverterBrushToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if (value is SolidColorBrush)
            {
                Brush brush = (Brush)value;
                
                SolidColorBrush newBrush = (SolidColorBrush)brush;

                return Color.FromArgb(newBrush.Color.A, newBrush.Color.R, newBrush.Color.G, newBrush.Color.B);
            }
                

            throw new InvalidOperationException("Unsupported type [" + value.GetType().Name + "], ColorToSolidColorBrushValueConverter.Convert()");


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if (value is SolidColorBrush)
            {
                Brush brush = (Brush)value;
                SolidColorBrush newBrush = (SolidColorBrush)brush;
                return newBrush.Color;
            }


            throw new InvalidOperationException("Unsupported type [" + value.GetType().Name + "], ColorToSolidColorBrushValueConverter.Convert()");

        }
    }
}

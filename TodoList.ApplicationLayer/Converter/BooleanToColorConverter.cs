using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace TodoList.ApplicationLayer.Converter
{
    [ValueConversion(typeof(bool), typeof(SolidColorBrush))]
    public class BooleanToColorConverter : IValueConverter
    {
        public Brush TrueBrush { get; set; }

        public Brush FalseBrush { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            var boolValue = value as bool? ?? true;
            if (parameter != null && parameter.ToString() == "!")
            {
                boolValue = !boolValue;
            }

            if (boolValue)
            {
                return TrueBrush;
            }
            return FalseBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

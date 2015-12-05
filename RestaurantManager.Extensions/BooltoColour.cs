using System;
using Windows.UI;
using Windows.UI.Xaml.Data;

namespace RestaurantManager.Extensions
{
    public class BooltoColour : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Color returnValue = Colors.Black;
            if (value is bool)
            {
                returnValue = (bool)value ? Colors.Red : Colors.Transparent;
            }
            return returnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            bool returnValue = default(bool);
            if (value is Color)
            {
                if ((Color)value == Colors.Red) { returnValue = true; }
                else if ((Color)value == Colors.Transparent) { returnValue = false; }
            }
            return returnValue;

        }
    }
}

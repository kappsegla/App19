using System;
using System.Globalization;
using Xamarin.Forms;

namespace App1.ValueConverters
{
    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        { 
            var input = (string) value;
           if (input.Length > 3)
               return Color.Blue;
           return Color.PaleVioletRed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
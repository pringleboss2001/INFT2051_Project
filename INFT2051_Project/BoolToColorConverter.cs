using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFT2051_Project
{
    public class BoolToColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            // Ensure the value is a boolean
            if (value is bool answeredQuestion)
            {
                Console.WriteLine("BoolToColorConverter: isAttempted = " + answeredQuestion);
                return answeredQuestion ? Color.FromArgb("#00FF00") : Color.FromArgb("#FF0000"); // Set colors as per the boolean
            }

            return Color.FromArgb("#000000"); // Fallback color;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

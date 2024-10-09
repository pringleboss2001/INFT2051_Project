using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFT2051_Project
{
    internal class PercentageMultiBinding : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {

            double correct = System.Convert.ToDouble(values[1]);
            double attempted = System.Convert.ToDouble(values[0]);

            return Math.Round((correct / attempted) * 100, 1);            
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

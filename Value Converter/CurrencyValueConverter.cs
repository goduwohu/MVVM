using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MVVM.Value_Converter
{
    public class CurrencyValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal val = (decimal)value;

            string test = parameter != null ? parameter.ToString() : "";

            return val.ToString("0.00 ") + test;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = value.ToString();

            if (parameter == null)
                val = val.Trim();
            else
                val = val.Replace(parameter.ToString(), "").Trim();

            decimal res = decimal.Parse(val);
            return res;
        }
    }
}

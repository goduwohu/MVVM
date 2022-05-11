using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MVVM.Value_Converter
{
    public class EmailConverter : IValueConverter
    {
        const string PREFIX = "mailto";
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string email = value as string;
            if (!String.IsNullOrEmpty(email))
                return $"{PREFIX}{email}";
            return String.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string mailLink = value as string;
            if (!string.IsNullOrEmpty(mailLink) && mailLink.ToLower().StartsWith(PREFIX))
                return mailLink.Substring(PREFIX.Length, mailLink.Length - PREFIX.Length);
            return mailLink ?? string.Empty;
        }
    }
}

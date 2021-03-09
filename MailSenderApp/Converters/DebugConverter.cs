using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;

namespace MailSenderApp.Converters
{
    class DebugConverter : IValueConverter
    {
        //Вызов методов в xaml
        //, Converter={StaticResource DebugConverter}
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debugger.Break();
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Debugger.Break();
            throw new NotImplementedException();
        }
    }
}

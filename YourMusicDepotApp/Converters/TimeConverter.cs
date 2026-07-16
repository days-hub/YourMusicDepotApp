using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using YourMusicDepotApp.Models;
using YourMusicDepotApp.ViewModels;

namespace YourMusicDepotApp.Converters
{
    public class TimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                return dateTime.ToString("HH:mm"); 
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string timeString && DateTime.TryParse(timeString, out var dateTime))
            {
                return dateTime;
            }
            return value;
        }
    }
}

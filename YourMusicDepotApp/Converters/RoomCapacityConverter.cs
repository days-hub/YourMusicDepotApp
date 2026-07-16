using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace YourMusicDepotApp.Converters
{
    public class RoomCapacityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Ensure both values are integers
            if (values[0] is int roomSize && values[1] is int currentCapacityCount)
            {
                return $"{currentCapacityCount}/{roomSize}";
            }
            return "Invalid data";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("RoomCapacityConverter does not support ConvertBack.");
        }
    }

}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using YourMusicDepotApp.Models;
using YourMusicDepotApp.ViewModels;

namespace YourMusicDepotApp.Converters
{
    public class RoomCapacityCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is MusicLesson lesson && lesson.Room != null)
            {
                //  DataContext of the lesson contains the necessary information
                // to retrieve the selected date and calculate the capacity count
                return lesson.CurrentRoomCapacityCount;
            }

            return "N/A"; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("RoomCapacityCountConverter does not support ConvertBack.");
        }
    }
}

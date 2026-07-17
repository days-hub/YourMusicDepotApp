using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace YourMusicDepotApp.Converters
{
    // Shows the lesson-indicator dot on a calendar day when that date has at
    // least one lesson. Inputs: [0] the day button's date, [1] the set of
    // dates that have lessons (SchedulingViewModel.LessonDates).
    public class DateHasLessonsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Hidden rather than Collapsed: the dot's space stays reserved so
            // day numbers align whether or not a date has lessons.
            if (values.Length == 2 && values[0] is DateTime date && values[1] is ISet<DateTime> lessonDates)
            {
                return lessonDates.Contains(date.Date) ? Visibility.Visible : Visibility.Hidden;
            }

            return Visibility.Hidden;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

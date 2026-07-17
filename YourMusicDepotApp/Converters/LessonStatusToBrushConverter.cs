using System;
using System.Globalization;
using System.Windows.Data;
using YourMusicDepotApp.Models;

namespace YourMusicDepotApp.Converters
{
    // Maps a lesson status string to a brush from the shared status palette.
    // ConverterParameter selects which brush: "Fill", "Text", or "Accent".
    public class LessonStatusToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = value as string;
            return (parameter as string) switch
            {
                "Fill" => LessonStatusPalette.FillFor(status),
                "Text" => LessonStatusPalette.TextFor(status),
                _ => LessonStatusPalette.AccentFor(status),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

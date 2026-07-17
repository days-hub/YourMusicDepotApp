using System.Windows.Media;

namespace YourMusicDepotApp.Models
{
    // Single source of truth for the colors used to represent lesson status
    // across the weekly schedule, legend chips, and lesson cards.
    public static class LessonStatusPalette
    {
        public static readonly SolidColorBrush ScheduledAccent = Freeze("#2E7D32");
        public static readonly SolidColorBrush ScheduledFill = Freeze("#E8F5E9");
        public static readonly SolidColorBrush ScheduledText = Freeze("#1B5E20");

        public static readonly SolidColorBrush CompletedAccent = Freeze("#1565C0");
        public static readonly SolidColorBrush CompletedFill = Freeze("#E3F2FD");
        public static readonly SolidColorBrush CompletedText = Freeze("#0D47A1");

        public static readonly SolidColorBrush CanceledAccent = Freeze("#C62828");
        public static readonly SolidColorBrush CanceledFill = Freeze("#FDECEA");
        public static readonly SolidColorBrush CanceledText = Freeze("#B71C1C");

        public static readonly SolidColorBrush DefaultAccent = Freeze("#616161");
        public static readonly SolidColorBrush DefaultFill = Freeze("#F5F5F5");
        public static readonly SolidColorBrush DefaultText = Freeze("#424242");

        public static SolidColorBrush AccentFor(string status) => status switch
        {
            "Scheduled" => ScheduledAccent,
            "Completed" => CompletedAccent,
            "Canceled" => CanceledAccent,
            _ => DefaultAccent,
        };

        public static SolidColorBrush FillFor(string status) => status switch
        {
            "Scheduled" => ScheduledFill,
            "Completed" => CompletedFill,
            "Canceled" => CanceledFill,
            _ => DefaultFill,
        };

        public static SolidColorBrush TextFor(string status) => status switch
        {
            "Scheduled" => ScheduledText,
            "Completed" => CompletedText,
            "Canceled" => CanceledText,
            _ => DefaultText,
        };

        private static SolidColorBrush Freeze(string hex)
        {
            var brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(hex));
            brush.Freeze();
            return brush;
        }
    }
}

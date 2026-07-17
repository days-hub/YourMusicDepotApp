using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using YourMusicDepotApp.Models;

namespace YourMusicDepotApp.Controls
{
    /// <summary>
    /// A lightweight week-at-a-glance scheduler: seven day columns with an
    /// hour gutter, rendering <see cref="ScheduleAppointment"/> items as
    /// colored cards positioned by start time and duration. Overlapping
    /// appointments within a day are laid out side by side.
    /// </summary>
    public partial class WeekScheduleControl : UserControl
    {
        // Displayed hours (8:00 through 21:00) and vertical scale.
        private const int StartHour = 8;
        private const int EndHour = 21;
        private const double HourHeight = 56;
        private const double GutterWidth = 56;
        private const double TopPad = 8;
        private const double BottomPad = 8;

        private static readonly Brush GridLineBrush = Frozen("#EFEFEF");
        private static readonly Brush LabelBrush = Frozen("#9E9E9E");
        private static readonly Brush TodayTintBrush = Frozen("#F6F3FB");
        private static readonly Brush FallbackAccentBrush = Frozen("#673AB7");

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            nameof(ItemsSource), typeof(IEnumerable<ScheduleAppointment>), typeof(WeekScheduleControl),
            new PropertyMetadata(null, OnScheduleChanged));

        public static readonly DependencyProperty WeekStartProperty = DependencyProperty.Register(
            nameof(WeekStart), typeof(DateTime), typeof(WeekScheduleControl),
            new PropertyMetadata(DateTime.MinValue, OnScheduleChanged));

        public IEnumerable<ScheduleAppointment> ItemsSource
        {
            get => (IEnumerable<ScheduleAppointment>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public DateTime WeekStart
        {
            get => (DateTime)GetValue(WeekStartProperty);
            set => SetValue(WeekStartProperty, value);
        }

        public WeekScheduleControl()
        {
            InitializeComponent();
            Loaded += (_, _) => Rebuild();
        }

        private static void OnScheduleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((WeekScheduleControl)d).Rebuild();
        }

        private void Rebuild()
        {
            if (!IsLoaded && WeekStart == DateTime.MinValue)
            {
                return;
            }

            var weekStart = (WeekStart == DateTime.MinValue ? DateTime.Today : WeekStart).Date;
            var appointments = (ItemsSource ?? Enumerable.Empty<ScheduleAppointment>())
                .Where(a => a.StartTime.Date >= weekStart && a.StartTime.Date < weekStart.AddDays(7))
                .ToList();

            BuildHeader(weekStart);
            BuildBody(weekStart, appointments);

            EmptyWeekText.Visibility = appointments.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        private void BuildHeader(DateTime weekStart)
        {
            HeaderGrid.Children.Clear();
            HeaderGrid.ColumnDefinitions.Clear();
            HeaderGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(GutterWidth) });

            var accent = TryFindResource("PrimaryHueMidBrush") as Brush ?? FallbackAccentBrush;

            for (int i = 0; i < 7; i++)
            {
                HeaderGrid.ColumnDefinitions.Add(new ColumnDefinition());
                var day = weekStart.AddDays(i);
                bool isToday = day == DateTime.Today;

                var dayName = new TextBlock
                {
                    Text = day.ToString("ddd").ToUpperInvariant(),
                    FontSize = 10,
                    Foreground = isToday ? accent : LabelBrush,
                    FontWeight = isToday ? FontWeights.SemiBold : FontWeights.Normal,
                    HorizontalAlignment = HorizontalAlignment.Center,
                };

                var dayNumber = new TextBlock
                {
                    Text = day.Day.ToString(),
                    FontSize = 15,
                    Foreground = isToday ? Brushes.White : Frozen("#424242"),
                    FontWeight = FontWeights.Medium,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                };

                var numberHost = new Border
                {
                    Width = 28,
                    Height = 28,
                    CornerRadius = new CornerRadius(14),
                    Background = isToday ? accent : Brushes.Transparent,
                    Child = dayNumber,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0, 2, 0, 0),
                };

                var cell = new StackPanel { HorizontalAlignment = HorizontalAlignment.Center };
                cell.Children.Add(dayName);
                cell.Children.Add(numberHost);

                Grid.SetColumn(cell, i + 1);
                HeaderGrid.Children.Add(cell);
            }
        }

        private void BuildBody(DateTime weekStart, List<ScheduleAppointment> appointments)
        {
            BodyGrid.Children.Clear();
            BodyGrid.ColumnDefinitions.Clear();
            BodyGrid.RowDefinitions.Clear();

            BodyGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(GutterWidth) });
            for (int i = 0; i < 7; i++)
            {
                BodyGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            int totalHours = EndHour - StartHour;
            double bodyHeight = totalHours * HourHeight;
            BodyGrid.Height = TopPad + bodyHeight + BottomPad;

            // Hour lines spanning the full width, plus hour labels in the gutter.
            for (int h = 0; h <= totalHours; h++)
            {
                double y = TopPad + h * HourHeight;

                var line = new Border
                {
                    Height = 1,
                    Background = GridLineBrush,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(GutterWidth, y, 0, 0),
                    IsHitTestVisible = false,
                };
                Grid.SetColumn(line, 0);
                Grid.SetColumnSpan(line, 8);
                BodyGrid.Children.Add(line);

                var label = new TextBlock
                {
                    Text = DateTime.Today.AddHours(StartHour + h).ToString("h tt"),
                    FontSize = 10,
                    Foreground = LabelBrush,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(0, y - 6, 8, 0),
                };
                Grid.SetColumn(label, 0);
                BodyGrid.Children.Add(label);
            }

            for (int i = 0; i < 7; i++)
            {
                var day = weekStart.AddDays(i);

                // Column separator and a subtle tint on today's column.
                var columnBackground = new Border
                {
                    BorderBrush = GridLineBrush,
                    BorderThickness = new Thickness(1, 0, 0, 0),
                    Background = day == DateTime.Today ? TodayTintBrush : Brushes.Transparent,
                    IsHitTestVisible = false,
                };
                Grid.SetColumn(columnBackground, i + 1);
                BodyGrid.Children.Add(columnBackground);

                var dayHost = new Grid
                {
                    VerticalAlignment = VerticalAlignment.Top,
                    Height = bodyHeight,
                    Margin = new Thickness(0, TopPad, 0, 0),
                };
                Grid.SetColumn(dayHost, i + 1);
                BodyGrid.Children.Add(dayHost);

                var dayAppointments = appointments
                    .Where(a => a.StartTime.Date == day)
                    .OrderBy(a => a.StartTime)
                    .ThenBy(a => a.EndTime)
                    .ToList();

                foreach (var cluster in ClusterOverlapping(dayAppointments))
                {
                    dayHost.Children.Add(BuildCluster(cluster));
                }
            }
        }

        /// <summary>
        /// Groups a day's appointments into vertically disjoint clusters of
        /// transitively overlapping items, assigning each appointment a column
        /// so overlapping cards render side by side.
        /// </summary>
        private static IEnumerable<List<(ScheduleAppointment Appointment, int Column, int ColumnCount)>> ClusterOverlapping(
            List<ScheduleAppointment> sorted)
        {
            var clusters = new List<List<ScheduleAppointment>>();
            DateTime clusterEnd = DateTime.MinValue;

            foreach (var appointment in sorted)
            {
                if (clusters.Count == 0 || appointment.StartTime >= clusterEnd)
                {
                    clusters.Add(new List<ScheduleAppointment>());
                    clusterEnd = appointment.EndTime;
                }
                else if (appointment.EndTime > clusterEnd)
                {
                    clusterEnd = appointment.EndTime;
                }

                clusters[^1].Add(appointment);
            }

            foreach (var cluster in clusters)
            {
                var columnEnds = new List<DateTime>();
                var placed = new List<(ScheduleAppointment, int, int)>();

                foreach (var appointment in cluster)
                {
                    int column = columnEnds.FindIndex(end => end <= appointment.StartTime);
                    if (column < 0)
                    {
                        column = columnEnds.Count;
                        columnEnds.Add(appointment.EndTime);
                    }
                    else
                    {
                        columnEnds[column] = appointment.EndTime;
                    }

                    placed.Add((appointment, column, 0));
                }

                yield return placed
                    .Select(p => (p.Item1, p.Item2, columnEnds.Count))
                    .ToList();
            }
        }

        private static Grid BuildCluster(List<(ScheduleAppointment Appointment, int Column, int ColumnCount)> cluster)
        {
            double clusterTop = cluster.Min(c => OffsetFor(c.Appointment.StartTime));
            double clusterBottom = cluster.Max(c => OffsetFor(c.Appointment.EndTime));

            var host = new Grid
            {
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(3, clusterTop, 3, 0),
                Height = Math.Max(clusterBottom - clusterTop, MinCardHeight),
            };

            int columnCount = cluster[0].ColumnCount;
            for (int i = 0; i < columnCount; i++)
            {
                host.ColumnDefinitions.Add(new ColumnDefinition());
            }

            foreach (var (appointment, column, _) in cluster)
            {
                double top = OffsetFor(appointment.StartTime) - clusterTop;
                double height = Math.Max(OffsetFor(appointment.EndTime) - OffsetFor(appointment.StartTime) - 2, MinCardHeight);

                var card = BuildCard(appointment);
                card.Margin = new Thickness(column == 0 ? 0 : 2, top, 0, 0);
                card.Height = height;
                card.VerticalAlignment = VerticalAlignment.Top;
                Grid.SetColumn(card, column);
                host.Children.Add(card);
            }

            return host;
        }

        private const double MinCardHeight = 20;

        private static Border BuildCard(ScheduleAppointment appointment)
        {
            bool canceled = appointment.Status == "Canceled";

            var time = new TextBlock
            {
                Text = $"{appointment.StartTime:HH:mm}–{appointment.EndTime:HH:mm}",
                FontSize = 10,
                Foreground = appointment.TextBrush,
                Opacity = 0.8,
                TextTrimming = TextTrimming.CharacterEllipsis,
            };

            var student = new TextBlock
            {
                Text = appointment.StudentName,
                FontSize = 12,
                FontWeight = FontWeights.SemiBold,
                Foreground = appointment.TextBrush,
                TextTrimming = TextTrimming.CharacterEllipsis,
                TextDecorations = canceled ? TextDecorations.Strikethrough : null,
            };

            var detail = new TextBlock
            {
                Text = string.Join(" · ", new[] { appointment.InstructorName, appointment.RoomLabel }
                    .Where(s => !string.IsNullOrEmpty(s))),
                FontSize = 11,
                Foreground = appointment.TextBrush,
                Opacity = 0.8,
                TextTrimming = TextTrimming.CharacterEllipsis,
            };

            var text = new StackPanel { Margin = new Thickness(6, 2, 6, 2) };
            text.Children.Add(time);
            text.Children.Add(student);
            text.Children.Add(detail);

            var layout = new Grid { ClipToBounds = true };
            layout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3) });
            layout.ColumnDefinitions.Add(new ColumnDefinition());

            var accentBar = new Border
            {
                Background = appointment.AccentBrush,
                CornerRadius = new CornerRadius(3, 0, 0, 3),
            };
            Grid.SetColumn(accentBar, 0);
            Grid.SetColumn(text, 1);
            layout.Children.Add(accentBar);
            layout.Children.Add(text);

            return new Border
            {
                Background = appointment.FillBrush,
                CornerRadius = new CornerRadius(4),
                Child = layout,
                Opacity = canceled ? 0.8 : 1.0,
                ToolTip = $"{appointment.StudentName} with {appointment.InstructorName}\n" +
                          $"{appointment.StartTime:dddd, MMM d · HH:mm}–{appointment.EndTime:HH:mm}\n" +
                          $"{appointment.RoomLabel} · {appointment.Status}",
            };
        }

        // Vertical pixel offset within a day column for a given time of day,
        // clamped to the displayed hour range.
        private static double OffsetFor(DateTime time)
        {
            double hours = Math.Clamp(time.TimeOfDay.TotalHours, StartHour, EndHour);
            return (hours - StartHour) * HourHeight;
        }

        private static SolidColorBrush Frozen(string hex)
        {
            var brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(hex));
            brush.Freeze();
            return brush;
        }
    }
}

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YourMusicDepotApp.Data;
using YourMusicDepotApp.Models;

namespace YourMusicDepotApp.ViewModels
{
    // Provides the dashboard statistics and today's lesson list for the home view.
    public class HomeViewModel : INotifyPropertyChanged
    {
        private readonly YourMusicDepotContext _context;

        private int _studentCount;
        private int _instructorCount;
        private int _lessonsTodayCount;
        private decimal _revenueThisMonth;
        private ObservableCollection<MusicLesson> _todaysLessons = new();

        public HomeViewModel(YourMusicDepotContext context)
        {
            _context = context;
            LoadDashboard();
        }

        public int StudentCount
        {
            get => _studentCount;
            set { _studentCount = value; OnPropertyChanged(nameof(StudentCount)); }
        }

        public int InstructorCount
        {
            get => _instructorCount;
            set { _instructorCount = value; OnPropertyChanged(nameof(InstructorCount)); }
        }

        public int LessonsTodayCount
        {
            get => _lessonsTodayCount;
            set { _lessonsTodayCount = value; OnPropertyChanged(nameof(LessonsTodayCount)); }
        }

        public decimal RevenueThisMonth
        {
            get => _revenueThisMonth;
            set { _revenueThisMonth = value; OnPropertyChanged(nameof(RevenueThisMonth)); }
        }

        public ObservableCollection<MusicLesson> TodaysLessons
        {
            get => _todaysLessons;
            set { _todaysLessons = value; OnPropertyChanged(nameof(TodaysLessons)); }
        }

        public string TodayDisplay => DateTime.Today.ToString("dddd, MMMM d, yyyy");

        private async void LoadDashboard()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            var monthStart = new DateTime(today.Year, today.Month, 1);
            var nextMonthStart = monthStart.AddMonths(1);

            StudentCount = await _context.Students.CountAsync();
            InstructorCount = await _context.Instructors.CountAsync();

            var todaysLessons = await _context.MusicLessons
                .Where(ml => ml.MusicLessonStartDateTime >= today && ml.MusicLessonStartDateTime < tomorrow)
                .Include(ml => ml.Instructor)
                .Include(ml => ml.Student)
                .Include(ml => ml.Room)
                .OrderBy(ml => ml.MusicLessonStartDateTime)
                .ToListAsync();

            TodaysLessons = new ObservableCollection<MusicLesson>(todaysLessons);
            LessonsTodayCount = todaysLessons.Count;

            RevenueThisMonth = await _context.MusicLessonPayments
                .Where(p => p.MusicLessonPaymentDate >= monthStart && p.MusicLessonPaymentDate < nextMonthStart)
                .SumAsync(p => (decimal?)p.MusicLessonPaymentAmount) ?? 0m;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

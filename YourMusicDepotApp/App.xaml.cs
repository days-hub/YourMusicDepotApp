using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using YourMusicDepotApp.Data;
using YourMusicDepotApp.Repositories;
using YourMusicDepotApp.Repositories.Interfaces;
using YourMusicDepotApp.ViewModels;

namespace YourMusicDepotApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }
        private void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<Func<YourMusicDepotContext>>(provider => () => new YourMusicDepotContext());
            services.AddScoped<IMusicLessonRepository, MusicLessonRepository>();
            // ... other services and view models
            
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            RegisterGlobalExceptionHandlers();

            base.OnStartup(e);
        }

        // Catches exceptions that would otherwise terminate the app (e.g. exceptions
        // escaping async void event handlers) and surfaces them in a dialog instead.
        private void RegisterGlobalExceptionHandlers()
        {
            // UI-thread exceptions, including those rethrown from async void methods.
            DispatcherUnhandledException += (sender, args) =>
            {
                ShowUnexpectedError(args.Exception);
                args.Handled = true;
            };

            // Faulted Tasks whose exceptions were never observed.
            TaskScheduler.UnobservedTaskException += (sender, args) =>
            {
                args.SetObserved();
                Dispatcher.BeginInvoke(() => ShowUnexpectedError(args.Exception));
            };

            // Last resort for non-UI-thread exceptions; the process still terminates,
            // but the error is shown to the user first.
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                if (args.ExceptionObject is Exception ex)
                {
                    ShowUnexpectedError(ex);
                }
            };
        }

        private static void ShowUnexpectedError(Exception exception)
        {
            // Unwrap AggregateException so the dialog shows the actual cause.
            if (exception is AggregateException aggregate && aggregate.InnerException != null)
            {
                exception = aggregate.InnerException;
            }

            MessageBox.Show(
                $"An unexpected error occurred:\n\n{exception.Message}",
                "YourMusicDepot",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }
}

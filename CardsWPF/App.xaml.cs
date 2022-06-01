using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using CardsWPF.Services.Implementations;
using CardsWPF.Services.Interfaces;
using CardsWPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;


namespace CardsWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            Configuration(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void Configuration(IServiceCollection services)
        {
            services.AddScoped<HttpClient>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IApiService, ApiService>();
            services.AddSingleton<MainWindowViewModels>();
            services.AddSingleton<MainWindow>();
        }
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}

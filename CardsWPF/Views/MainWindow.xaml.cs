using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CardsWPF.Services.Interfaces;
using CardsWPF.ViewModels;
using CardsWPF.Views;

namespace CardsWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IApiService _apiService;
        private readonly MainWindowViewModels _viewModels;
        public MainWindow(MainWindowViewModels viewModels, IApiService apiService)
        {
            _apiService = apiService;
            _viewModels = viewModels;
            InitializeComponent();
            DataContext = _viewModels;
            
        }

        
        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddWindow(_apiService);
            if ((bool)addWindow.ShowDialog())
            {
                _viewModels.Add(addWindow.Card);
            }

        }

        private void Refresh_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModels.Refresh();
        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModels.Delete();
        }

        private void Update_OnClick(object sender, RoutedEventArgs e)
        {
            var updateWindow = new UpdateWindow(_viewModels.SelectedCard,_apiService);
            if ((bool)updateWindow.ShowDialog())
            {
                _viewModels.Update(updateWindow.SelectedCard);
            }

        }
    }
}

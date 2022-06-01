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
using System.Windows.Shapes;
using CardsWPF.Models;
using CardsWPF.Services.Interfaces;
using Microsoft.Win32;

namespace CardsWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public Card Card { get; private set; }
        private readonly IApiService _apiService;

        public AddWindow(IApiService apiService)
        {
            _apiService = apiService;
            InitializeComponent();
            Card = (Card)DataContext;
        }

        private async void AddFile_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Filter = "png files(*.png) |*.png";
            if ((bool)fileDialog.ShowDialog())
            {
                var stream = fileDialog.OpenFile();
                var data = new byte[stream.Length];
                await stream.ReadAsync(data, 0, data.Length);
                Card.Title = data;

            }

        }
        private async void Accept_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Card.Name) && Card.Title != null)
            {
                Card.Name = TitleBox.Text;
                await _apiService.FileService.Post(Card);
                DialogResult = true;
                Close();
                return;
            }

            MessageBox.Show("Image or Name is not valid, pls add something");
        }
    }
}

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
    public partial class UpdateWindow : Window
    {
        private readonly IApiService _apiService;
        public Card SelectedCard { get; private set; }
        public UpdateWindow(Card card, IApiService apiService)
        {
            _apiService = apiService;
            SelectedCard = card;
            DataContext = SelectedCard;
            InitializeComponent();
        }

        private async void Update_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "png files(*.png) |*.png"
            };
            if ((bool)fileDialog.ShowDialog())
            {
                var stream = fileDialog.OpenFile();
                var data = new byte[stream.Length];
                await stream.ReadAsync(data, 0, data.Length);
                SelectedCard.Title = data;

            }
        }

        private async void Accept_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TitleBox.Text))
            {
                SelectedCard.Name = TitleBox.Text;
                await _apiService.FileService.Update(SelectedCard);
                DialogResult = true;
                Close();
                return;
            }

            MessageBox.Show("pls add something");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using CardsWPF.Models;
using CardsWPF.Services.Interfaces;

namespace CardsWPF.ViewModels
{
    public class MainWindowViewModels
    {
        private readonly IApiService _apiService;
        public Card SelectedCard { get; set; }
        public ObservableCollection<Card> Cards { get; set; }

        public void Delete()
        {
            _apiService.FileService.Delete(SelectedCard.Id);
        }
        public  void Add(Card card)
        {
            Cards.Add(card);
        }
        public async void Refresh()
        {
            Cards.Clear();
            List<Card> list = await _apiService.FileService.GetAll();
            list.ForEach(f => Cards.Add(f));
        }
        private async void Init()
        {
           List<Card> list = await _apiService.FileService.GetAll();
           list.ForEach(f => Cards.Add(f));
        }
        public MainWindowViewModels(IApiService apiService)
        {
            _apiService = apiService;
            Cards = new ObservableCollection<Card>();
            Init();
        }

        public void Update(Card updateWindowSelectedCard)
        {
            var oldCard = Cards.First(f => f.Id == updateWindowSelectedCard.Id);
            var indexOf = Cards.IndexOf(oldCard);
            Cards[indexOf] = updateWindowSelectedCard;
        }
    }
}

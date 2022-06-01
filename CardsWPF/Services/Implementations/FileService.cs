using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CardsWPF.Models;
using CardsWPF.Services.Interfaces;
using Newtonsoft.Json;


namespace CardsWPF.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly HttpClient _client;
        private readonly string _url = @"https://localhost:5001/api/Cards/";

        public FileService(HttpClient client)
        {
            _client = client;

        }

        public async Task<List<Card>> GetAll()
        {
            var responseMessage = await _client.GetAsync(_url + "get-all");
            var json = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Card>>(json);

        }

        public Task<Card> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Post(Card card)
        {
            card.Id = Guid.NewGuid();
            var json = JsonConvert.SerializeObject(card);

            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PostAsync(_url + "post", data);

        }

        public async Task Delete(Guid Id)
        {
            var card = new DeleteCard
            {
                Id = Id,
            };
            var json = JsonConvert.SerializeObject(card);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PostAsync(_url + "delete", data);
        }

        public Task Delete(List<Guid> Ids)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Card card)
        {
            var json = JsonConvert.SerializeObject(card);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await _client.PutAsync(_url + "update", data);
        }
    }
}

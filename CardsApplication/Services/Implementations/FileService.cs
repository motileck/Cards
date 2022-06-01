using Cards.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CardDomain;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


namespace Cards.Application.Services.Implementations
{
    public class FileService : IFileService
    {
        private const string FilePath = @"C:\Pictures\";

        public FileService()
        {
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
        }

        public async Task<Card> Get(Guid Id)
        {
            await using var fS = new FileStream(FilePath + $"{Id}.json", FileMode.Open);
            var data = new byte[fS.Length];
            await fS.ReadAsync(data, 0, data.Length);
            var card = JsonConvert.DeserializeObject<Card>(Encoding.UTF8.GetString(data));
            return card;
        }

        public async Task Post(Card card)
        {
            await using var fS = new FileStream(FilePath + $"{card.Id}.json", FileMode.CreateNew);
            var json = JsonConvert.SerializeObject(card);
            var data = Encoding.UTF8.GetBytes(json);
            await fS.WriteAsync(data, 0, data.Length);
        }

        public async Task Update(Card card)
        {
            File.Delete(FilePath + $"{card.Id}.json");
            await using var fS = new FileStream(FilePath + $"{card.Id}.json", FileMode.Create);
            var json = JsonConvert.SerializeObject(card);
            var data = Encoding.UTF8.GetBytes(json);
            await fS.WriteAsync(data, 0, data.Length);
        }

        public void Delete(Guid Id)
        {
            if (File.Exists(FilePath + $"{Id}.json"))
            {
                File.Delete(FilePath + $"{Id}.json");
            }
        }

        public async Task<IEnumerable<Card>> GetAll()
        {
            var pathfiles = Directory.GetFiles(FilePath);
            var files = new List<Card>();
            foreach (var pathfile in pathfiles)
            {
                await using var fileStream = new FileStream(pathfile, FileMode.Open);
                var data = new byte[fileStream.Length];
                await fileStream.ReadAsync(data, 0, data.Length);
                var card = JsonConvert.DeserializeObject<Card>(Encoding.UTF8.GetString(data));
                files.Add(card);
            }

            return files;
        }

        public  void DeleteById(List<Guid> Ids)
        {

            foreach (var id in Ids)
            {
                Delete(id);
            }

        }
    }
}

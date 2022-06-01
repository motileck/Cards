using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsWPF.Models;

namespace CardsWPF.Services.Interfaces
{
    public interface IFileService
    {
        Task<List<Card>> GetAll();
        Task<Card> GetById(Guid id);
        Task Post(Card card);
        Task Delete(Guid Id);
        Task Delete(List<Guid> Ids);
        Task Update(Card card);
    }
}

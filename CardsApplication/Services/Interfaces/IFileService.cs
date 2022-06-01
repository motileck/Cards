using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CardDomain;

namespace Cards.Application.Services.Interfaces
{
    public interface IFileService 
    {
        Task<Card> Get(Guid Id);
        Task Post(Card card);
        Task Update(Card card);
        void Delete(Guid Id);
        Task <IEnumerable<Card>>GetAll();
        void DeleteById(List<Guid> Ids);
    }
}

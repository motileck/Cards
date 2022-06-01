using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsWPF.Models;

namespace CardsWPF.Services.Interfaces
{
    public interface IApiService 
    {
       IFileService FileService { get; set; }


    }
}

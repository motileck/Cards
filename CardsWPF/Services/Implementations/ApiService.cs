using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsWPF.Models;
using CardsWPF.Services.Interfaces;

namespace CardsWPF.Services.Implementations
{
    public class ApiService : IApiService
    {
        public IFileService FileService { get; set; }

        public ApiService(IFileService fileService)
        {
            FileService = fileService;
        }

    }
}

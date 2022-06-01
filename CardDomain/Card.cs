using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardDomain
{
    public class Card 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Title { get; set; }
    }
}

using jodeware2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace jodeware2.Services
{
    public interface IProduktRepository
    {
        bool DoesProduktExist(string id);
        IEnumerable<Produkt> All { get; }
        Produkt Find(string id);
        void Insert(Produkt produkt);
        void Update(Produkt produkt);
        void Delete(string id);
    }
}

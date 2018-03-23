using jodeware2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace jodeware2.Services
{
    public interface IProduktRepository
    {
        bool DoesProduktExist(int id);
        IEnumerable<Produkt> All { get; }
        Produkt Find(int id);
        void Insert(Produkt produkt);
        void Update(Produkt produkt);
        void Delete(int id);
    }
}

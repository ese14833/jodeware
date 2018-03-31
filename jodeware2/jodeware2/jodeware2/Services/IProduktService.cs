using jodeware2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace jodeware2.Services
{
    public interface IProduktService
    {
        bool DoesProduktExist(string id);
        Produkt Find(string id);
        IEnumerable<Produkt> GetData();
        void InsertData(Produkt produkt);
        void UpdateData(Produkt produkt);
        void DeleteData(string id);
    }
}

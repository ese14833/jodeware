using jodeware2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace jodeware2.Services
{
    public interface IProduktService
    {
        bool DoesProduktExist(int id);
        Produkt Find(int id);
        IEnumerable<Produkt> GetData();
        void InsertData(Produkt produkt);
        void UpdateData(Produkt produkt);
        void DeleteData(int id);
    }
}

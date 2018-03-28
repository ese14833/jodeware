using jodeware2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace jodeware2.Data
{
    public interface IRestService
    {
        Task<List<Produkt>> RefreshDataAsync();
        Task SaveProduktAsync(Produkt produkt, bool isNewProdukt);
        Task DeleteProduktAsync(string id); 
    }
}

using jodeware2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace jodeware2.Data
{
    public interface IRestService
    {
        Task<RootObject> RefreshDataAsync();
        Task SaveAsync(Object ob, bool isNewProdukt);
        Task DeleteProduktAsync(string id); 
        Task DeleteKategorieAsync(string id);
        Task DeleteHerstellerAsync(string id);
        Task DeleteRegalAsync(string id);
    }
}

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
        Task<RootObjectKat> RefreshKategorieAsync();
        Task<RootObjectHer> RefreshHerstellerAsync();
        Task<RootObjectReg> RefreshRegalAsync();
        Task SaveAsync(Object ob, bool isNewProdukt);
        Task DeleteProduktAsync(string id); 
        Task DeleteKategorieAsync(string id);
        Task DeleteHerstellerAsync(string id);
        Task DeleteRegalAsync(string id);
        Task DeleteLagerbestandAsync(string id);
        Task DeleteVerkaufAsync(string id);
    }
}

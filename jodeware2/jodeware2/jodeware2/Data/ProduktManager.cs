using jodeware2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace jodeware2.Data
{
    public class ProduktManager
    {
        RestService restService;

        public ProduktManager (RestService service)
        {
            restService = service;
        }

        public Task<List<Produkt>> GetTaskAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync (Produkt produkt, bool isNewProdukt = false)
        {
            return restService.SaveProduktAsync(produkt, isNewProdukt);
        }

        public Task DeleteTaskAsync (Produkt produkt)
        {
            return restService.DeleteProduktAsync(produkt.pro_id);
        }
    }
}

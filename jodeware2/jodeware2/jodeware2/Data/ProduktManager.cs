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

        public Task<RootObject> GetTaskAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync (Object ob, bool isNewProdukt = false)
        {
            return restService.SaveAsync(ob, isNewProdukt);
        }

        public Task DeleteTaskAsync (Object ob)
        {
            if (ob is Produkt)
            {
                Produkt pro = new Produkt();
                pro = (Produkt)ob;
                return restService.DeleteProduktAsync(pro.pro_id);
            }
            if (ob is Kategorie)
            {
                Kategorie kat = new Kategorie();
                kat = (Kategorie)ob;
                return restService.DeleteKategorieAsync(kat.kat_id);
            }
            if (ob is Hersteller)
            {
                Hersteller her = new Hersteller();
                her = (Hersteller)ob;
                return restService.DeleteHerstellerAsync(her.her_id);
            }
            if (ob is Regal)
            {
                Regal regal = new Regal();
                regal = (Regal)ob;
                return restService.DeleteRegalAsync(regal.reg_id);
            }
            if (ob is Lagerbestand)
            {
                Lagerbestand lager = new Lagerbestand();
                lager = (Lagerbestand)ob;
                return restService.DeleteRegalAsync(lager.lag_id);
            }
            if (ob is Verkauf)
            {
                Verkauf verkauf = new Verkauf();
                verkauf = (Verkauf)ob;
                return restService.DeleteRegalAsync(verkauf.ver_id);
            }
            return null;
            //return restService.DeleteProduktAsync(produkt.pro_id);
        }
    }
}

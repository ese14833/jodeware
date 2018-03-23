using jodeware2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace jodeware2.Services
{
    public class ProduktRepository : IProduktRepository
    {
        private List<Produkt> _produktList;

        public ProduktRepository()
        {
            InitializeData();
        }

        public IEnumerable<Produkt> All
        {
            get { return _produktList; }
        }

        public bool DoesProduktExist(int id)
        {
            return _produktList.Any(produkt => produkt.pro_id == id);
        }

        public Produkt Find(int id)
        {
            return _produktList.Where(produkt => produkt.pro_id == id).FirstOrDefault();
        }

        public void Insert(Produkt produkt)
        {
            _produktList.Add(produkt);
        }

        public void Update(Produkt produkt)
        {
            var todoItem = this.Find(produkt.pro_id);
            var index = _produktList.IndexOf(todoItem);
            _produktList.RemoveAt(index);
            _produktList.Insert(index, produkt);
        }

        public void Delete(int id)
        {
            _produktList.Remove(this.Find(id));
        }

        #region Helpers

        private void InitializeData()
        {
            _produktList = new List<Produkt>();

            var produkt1 = new Produkt
            {
                pro_id = 1,
                hersteller_her_id = 24,
                kategorie_kat_id = 2,
                pro_bezeichnung = "Coca Cola",
                pro_bild = new Image { Source = "adden_colored.png" },
                pro_beschreibung = "Soft Drink"
            };

            var produkt2 = new Produkt
            {
                pro_id = 2,
                hersteller_her_id = 15,
                kategorie_kat_id = 3,
                pro_bezeichnung = "Schokokekse",
                pro_bild = new Image { Source = "adden_colored.png" },
                pro_beschreibung = "Kekse"
            };

            var produkt3 = new Produkt
            {
                pro_id = 3,
                hersteller_her_id = 9,
                kategorie_kat_id = 6,
                pro_bezeichnung = "Küchenrolle",
                pro_bild = new Image { Source = "adden_colored.png" },
                pro_beschreibung = "Papier"
            };

            _produktList.Add(produkt1);
            _produktList.Add(produkt2);
            _produktList.Add(produkt3);
        }

        #endregion
    }
}

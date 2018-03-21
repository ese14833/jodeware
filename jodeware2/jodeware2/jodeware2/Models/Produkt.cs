using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace jodeware2.Models
{
    public class Produkt
    {
        public int pro_id { get; set; }
        public int hersteller_her_id { get; set; }
        public int kategorie_kat_id { get; set; }
        public string pro_bezeichnung { get; set; }
        public Image pro_bild { get; set; }
        public string pro_beschreibung { get; set; }

        public string Summary
        {
            get { return String.Format("Id: {0}, Bezeichnung: {1}", pro_id, pro_bezeichnung); }
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}, {3}", pro_id, pro_bezeichnung, pro_beschreibung, hersteller_her_id);
        }
    }

    public class Rootobject
    {
        public Produkt[] produkts { get; set; }
    }
}

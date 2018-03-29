using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace jodeware2.Models
{
    public class Produkt
    {
        [JsonIgnore]
        public string pro_id { get; set; }
        public string pro_bezeichnung { get; set; }
        public object pro_bild { get; set; }
        public object pro_beschreibung { get; set; }
        public string hersteller_her_id { get; set; }
        public string kategorie_kat_id { get; set; }
    }
}

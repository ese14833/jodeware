using System;
using System.Collections.Generic;
using System.Text;

namespace jodeware2.Models
{
    public class Verkauf
    {
        public string ver_id { get; set; }
        public string ver_menge { get; set; }
        public DateTime ver_datum { get; set; }
        public string ver_betrag { get; set; }
        public string produkt_pro_id { get; set; }
    }
}

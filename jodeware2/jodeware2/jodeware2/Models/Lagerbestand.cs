using System;
using System.Collections.Generic;
using System.Text;

namespace jodeware2.Models
{
    public class Lagerbestand
    {
        public string lag_id { get; set; }
        public string lag_preis { get; set; }
        public string lag_akt_menge { get; set; }
        public string lag_res_menge { get; set; }
        public string produkt_pro_id {get; set;}
        public string regal_reg_id { get; set; }
    }
}

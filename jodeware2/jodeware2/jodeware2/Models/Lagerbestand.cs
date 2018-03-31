using System;
using System.Collections.Generic;
using System.Text;

namespace jodeware2.Models
{
    public class Lagerbestand
    {
        public string lag_id { get; set; }
        public decimal lag_preis { get; set; }
        public int lag_akt_menge { get; set; }
        public int lag_res_menge { get; set; }
        public int produkt_pro_id {get; set;}
        public int regal_reg_id { get; set; }
    }
}

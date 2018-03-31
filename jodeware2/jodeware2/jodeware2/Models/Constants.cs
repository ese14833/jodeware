using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace jodeware2.Models
{
    public class Constants
    {
        public static bool isDev = true;

        public static Color BackgroundColor = Color.FromRgb(58, 153, 215);
        public static Color MainTextColor = Color.White;

        // REST: Produkt URLs
        public static string ProduktInsert = "http://test.jodeware.com/api/produkt/insertProdukt.php";
        public static string ProduktRead = "http://test.jodeware.com/api/produkt/readProdukt.php";
        public static string ProduktUpdate = "http://test.jodeware.com/api/produkt/updateProdukt.php";
        public static string ProduktDelete = "http://test.jodeware.com/api/produkt/deleteProdukt.php";

        // REST: Kategorie URLs
        public static string KategorieRead = "http://test.jodeware.com/api/kategorie/readKategorie.php";
        public static string KategorieInsert = "http://test.jodeware.com/api/kategorie/insertKategorie.php";
        public static string KategorieUpdate = "http://test.jodeware.com/api/kategorie/updateKategorie.php";
        public static string KategorieDelete = "http://test.jodeware.com/api/kategorie/deleteKategorie.php";

        // REST: Hersteller URLs
        public static string HerstellerRead = "http://test.jodeware.com/api/hersteller/readHersteller.php";
        public static string HerstellerInsert = "http://test.jodeware.com/api/hersteller/insertHersteller.php";
        public static string HerstellerUpdate = "http://test.jodeware.com/api/hersteller/updateHersteller.php";
        public static string HerstellerDelete = "http://test.jodeware.com/api/hersteller/deleteHersteller.php";


        // REST: Lagerbestand URLs
        public static string LagerbestandRead = "http://test.jodeware.com/api/lagerbestand/readLagerbestand.php";
        public static string LagerbestandInsert = "http://test.jodeware.com/api/lagerbestand/insertLagerbestand.php";
        public static string LagerbestandUpdate = "http://test.jodeware.com/api/lagerbestand/updateLagerbestand.php";
        public static string LagerbestandDelete = "http://test.jodeware.com/api/lagerbestand/deleteLagerbestand.php";

        // REST: Regal URLs
        public static string RegalRead = "http://test.jodeware.com/api/regal/readRegal.php";
        public static string RegalInsert = "http://test.jodeware.com/api/regal/insertRegal.php";
        public static string RegalUpdate = "http://test.jodeware.com/api/regal/updateRegal.php";
        public static string RegalDelete = "http://test.jodeware.com/api/regal/deleteRegal.php";

        // REST: Verkauf URLs
        public static string VerkaufRead = "http://test.jodeware.com/api/verkauf/readVerkauf.php";
        public static string VerkaufInsert = "http://test.jodeware.com/api/verkauf/insertVerkauf.php";
        public static string VerkaufUpdate = "http://test.jodeware.com/api/verkauf/updateVerkauf.php";
        public static string VerkaufDelete = "http://test.jodeware.com/api/verkauf/deleteVerkauf.php";

        // Credentials that are hard coded into the REST service
        public static string Username = "test";
        public static string Password = "test";
    }
}

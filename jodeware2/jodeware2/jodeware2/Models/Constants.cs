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
        public static string ProduktInsert = "https://test.jodeware.com/api/produkt/insertProdukt.php";
        public static string ProduktRead = "https://test.jodeware.com/api/produkt/readProdukt2.php";
        public static string ProduktUpdate = "https://test.jodeware.com/api/produkt/updateProdukt.php";
        public static string ProduktDelete = "https://test.jodeware.com/api/produkt/deleteProdukt.php";

        // REST: Kategorie URLs
        public static string KategorieRead = "https://test.jodeware.com/api/kategorie/readKategorie.php";
        public static string KategorieInsert = "https://test.jodeware.com/api/kategorie/insertKategorie.php";
        public static string KategorieUpdate = "https://test.jodeware.com/api/kategorie/updateKategorie.php";
        public static string KategorieDelete = "https://test.jodeware.com/api/kategorie/deleteKategorie.php";

        // REST: Hersteller URLs
        public static string HerstellerRead = "https://test.jodeware.com/api/hersteller/readHersteller.php";
        public static string HerstellerInsert = "https://test.jodeware.com/api/hersteller/insertHersteller.php";
        public static string HerstellerUpdate = "https://test.jodeware.com/api/hersteller/updateHersteller.php";
        public static string HerstellerDelete = "https://test.jodeware.com/api/hersteller/deleteHersteller.php";


        // REST: Lagerbestand URLs
        public static string LagerbestandRead = "https://test.jodeware.com/api/lagerbestand/readLagerbestand.php";
        public static string LagerbestandInsert = "https://test.jodeware.com/api/lagerbestand/insertLagerbestand.php";
        public static string LagerbestandUpdate = "https://test.jodeware.com/api/lagerbestand/updateLagerbestand.php";
        public static string LagerbestandDelete = "https://test.jodeware.com/api/lagerbestand/deleteLagerbestand.php";

        // REST: Regal URLs
        public static string RegalRead = "https://test.jodeware.com/api/regal/readRegal.php";
        public static string RegalInsert = "https://test.jodeware.com/api/regal/insertRegal.php";
        public static string RegalUpdate = "https://test.jodeware.com/api/regal/updateRegal.php";
        public static string RegalDelete = "https://test.jodeware.com/api/regal/deleteRegal.php";

        // REST: Verkauf URLs
        public static string VerkaufRead = "https://test.jodeware.com/api/verkauf/readVerkauf.php";
        public static string VerkaufInsert = "https://test.jodeware.com/api/verkauf/insertVerkauf.php";
        public static string VerkaufUpdate = "https://test.jodeware.com/api/verkauf/updateVerkauf.php";
        public static string VerkaufDelete = "https://test.jodeware.com/api/verkauf/deleteVerkauf.php";

        // Credentials that are hard coded into the REST service
        public static string Username = "test";
        public static string Password = "test";
    }
}

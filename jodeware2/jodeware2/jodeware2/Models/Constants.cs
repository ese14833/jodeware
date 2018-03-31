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
        // REST Service URLs
        public static string RestInsert = "http://test.jodeware.com/api/produkt/insertProdukt.php";
        public static string RestRead = "http://test.jodeware.com/api/produkt/readProdukt.php";
        public static string RestUpdate = "http://test.jodeware.com/api/produkt/updateProdukt.php";
        public static string RestDelete = "http://test.jodeware.com/api/produkt/deleteProdukt.php";
        // Credentials that are har coded into the REST service
        public static string Username = "test";
        public static string Password = "test";
    }
}

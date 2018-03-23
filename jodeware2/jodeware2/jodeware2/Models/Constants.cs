﻿using System;
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
        // URL of REST service
        public static string RestUrl = "http://developer.xamarin.com:8081/api/produkts/{0}"; //Platzhalter!!!!
        // Credentials that are har coded into the REST service
        public static string Username = "Xamarin";
        public static string Password = "XamarinPassword";
    }
}

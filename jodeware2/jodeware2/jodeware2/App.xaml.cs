using jodeware2.Data;
using jodeware2.LocalDB;
using jodeware2.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace jodeware2
{
	public partial class App : Application
	{
        public static ProduktManager produktManager { get; set; }
		public App ()
		{
			InitializeComponent();

            produktManager = new ProduktManager(new RestService());
			MainPage = new MainPage();
            //MainPage = new HerstellerListPage();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

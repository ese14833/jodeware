using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jodeware2.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Einstellungen : ContentPage
	{
		public Einstellungen ()
		{
			InitializeComponent ();
		}

        public void Btn_bgchanger(object sender, EventArgs e)
        {
            Adden add = new Adden();
            add.BackgroundColor = Color.DarkGray;

            Bericht ber = new Bericht();
            ber.BackgroundColor = Color.DarkGray;

            Bearbeiten edit = new Bearbeiten();
            edit.BackgroundColor = Color.DarkGray;

            HomeScreen start = new HomeScreen();
            start.BackgroundColor = Color.DarkGray;
           


            this.BackgroundColor = Color.DarkGray;

        }

        async void Btn_home(Object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeScreen());
        }

	}
}
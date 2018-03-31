using jodeware2.Models;
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
	public partial class VerkaufAdden : ContentPage
	{
        bool isnewVerkauf;
		public VerkaufAdden ()
		{
			InitializeComponent ();
            Title = "Verkauf hinzufügen";
            isnewVerkauf = true;
		}

        async void hinzufuegen(Object sender, EventArgs e)
        {
            Verkauf verkauf = new Verkauf();
            verkauf.ver_id = e_ver_id.Text;
            verkauf.ver_menge = e_ver_menge.Text;
            verkauf.ver_datum = d_ver_datum.Date;
            verkauf.ver_betrag = e_ver_betrag.Text;
            verkauf.produkt_pro_id = e_ver_pro.Text;

            if (verkauf != null && verkauf.ver_menge != "0" && verkauf.ver_datum != null)
            {
                await App.produktManager.SaveTaskAsync(verkauf, isnewVerkauf);
                await DisplayAlert("Erfolgreich", "Verkauf wurde geaddet.", "Okay");
                await Navigation.PushModalAsync(new HomeScreen());
            }
            else
                await DisplayAlert("Fehler!", "Verkauf konnte nicht geaddet werden.", "Okay");
        }
    }
}
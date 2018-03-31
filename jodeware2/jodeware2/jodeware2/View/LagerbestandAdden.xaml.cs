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
	public partial class LagerbestandAdden : ContentPage
	{
        bool isNewLagerbestand;
		public LagerbestandAdden ()
		{
			InitializeComponent ();
            Title = "Lagerbestand hinzufügen";
            isNewLagerbestand = true;
		}

        async void hinzufuegen(Object sender, EventArgs e)
        {
            Lagerbestand lager = new Lagerbestand();
            lager.lag_preis = e_lager_preis.Text;
            lager.lag_akt_menge = e_lager_akt.Text;
            lager.lag_res_menge = e_lager_res.Text;
            lager.produkt_pro_id = e_lager_pro.Text;
            lager.regal_reg_id = e_lager_reg.Text;

            if (lager != null && lager.lag_preis != "0")
            {
                await App.produktManager.SaveTaskAsync(lager, isNewLagerbestand);
                await DisplayAlert("Erfolgreich", "Lagerbestand wurde geaddet.", "Okay");
                await Navigation.PushModalAsync(new HomeScreen());
            }
            else
                await DisplayAlert("Fehler!", "Lagerbestand konnte nicht geaddet werden.", "Okay");
        }
    }
}
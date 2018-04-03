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
	public partial class LagerbestandAendern : ContentPage
	{
        Lagerbestand lagerbestand = new Lagerbestand();
        bool isNewProdukt;
        public LagerbestandAendern (Lagerbestand lagerbestand)
		{
			InitializeComponent ();
            this.lagerbestand = lagerbestand;
            isNewProdukt = false;
            e_preis.Text = lagerbestand.lag_preis;
            e_akt.Text = lagerbestand.lag_akt_menge;
            e_res.Text = lagerbestand.lag_res_menge;
        }

        async void Speichern_Clicked(object sender, EventArgs e)
        {
            lagerbestand.lag_preis = e_preis.Text;
            lagerbestand.lag_akt_menge = e_akt.Text;
            lagerbestand.lag_res_menge = e_res.Text;

            if (lagerbestand != null && !string.IsNullOrEmpty(lagerbestand.lag_akt_menge))
            {
                await App.produktManager.SaveTaskAsync(lagerbestand, isNewProdukt);
                await DisplayAlert("Erfolgreich", "Lagerbestand wurde geändert.", "Okay");
                await Navigation.PushModalAsync(new HomeScreen());
            }
            else
                await DisplayAlert("Fehler!", "Lagerbestand konnte nicht geändert werden.", "Okay");
        }

        async void Home_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeScreen());
        }
    }
}
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
	public partial class ProduktAendern : ContentPage
	{
        Produkt produkt = new Produkt();
        bool isNewProdukt;
        public ProduktAendern (Produkt produkt)
		{
			InitializeComponent ();
            this.produkt = produkt;
            isNewProdukt = false;
            e_bezeichnung.Text = produkt.pro_bezeichnung;
            e_beschreibung.Text = (String)produkt.pro_beschreibung;
        }

        async void Speichern_Clicked(object sender, EventArgs e)
        {
            produkt.pro_bezeichnung = e_bezeichnung.Text;
            produkt.pro_beschreibung = e_beschreibung.Text;

            if (produkt != null && !string.IsNullOrEmpty(produkt.pro_bezeichnung))
            {
                await App.produktManager.SaveTaskAsync(produkt, isNewProdukt);
                await DisplayAlert("Erfolgreich", "Produkt wurde geändert.", "Okay");
                await Navigation.PushModalAsync(new HomeScreen());
            }
            else
                await DisplayAlert("Fehler!", "Produkt konnte nicht geändert werden.", "Okay");
        }

        async void Home_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeScreen());
        }
    }
}
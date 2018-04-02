using jodeware2.Models;
using Plugin.Media;
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
	public partial class ProduktAdden : ContentPage
	{
        bool isNewProdukt;

		public ProduktAdden ()
		{
			InitializeComponent ();
            Title = "Ware hinzufügen";
            isNewProdukt = true;
        }

        async void hinzufuegen(Object sender, EventArgs e)
        {
            Produkt produkt = new Produkt();
            produkt.pro_bezeichnung = e_bezeichnung.Text;
            produkt.pro_beschreibung = e_beschreibung.Text;
            produkt.hersteller_her_id = e_hersteller.Text;
            produkt.kategorie_kat_id = e_kategorie.Text;

            if (produkt != null && produkt.pro_bezeichnung != null && produkt.pro_bezeichnung != null )
            {
                await App.produktManager.SaveTaskAsync(produkt, isNewProdukt);
                await DisplayAlert("Erfolgreich", "Produkt wurde geaddet.", "Okay");
                await Navigation.PushModalAsync(new HomeScreen());
            }
            else
                await DisplayAlert("Fehler!", "Produkt konnte nicht geaddet werden.", "Okay");
        }

        async void coloredadden(object sender, EventArgs e)
        {
            var imageSender = new Image { Source = "adden_colored.png" };
            imageSender.Aspect = Aspect.AspectFit;
            await Navigation.PushModalAsync(new ProduktAdden());
        }

        async void coloredbericht(object sender, EventArgs e)
        {
            var imageSender = new Image { Source = "statistic_colored.png" };
            imageSender.Aspect = Aspect.AspectFit;
            await Navigation.PushModalAsync(new Bericht());
        }

        async void colorededit(object sender, EventArgs e)
        {
            var imageSender = new Image { Source = "edit_colored.png" };
            imageSender.Aspect = Aspect.AspectFit;
            await Navigation.PushModalAsync(new ProduktBearbeiten());
        }

        async void coloredsettings(object sender, EventArgs e)
        {
            var imageSender = new Image { Source = "settings_colored.png" };
            imageSender.Aspect = Aspect.AspectFit;
            await Navigation.PushModalAsync(new Bericht());
        }


        async void Btn_home(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeScreen());
        }

    }
}
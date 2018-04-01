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
	public partial class KategorieAdden : ContentPage
	{
        bool isNewKategorie;
        public KategorieAdden ()
		{
			InitializeComponent ();
            Title = "Kategorie hinzufügen";
            isNewKategorie = true;
        }

        async void hinzufuegen(Object sender, EventArgs e)
        {
            Kategorie kat = new Kategorie();
            kat.kat_id = e_kat_id.Text;
            kat.kat_bezeichnung = e_kat_bezeichnung.Text;

            if (kat != null && kat.kat_id != null && kat.kat_bezeichnung != null)
            {
                await App.produktManager.SaveTaskAsync(kat, isNewKategorie);
                await DisplayAlert("Erfolgreich", "Kategorie wurde geaddet.", "Okay");
                await Navigation.PushModalAsync(new HomeScreen());
            }
            else
                await DisplayAlert("Fehler!", "Kategorie konnte nicht geaddet werden.", "Okay");
        }

        async void Btn_home(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeScreen());
        }
    }
}
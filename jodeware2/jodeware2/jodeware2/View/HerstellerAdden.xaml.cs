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
	public partial class HerstellerAdden : ContentPage
	{
        bool isNewHersteller;
        public HerstellerAdden ()
		{
            InitializeComponent();
            Title = "Hersteller hinzufügen";
            isNewHersteller = true;
        }

        async void hinzufuegen(Object sender, EventArgs e)
        {
            Hersteller her = new Hersteller();
            her.her_id = e_her_id.Text;
            her.her_bezeichnung = e_her_bezeichnung.Text;

            if (her != null && her.her_id != null && her.her_bezeichnung != null)
            {
                await App.produktManager.SaveTaskAsync(her, isNewHersteller);
                await DisplayAlert("Erfolgreich", "Hersteller wurde geaddet.", "Okay");
                await Navigation.PushModalAsync(new HomeScreen());
            }
            else
                await DisplayAlert("Fehler!", "Hersteller konnte nicht geaddet werden.", "Okay");
        }
    }
}
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
	public partial class RegalAdden : ContentPage
	{
        bool isNewRegal;
        public RegalAdden ()
		{
			InitializeComponent ();
            Title = "Regal hinzufügen";
            isNewRegal = true;
        }

        async void hinzufuegen(Object sender, EventArgs e)
        {
            Regal regal = new Regal();
            regal.reg_id = e_regal_id.Text;
            regal.reg_bezeichnung = e_regal_bezeichnung.Text;

            if (regal != null && regal.reg_id != null && regal.reg_bezeichnung != null)
            {
                await App.produktManager.SaveTaskAsync(regal, isNewRegal);
                await DisplayAlert("Erfolgreich", "Regal wurde geaddet.", "Okay");
                await Navigation.PushModalAsync(new HomeScreen());
            }
            else
                await DisplayAlert("Fehler!", "Regal konnte nicht geaddet werden.", "Okay");
        }

        async void Btn_home(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeScreen());
        }

    }

}
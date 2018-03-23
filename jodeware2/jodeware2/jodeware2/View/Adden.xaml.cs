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
	public partial class Adden : ContentPage
	{
        bool isNewProdukt;

		public Adden ()
		{
			InitializeComponent ();
            isNewProdukt = true;
		}

        async void hinzufuegen(Object sender, EventArgs e)
        {
            var produkt = (Produkt)BindingContext;
            await App.produktManager.SaveTaskAsync(produkt, isNewProdukt);
            await DisplayAlert("Erfolgreich", "Produkt wurde geaddet", "Okay");
            await Navigation.PushModalAsync(new HomeScreen());
        }
	}
}
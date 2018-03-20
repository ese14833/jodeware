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
		public Adden ()
		{
			InitializeComponent ();
		}

        async void hinzufuegen(Object sender, EventArgs e)
        {
            await DisplayAlert("Erfolgreich", "Produkt wurde geaddet", "Okay");
            await Navigation.PushModalAsync(new HomeScreen());
        }
	}
}
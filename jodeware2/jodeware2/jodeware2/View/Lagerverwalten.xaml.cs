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
	public partial class Lagerverwalten : ContentPage
	{
		public Lagerverwalten ()
		{
			InitializeComponent ();
        }

        async void home_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeScreen());
        }

        async void HerstellerAdden_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HerstellerAdden());
        }


        async void KategorieAdden_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new KategorieAdden());
        }

        async void RegalAdden_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegalAdden());
        }

        async void LagerbestandAdden_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LagerbestandAdden());
        }

        async void VerkaufAdden_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new VerkaufAdden());
        }
    }
}
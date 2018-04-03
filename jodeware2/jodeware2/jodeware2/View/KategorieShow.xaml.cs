using jodeware2.Data;
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
	public partial class KategorieShow : ContentPage
	{
        public RestService restService;
        public KategorieShow ()
		{
			InitializeComponent ();
            GetData();
        }

        public async void GetData()
        {
            restService = new RestService();
            RootObjectKat objectKat = new RootObjectKat();
            //ListView kategorieList = new ListView();
            kategorieList.RowHeight = 60;
            objectKat = await restService.RefreshKategorieAsync();
            kategorieList.ItemsSource = objectKat.kategorie;
        }

        async void home_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeScreen());
        }
    }
}
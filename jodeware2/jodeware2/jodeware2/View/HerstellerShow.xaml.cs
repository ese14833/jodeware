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
	public partial class HerstellerShow : ContentPage
	{
        public RestService restService;
        public HerstellerShow ()
		{
			InitializeComponent ();
            GetData();
		}

        public async void GetData()
        {
            restService = new RestService();
            RootObjectHer objectHer = new RootObjectHer();
            //ListView kategorieList = new ListView();
            herstellerList.RowHeight = 60;
            objectHer = await restService.RefreshHerstellerAsync();
            herstellerList.ItemsSource = objectHer.hersteller;
        }

        async void home_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeScreen());
        }
    }
}
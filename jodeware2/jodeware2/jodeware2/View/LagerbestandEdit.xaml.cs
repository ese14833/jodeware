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
	public partial class LagerbestandEdit : ContentPage
	{
        public RestService restService;
        bool isNewProdukt = false;
        private List<Lagerbestand> lagers = null;
        public LagerbestandEdit ()
		{
			InitializeComponent ();
            Title = "Lagerbestand bearbeiten";
            GetData();
        }

        public async void GetData()
        {
            restService = new RestService();
            RootObjectLag rootObject = new RootObjectLag();
            lagerlist.RowHeight = 60;
            rootObject = await restService.RefreshLagerbestandAsync();
            lagerlist.ItemsSource = rootObject.lagerbestand;
            lagers = rootObject.lagerbestand;
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            lagerlist.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                GetData();
            }
            else
            {
                lagerlist.ItemsSource = lagers.Where(i => i.lag_id.Contains(e.NewTextValue));
            }
            lagerlist.EndRefresh();
        }

        async void home_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeScreen());
        }

        async void Update_Clicked(object sender, EventArgs e)
        {
            Lagerbestand lag = (Lagerbestand)lagerlist.SelectedItem;
            //await Navigation.PushModalAsync(new LagerbestandAendern(lag));
        }

        async void delete_Clicked(object sender, EventArgs e)
        {
            Lagerbestand lag = (Lagerbestand)lagerlist.SelectedItem;
            Lagerbestand lager = (from l in lagers
                               where l.lag_id == lag.lag_id
                               select l).FirstOrDefault<Lagerbestand>();
            await App.produktManager.DeleteTaskAsync(lager);
            await Navigation.PushModalAsync(new LagerbestandEdit());
        }


    }
}
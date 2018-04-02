using jodeware2.Data;
using jodeware2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jodeware2.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerkaufAdden : ContentPage
	{
        public RestService restService;

        public List<string> proBezList;
        public List<Produkt> produkts;

        public string proBez;

        bool isnewVerkauf;
		public VerkaufAdden ()
		{
			InitializeComponent ();
            Title = "Verkauf hinzufügen";
            isnewVerkauf = true;
            GetJson();
		}

        async void hinzufuegen(Object sender, EventArgs e)
        {
            Verkauf verkauf = new Verkauf();
            //verkauf.ver_id = e_ver_id.Text;
            verkauf.ver_menge = e_ver_menge.Text;
            verkauf.ver_datum = d_ver_datum.Date;
            verkauf.ver_betrag = e_ver_betrag.Text;
            verkauf.produkt_pro_id = (from p in produkts
                                      where p.pro_bezeichnung == proBez
                                      select p.pro_id).SingleOrDefault();

            if (verkauf != null && verkauf.ver_menge != "0" && verkauf.ver_datum != null)
            {
                await App.produktManager.SaveTaskAsync(verkauf, isnewVerkauf);
                await DisplayAlert("Erfolgreich", "Verkauf wurde geaddet.", "Okay");
                await Navigation.PushModalAsync(new HomeScreen());
            }
            else
                await DisplayAlert("Fehler!", "Verkauf konnte nicht geaddet werden.", "Okay");
        }

        public async void GetJson()
        {
            restService = new RestService();
            RootObject rootObject = new RootObject();

            try
            {
                rootObject = await restService.RefreshDataAsync();
                produkts = rootObject.produkt;
                proBezList = produkts.Select(p => p.pro_bezeichnung).ToList();
                picker_pro.ItemsSource = proBezList;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        async void Btn_home(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeScreen());
        }

        private void picker_pro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picker_pro != null && picker_pro.SelectedIndex <= picker_pro.Items.Count)
            {
                proBez = picker_pro.Items[picker_pro.SelectedIndex];
            }
        }
    }
}
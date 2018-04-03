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
	public partial class LagerbestandAdden : ContentPage
	{
        public Data.RestService restService;

        public List<string> proBezList;
        public List<string> regBezList;

        public List<Produkt> produkts;
        public List<Regal> regals;

        public string proBez;
        public string regBez;

        bool isNewLagerbestand;
		public LagerbestandAdden ()
		{
			InitializeComponent ();
            Title = "Lagerbestand hinzufügen";
            isNewLagerbestand = true;
            GetJson();
		}

        async void hinzufuegen(Object sender, EventArgs e)
        {
            Lagerbestand lager = new Lagerbestand();
            lager.lag_preis = e_lager_preis.Text;
            lager.lag_akt_menge = e_lager_akt.Text;
            lager.lag_res_menge = e_lager_res.Text;
            lager.produkt_pro_id = (from p in produkts
                                    where p.pro_bezeichnung == proBez
                                    select p.pro_id).SingleOrDefault();
            lager.regal_reg_id = (from r in regals
                                  where r.reg_bezeichnung == regBez
                                  select r.reg_id).SingleOrDefault();

            if (lager != null && lager.lag_preis != "0")
            {
                await App.produktManager.SaveTaskAsync(lager, isNewLagerbestand);
                await DisplayAlert("Erfolgreich", "Lagerbestand wurde geaddet.", "Okay");
                await Navigation.PushModalAsync(new HomeScreen());
            }
            else
                await DisplayAlert("Fehler!", "Lagerbestand konnte nicht geaddet werden.", "Okay");
        }

        public async void GetJson()
        {
            restService = new RestService();
            RootObject rootObject = new RootObject();
            RootObjectReg rootObjectReg = new RootObjectReg();

            try
            {
                rootObject = await restService.RefreshDataAsync();
                produkts = rootObject.produkt;
                proBezList = produkts.Select(p => p.pro_bezeichnung).ToList();
                picker_pro.ItemsSource = proBezList;

                rootObjectReg = await restService.RefreshRegalAsync();
                regals = rootObjectReg.regal;
                regBezList = regals.Select(r => r.reg_bezeichnung).ToList();
                picker_reg.ItemsSource = regBezList;

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

        private void picker_reg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picker_reg != null && picker_reg.SelectedIndex <= picker_reg.Items.Count)
            {
                proBez = picker_reg.Items[picker_reg.SelectedIndex];
            }
        }
    }
}
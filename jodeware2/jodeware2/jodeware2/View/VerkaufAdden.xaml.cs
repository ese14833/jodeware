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
        public List<Lagerbestand> lagers;

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
            Lagerbestand lager = new Lagerbestand();
            Verkauf verkauf = new Verkauf();
            int akt, res, ver, checkMenge;

            verkauf.ver_menge = e_ver_menge.Text;
            verkauf.ver_datum = d_ver_datum.Date;
            verkauf.ver_betrag = e_ver_betrag.Text;
            verkauf.produkt_pro_id = (from p in produkts
                                      where p.pro_bezeichnung == proBez
                                      select p.pro_id).SingleOrDefault();

            lager = (from lag in lagers
                     where lag.produkt_pro_id == verkauf.produkt_pro_id
                     select lag).FirstOrDefault<Lagerbestand>();

            if (lager != null)
            {
                akt = 0;
                int.TryParse(lager.lag_akt_menge, out akt);

                res = 0;
                int.TryParse(lager.lag_res_menge, out res);

                ver = 0;
                int.TryParse(verkauf.ver_menge, out ver);

                checkMenge = (akt - res) - ver;

                if (checkMenge >= 0)
                {

                    if (verkauf != null && verkauf.ver_menge != "0" && verkauf.ver_datum != null)
                    {
                        await App.produktManager.SaveTaskAsync(verkauf, isnewVerkauf);
                        await DisplayAlert("Erfolgreich", "Verkauf wurde geaddet.", "Okay");

                        lager.lag_akt_menge = (akt - ver).ToString();
                        await App.produktManager.SaveTaskAsync(lager, false);

                        await Navigation.PushModalAsync(new Lagerverwalten());
                    }
                    else
                        await DisplayAlert("Fehler!", "Verkauf konnte nicht geaddet werden.", "Okay");
                }
                else
                    await DisplayAlert("Fehler!", "Es sind nicht genügend Stück dieses Produkts im Lager vorhanden!.", "Okay");

            }
            else
                await DisplayAlert("Fehler!", "Es sind nicht genügend Stück dieses Produkts im Lager vorhanden!.", "Okay");
        }

        public async void GetJson()
        {
            restService = new RestService();
            RootObject rootObject = new RootObject();
            RootObjectLag objectLag = new RootObjectLag();

            try
            {
                rootObject = await restService.RefreshDataAsync();
                produkts = rootObject.produkt;
                proBezList = produkts.Select(p => p.pro_bezeichnung).ToList();
                picker_pro.ItemsSource = proBezList;

                objectLag = await restService.RefreshLagerbestandAsync();
                lagers = objectLag.lagerbestand;

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

        }
    }
}
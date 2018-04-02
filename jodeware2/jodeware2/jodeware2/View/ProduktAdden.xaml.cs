using jodeware2.Data;
using jodeware2.Models;
using Plugin.Media;
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
	public partial class ProduktAdden : ContentPage
	{
        public RestService restService;

        public List<string> herBezList;
        public List<string> katBezList;

        public List<Hersteller> herstellers;
        public List<Kategorie> kategories;

        public string herstellerBez;
        public string kategorieBez;
        bool isNewProdukt;

		public ProduktAdden ()
		{
			InitializeComponent ();
            Title = "Ware hinzufügen";
            isNewProdukt = true;
            GetJsonLists();
        }

        async void hinzufuegen(Object sender, EventArgs e)
        {
            Produkt produkt = new Produkt();
            produkt.pro_bezeichnung = e_bezeichnung.Text;
            produkt.pro_beschreibung = e_beschreibung.Text;
            produkt.hersteller_her_id = (from h in herstellers
                                         where h.her_bezeichnung == herstellerBez
                                         select h.her_id).SingleOrDefault();
            produkt.kategorie_kat_id = (from k in kategories
                                        where k.kat_bezeichnung == kategorieBez
                                        select k.kat_id).SingleOrDefault();

            if (produkt != null && produkt.pro_bezeichnung != null && produkt.pro_bezeichnung != null )
            {
                await App.produktManager.SaveTaskAsync(produkt, isNewProdukt);
                await DisplayAlert("Erfolgreich", "Produkt wurde geaddet.", "Okay");
                await Navigation.PushModalAsync(new HomeScreen());
            }
            else
                await DisplayAlert("Fehler!", "Produkt konnte nicht geaddet werden.", "Okay");
        }

        public async void GetJsonLists()
        {
            restService = new RestService();
            RootObjectKat rootKat = new RootObjectKat();
            RootObjectHer rootHer = new RootObjectHer();

            try
            {
                rootKat = await restService.RefreshKategorieAsync();
                kategories = rootKat.kategorie;
                katBezList = rootKat.kategorie.Select(k => k.kat_bezeichnung).ToList();
                picker_kat.ItemsSource = katBezList;

                rootHer = await restService.RefreshHerstellerAsync();
                herstellers = rootHer.hersteller;
                herBezList = rootHer.hersteller.Select(h => h.her_bezeichnung).ToList();
                picker_her.ItemsSource = herBezList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        async void coloredadden(object sender, EventArgs e)
        {
            var imageSender = new Image { Source = "adden_colored.png" };
            imageSender.Aspect = Aspect.AspectFit;
            await Navigation.PushModalAsync(new ProduktAdden());
        }

        async void coloredbericht(object sender, EventArgs e)
        {
            var imageSender = new Image { Source = "statistic_colored.png" };
            imageSender.Aspect = Aspect.AspectFit;
            await Navigation.PushModalAsync(new Bericht());
        }

        async void colorededit(object sender, EventArgs e)
        {
            var imageSender = new Image { Source = "edit_colored.png" };
            imageSender.Aspect = Aspect.AspectFit;
            await Navigation.PushModalAsync(new ProduktBearbeiten());
        }

        async void coloredsettings(object sender, EventArgs e)
        {
            var imageSender = new Image { Source = "settings_colored.png" };
            imageSender.Aspect = Aspect.AspectFit;
            await Navigation.PushModalAsync(new Bericht());
        }

        /*async void Btn_kamera(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Keine Kamera gefunden", "Bitte aktivieren Sie Ihren Kamera!", "Okay");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(
                new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                });

            if(file == null)
            {
                return;
            }

            MainImage.S
        }*/




        /* Vorrübergehend */
        async void Btn_kamera(object sender, EventArgs e)
        {
            await DisplayAlert("Foto", "Demnächst kommt die vollständige Funktionalität", "Okay");
        }

        async void Btn_home(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeScreen());
        }

        private void picker_her_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picker_her != null && picker_her.SelectedIndex <= picker_her.Items.Count)
            {
                herstellerBez = picker_her.Items[picker_her.SelectedIndex];
            }
        }

        private void picker_kat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(picker_kat != null && picker_kat.SelectedIndex <= picker_kat.Items.Count)
            {
                kategorieBez = picker_kat.Items[picker_kat.SelectedIndex];
            }
        }
    }
}
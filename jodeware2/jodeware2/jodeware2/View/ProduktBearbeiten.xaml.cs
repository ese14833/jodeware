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
	public partial class ProduktBearbeiten : ContentPage
	{
        public RestService restService;
        bool isNewProdukt = false;
        private List<Produkt> produkts = null;
        public ProduktBearbeiten ()
		{
            InitializeComponent();
            Title = "Ware bearbeiten";
            GetData();
        }

        public async void GetData()
        {
            restService = new RestService();
            RootObject rootObject = new RootObject();
            produktlist.RowHeight = 60;
            rootObject = await restService.RefreshDataAsync();
            produktlist.ItemsSource = rootObject.produkt;
            produkts = rootObject.produkt;
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            produktlist.BeginRefresh();

            try
            {
                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                {
                    GetData();
                }
                else
                {
                    produktlist.ItemsSource = produkts.Where(i => i.pro_bezeichnung.Contains(e.NewTextValue));
                }
                produktlist.EndRefresh();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

        async void home_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeScreen());
        } 

        async void Save_Clicked(object sender, EventArgs e)
        {
            var todoItem = (Produkt)BindingContext;
            await App.produktManager.SaveTaskAsync(todoItem, isNewProdukt);
            await Navigation.PopAsync();
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

        async void Update_Clicked(object sender, EventArgs e)
        {
            Produkt pro = (Produkt)produktlist.SelectedItem;
            if (pro != null)
                await Navigation.PushModalAsync(new ProduktAendern(pro));
            else
                await DisplayAlert("Fehler!", "Kein Produkt ausgewählt!.", "Okay");
        }

        async void delete_Clicked(object sender, EventArgs e)
        {
            Produkt pro = (Produkt)produktlist.SelectedItem;
            if (pro != null)
            {
                Produkt produkt = (from prod in produkts
                                   where prod.pro_id == pro.pro_id
                                   select prod).FirstOrDefault<Produkt>();
                await App.produktManager.DeleteTaskAsync(produkt);
                await Navigation.PushModalAsync(new ProduktBearbeiten());
            }
            else
                await DisplayAlert("Fehler!", "Kein Produkt ausgewählt!.", "Okay");
        }

    }
}
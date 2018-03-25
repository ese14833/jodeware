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
	public partial class Bearbeiten : ContentPage
	{
        bool isNewProdukt = false;
        public Bearbeiten ()
		{
            InitializeComponent();
            Title = "Ware bearbeiten";
            produktlist.ItemsSource = ProduktListeTest.StringListe;

            
        }

        async void home_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeScreen());
        }

        async void delete_Clicked(object sender, EventArgs e)
        {
            var produkt = (Produkt)BindingContext;
            await App.produktManager.DeleteTaskAsync(produkt);
            await Navigation.PopAsync();
        }

        async void save_Clicked(object sender, EventArgs e)
        {
            var produkt = (Produkt)BindingContext;
            await App.produktManager.SaveTaskAsync(produkt, isNewProdukt);
            await Navigation.PopAsync();
        }


        async void coloredadden(object sender, EventArgs e)
        {
            var imageSender = new Image { Source = "adden_colored.png" };
            imageSender.Aspect = Aspect.AspectFit;
            await Navigation.PushModalAsync(new Adden());
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
            await Navigation.PushModalAsync(new Bearbeiten());
        }

        async void coloredsettings(object sender, EventArgs e)
        {
            var imageSender = new Image { Source = "settings_colored.png" };
            imageSender.Aspect = Aspect.AspectFit;
            await Navigation.PushModalAsync(new Bericht());
        }

    }
}
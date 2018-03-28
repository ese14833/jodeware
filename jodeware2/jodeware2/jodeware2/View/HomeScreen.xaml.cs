using RestSharp;
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
    public partial class HomeScreen : ContentPage
    {


        public HomeScreen()
        {

            InitializeComponent();


            Title = "Startseite";


            logo = new Image { Source = "jodewarelogo.png" };

            
            var imageSenderAdden = new Image { Source = "adden_colored.png" };
            imageSenderAdden.IsVisible = true;

            var imageSenderEdit = new Image { Source = "edit_colored.png" };
            imageSenderEdit.IsVisible = true;

            var imageSenderStatistic = new Image { Source = "statistic_colored.png" };
            imageSenderStatistic.IsVisible = true;

            var imageSenderSettings = new Image { Source = "settings_colored.png" };
            imageSenderSettings.IsVisible = true;

            var imageSenderQR = new Image { Source = "qrcode.png" };
            imageSenderSettings.IsVisible = true;


            ScrollView scroll = new ScrollView();
        }

        async void LogOut_Clicked(object sender, EventArgs e)
        {
            Logout();
            await Navigation.PushModalAsync(new LoginPage());
        }

        public void Logout()
        {
            var client = new RestClient("https://jodeware.eu.auth0.com/v2/logout");
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
        }


        async void coloredadden(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Adden());
        }

        async void coloredbericht(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Bericht());
        }

        async void colorededit(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Bearbeiten());
        }

        async void coloredsettings(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new Einstellungen());
        }

        async void coloredqr(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new QRCodeGenerator());
        }
    }
}
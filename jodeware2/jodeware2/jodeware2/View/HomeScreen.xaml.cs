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
            ScrollView scroll = new ScrollView();
        }

        async void AddBtn(object sender, EventArgs e)
        {
            var imageSender = new Image { Source = "adden.png" };
            await Navigation.PushModalAsync(new Adden());
        }

        async void EditBtn(object sender, EventArgs e)
        {
            var imageSender = new Image { Source = "edit.png" };
            await Navigation.PushModalAsync(new Bearbeiten());
        }

        async void BerichtBtn(object sender, EventArgs e)
        {
            var imageSender = new Image { Source = "statistic.png" };
            await Navigation.PushModalAsync(new Bericht());
        }

        async void LogOut(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}
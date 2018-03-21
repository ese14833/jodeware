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
    public partial class Bericht : ContentPage
    {
        public Bericht()
        {
            InitializeComponent();
        }

        async void Button_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeScreen());
        }
    }
}
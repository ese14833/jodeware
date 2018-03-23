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
            var todoItem = (Produkt)BindingContext;
            await App.produktManager.SaveTaskAsync(todoItem, isNewProdukt);
            await Navigation.PopAsync();
        }
    }
}
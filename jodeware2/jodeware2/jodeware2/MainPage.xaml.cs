using jodeware2.View;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace jodeware2
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            CheckConnectivity();
		}

        async void CheckConnectivity()
        {
            var isConnected = CrossConnectivity.Current.IsConnected;

            if(isConnected == true)
            {
                await Navigation.PushModalAsync(new LoginPage());
            }
            else
            {
                ConnectivityTest.Text = "Sie sind nicht mit dem Internet verbunden!";
            }
        }
    }
}
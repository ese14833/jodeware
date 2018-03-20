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
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            var image = new Image { Source = "jodewarelogo.png" };
		}

        async void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(entry_username.Text, entry_password.Text);
            if (user.CheckInformation())
            {
                await Navigation.PushModalAsync(new HomeScreen());
            }
            else
            {
                await DisplayAlert("Login", "Login nicht erfolgreich!", "Okay!");
            }
        }
    }
}
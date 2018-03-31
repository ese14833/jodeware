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
	public partial class Einstellungen : ContentPage
	{
		public Einstellungen ()
		{
			InitializeComponent ();
		}

        public void Btn_bgchanger(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.DarkGray;
        }

        async void Btn_home(Object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeScreen());
        }
	}
}
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
	public partial class ProdEditView : ContentPage
	{
		public ProdEditView ()
		{
			InitializeComponent ();
		}

        async void btn_updaten(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new HomeScreen());
            /* Updaten */
            /* Habe vorrübergehend einen Verlinkung auf die Startseite gemacht um den Fehler zu beheben. Da soll die Update Logik kommen */
            /* oder keine Ahnung wo die Update Logik kommt, du bist der Master bei der Sache. xD */
        }

        async void btn_home(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeScreen());
        }

	}
}
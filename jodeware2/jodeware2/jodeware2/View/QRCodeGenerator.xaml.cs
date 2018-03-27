using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace jodeware2.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QRCodeGenerator : ContentPage
	{
        ZXingBarcodeImageView barcode;

        public QRCodeGenerator ()
		{
			InitializeComponent ();

            barcode = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            barcode.BarcodeOptions.Width = 350;
            barcode.BarcodeOptions.Height = 350;
		}

        async void Btn_home(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeScreen());
        }

    }
}
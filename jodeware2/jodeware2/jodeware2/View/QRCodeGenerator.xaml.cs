using Plugin.Share;
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

            barcode.BarcodeOptions.Width = 300;
            barcode.BarcodeOptions.Height = 300;
            
        }

        async void Btn_home(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeScreen());
        }

        private void Btn_sharelink(object sender, EventArgs e)
        {
            CrossShare.Current.Share(new Plugin.Share.Abstractions.ShareMessage
            {
                Text = "Besuche unsere Webseite",
                Title = "JodeWare",
                Url = "https://jodeware.com"
            });
        }


        private void Btn_visitsite(object sender, EventArgs e)
        {
            CrossShare.Current.OpenBrowser("https://www.jodeware.com");
        }

    }
}
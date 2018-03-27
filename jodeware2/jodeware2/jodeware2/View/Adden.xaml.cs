﻿using jodeware2.Models;
using Plugin.Media;
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
	public partial class Adden : ContentPage
	{
        bool isNewProdukt;


		public Adden ()
		{
			InitializeComponent ();
            Title = "Ware hinzufügen";
            isNewProdukt = true;
        }

        async void hinzufuegen(Object sender, EventArgs e)
        {
            var produkt = (Produkt)BindingContext;
            await App.produktManager.SaveTaskAsync(produkt, isNewProdukt);
            await DisplayAlert("Erfolgreich", "Produkt wurde geaddet", "Okay");
            await Navigation.PushModalAsync(new HomeScreen());
        }

        async void coloredadden(object sender, EventArgs e)
        {
            var imageSender = new Image { Source = "adden_colored.png" };
            imageSender.Aspect = Aspect.AspectFit;
            await Navigation.PushModalAsync(new Adden());
        }

        async void coloredbericht(object sender, EventArgs e)
        {
            var imageSender = new Image { Source = "statistic_colored.png" };
            imageSender.Aspect = Aspect.AspectFit;
            await Navigation.PushModalAsync(new Bericht());
        }

        async void colorededit(object sender, EventArgs e)
        {
            var imageSender = new Image { Source = "edit_colored.png" };
            imageSender.Aspect = Aspect.AspectFit;
            await Navigation.PushModalAsync(new Bearbeiten());
        }

        async void coloredsettings(object sender, EventArgs e)
        {
            var imageSender = new Image { Source = "settings_colored.png" };
            imageSender.Aspect = Aspect.AspectFit;
            await Navigation.PushModalAsync(new Bericht());
        }

        /*async void Btn_kamera(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Keine Kamera gefunden", "Bitte aktivieren Sie Ihren Kamera!", "Okay");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(
                new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                });

            if(file == null)
            {
                return;
            }

            MainImage.S
        }*/




        /* Vorrübergehend */
        async void Btn_kamera(object sender, EventArgs e)
        {
            await DisplayAlert("Foto", "Demnächst kommt die vollständige Funktionalität", "Okay");
        }

    }
}
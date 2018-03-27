using jodeware2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Produkt> products { get; set; }
        public Bericht()
        {
            InitializeComponent();
            products = new ObservableCollection<Produkt>();
            ListView lstView = new ListView();
            lstView.RowHeight = 60;
            this.Title = "Berichte";
            lstView.ItemTemplate = new DataTemplate(typeof(CustomProduktCell));
            products.Add(new Produkt { pro_id = 1, hersteller_her_id = 24, kategorie_kat_id = 2, pro_bezeichnung = "Coca Cola", pro_bild = new Image { Source = "adden_colored.png" }, pro_beschreibung = "Soft Drink"});
            products.Add(new Produkt { pro_id = 2, hersteller_her_id = 35, kategorie_kat_id = 1, pro_bezeichnung = "Fanta", pro_bild = new Image { Source = "adden_colored.png" }, pro_beschreibung = "Soft Drink" });
            products.Add(new Produkt { pro_id = 3, hersteller_her_id = 19, kategorie_kat_id = 7, pro_bezeichnung = "Sprite", pro_bild = new Image { Source = "adden_colored.png" }, pro_beschreibung = "Soft Drink" });
            lstView.ItemsSource = products;
        }

        async void Menu_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomeScreen());
        }

        private void Gestern_Clicked(object sender, EventArgs e)
        {

        }

        private void Woche_Clicked(object sender, EventArgs e)
        {

        }

        private void Monat_Clicked(object sender, EventArgs e)
        {

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

    }
    public class CustomProduktCell : ViewCell
    {
        public CustomProduktCell()
        {
            //instantiate each of our views
            var pro_bildI = new Image();
            var pro_idLabel = new Label();
            var hersteller_her_idLabel = new Label();
            var kategorie_kat_idLabel = new Label();
            var pro_bezeichnungLabel = new Label();
            var pro_beschreibungLabel = new Label();
            var verticaLayout = new StackLayout();
            var horizontalLayout = new StackLayout() { BackgroundColor = Color.Olive };

            //set bindings
            pro_idLabel.SetBinding(Label.TextProperty, new Binding("pro_id"));
            hersteller_her_idLabel.SetBinding(Label.TextProperty, new Binding("hersteller_her_id"));
            kategorie_kat_idLabel.SetBinding(Label.TextProperty, new Binding("kategorie_kat_id"));
            pro_bezeichnungLabel.SetBinding(Label.TextProperty, new Binding("pro_bezeichnung"));
            pro_beschreibungLabel.SetBinding(Label.TextProperty, new Binding("pro_beschreibung"));
            pro_bildI.SetBinding(Image.SourceProperty, new Binding("pro_bild"));

            //Set properties for desired design
            horizontalLayout.Orientation = StackOrientation.Horizontal;
            horizontalLayout.HorizontalOptions = LayoutOptions.Fill;
            pro_bildI.HorizontalOptions = LayoutOptions.End;
            pro_idLabel.FontSize = 24;

            //add views to the view hierarchy
            verticaLayout.Children.Add(pro_idLabel);
            verticaLayout.Children.Add(hersteller_her_idLabel);
            verticaLayout.Children.Add(kategorie_kat_idLabel);
            verticaLayout.Children.Add(pro_bezeichnungLabel);
            verticaLayout.Children.Add(pro_beschreibungLabel);
            horizontalLayout.Children.Add(verticaLayout);
            horizontalLayout.Children.Add(pro_bildI);

            // add to parent view
            View = horizontalLayout;
        }
    }
}
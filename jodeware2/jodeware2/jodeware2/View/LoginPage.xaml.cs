﻿using jodeware2.Models;
using Newtonsoft.Json;
using RestSharp;
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

            Title = "Anmelden";

            var image = new Image { Source = "jodewarelogo.png" };

            Anmelden_Text.FontSize = 24;
            Anmelden_Text.Text = "Anmelden";
            Anmelden_Text.FontAttributes = FontAttributes.Bold;


		}

        #pragma warning disable 1998
        async void SignInProcedure(object sender, EventArgs e)
        {
            Login(entry_username.Text, entry_password.Text);
        }
        #pragma warning restore 1998

        public void Login(string username, string password)
        {
            var client = new RestClient("https://jodeware.eu.auth0.com/oauth/token");
            var request = new RestRequest(Method.POST);

            request.AddParameter("grant_type", "password");
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            request.AddParameter("client_id", "2qK8aSMyOtzidVPXJHSMf1Aj5Ml-V9zB");
            request.AddParameter("client_secret", "QNYxADHBbfi91QBQs3hc6DzEJ0-n4XzJ63eGqA--GZVapyhWPBMEjD1zhil_RMsP");
            request.AddParameter("scope", "openid");


            IRestResponse response = client.Execute(request);

            LoginToken token = JsonConvert.DeserializeObject<LoginToken>(response.Content);

            if (token.id_token != null)
            {
                Application.Current.Properties["id_token"] = token.id_token;
                Application.Current.Properties["access_token"] = token.access_token;
                GetUserData(token.id_token);
            }
            else
            {
                DisplayAlert("Oh No!", "It's seems that you have entered an incorrect email or password. Please try again.", "OK");
            };
        }

        public void GetUserData(string token)
        {
            var client = new RestClient("https://jodeware.eu.auth0.com/api/v2/");
            var request = new RestRequest("tokeninfo", Method.GET);
            request.AddParameter("id_token", token);


            IRestResponse response = client.Execute(request);

            User user = JsonConvert.DeserializeObject<User>(response.Content);

            Application.Current.Properties["email"] = user.email;
            Application.Current.Properties["picture"] = user.picture;

            Navigation.PushModalAsync(new HomeScreen());
        }

        public class LoginToken
        {
            public string id_token { get; set; }
            public string access_token { get; set; }
            public string token_type { get; set; }
        }

        public class User
        {
            public string name { get; set; }
            public string picture { get; set; }
            public string email { get; set; }
        }

    }
    
}
﻿using jodeware2.Models;
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
		}

        void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(entry_username.Text, entry_password.Text);
            if (user.CheckInformation())
            {
                DisplayAlert("Login", "Login erfolgreich", "Okay!");
            }
            else
            {
                DisplayAlert("Login", "Login nicht erfolgreich!", "Okay!");
            }
        }
        }



}
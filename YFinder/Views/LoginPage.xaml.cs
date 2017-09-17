using System;
using System.Collections.Generic;

using Xamarin.Forms;
using YFinder.Views;

namespace YFinder
{
	public partial class LoginPage : ContentPage
	{

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new UserPage());
        }

        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
			label.Text = e.NewTextValue;
		}

        public LoginPage()
		{
			InitializeComponent();
        }
	}
}
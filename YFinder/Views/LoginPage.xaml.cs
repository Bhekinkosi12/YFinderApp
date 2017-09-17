using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace YFinder
{
	public partial class LoginPage : ContentPage
	{
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new FavoritePage());
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
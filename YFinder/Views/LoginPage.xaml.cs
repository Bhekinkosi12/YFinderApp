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

        public LoginPage()
		{
			InitializeComponent();
        }
	}
}
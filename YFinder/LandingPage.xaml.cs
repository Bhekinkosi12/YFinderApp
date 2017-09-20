using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace YFinder.Views
{
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        async void RouteToLoginPage(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }

		async void RouteToRegisterPage(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new RegisterPage());
		}
    }
}
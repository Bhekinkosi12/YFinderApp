using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace YFinder
{
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            InitializeComponent();
        }

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new LoginPage());
		}
    }
}

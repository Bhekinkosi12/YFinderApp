using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace YFinder
{
	public partial class LoginPage : ContentPage
	{
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
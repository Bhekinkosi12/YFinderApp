using System;
using System.Collections.Generic;
using YFinder.Models;
using YFinder.Views;
using Xamarin.Forms;

namespace YFinder
{
	public partial class UserProfilePage : ContentPage
	{
        public UserProfilePage()
        {
            BindingContext = StaticVariables.activeUser ?? throw new ArgumentNullException();

            var imageSource = ImageSource.FromResource("YFinder.iOS.Resources.letterY.png");

			InitializeComponent();
		}
	}
}
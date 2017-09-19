using System;
using System.Collections.Generic;
using YFinder.Models;
using Xamarin.Forms;

namespace YFinder.Views
{
	public partial class UserProfilePage : ContentPage
	{
        public UserProfilePage(User user)
        {
            BindingContext = user ?? throw new ArgumentNullException();

			InitializeComponent();
		}
	}
}

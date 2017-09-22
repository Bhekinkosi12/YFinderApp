using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace YFinder.Views
{
    public partial class EditProfilePage : ContentPage
    {
        public EditProfilePage()
        {
            BindingContext = StaticVariables.activeUser ?? throw new ArgumentNullException();

            InitializeComponent();
        }
    }
}
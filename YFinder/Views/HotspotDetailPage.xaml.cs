using System;
using System.Collections.Generic;

using Xamarin.Forms;
using YFinder.Models;
using YFinder.Views;

namespace YFinder
{
    public partial class HotspotDetailPage : ContentPage
    {
        async void ClearDetail(object sender, System.EventArgs e)
        {
           await Navigation.PopModalAsync();
        }

        public HotspotDetailPage(Hotspot hotspot)
        {
            InitializeComponent();
        }
    }
}

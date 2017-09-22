using System;
using System.Collections.Generic;
using System.Net;
using Xamarin.Forms;
using YFinder.Models;
using YFinder.Views;

namespace YFinder
{

    public partial class HotspotDetailPage : ContentPage
    {
		private Hotspot _hotspotPassed = new Hotspot();

		public HotspotDetailPage(Hotspot hotspot)
		{
			InitializeComponent();
			BindingContext = hotspot;
            _hotspotPassed = hotspot;
		}

        async void ClearDetail(object sender, System.EventArgs e)
        {
           await Navigation.PopModalAsync();
        }

		async void TakeMeThere(object sender, System.EventArgs e)
		{
			Device.OpenUri(
                new Uri(string.Format("http://maps.apple.com/?q={0}", WebUtility.UrlEncode(_hotspotPassed.Latitude + " " + _hotspotPassed.Longitude))));
		}
		
    }
}
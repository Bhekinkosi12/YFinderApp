using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using YFinder.Models;
using YFinder.Views;
using System.Collections.ObjectModel;

namespace YFinder
{

    public partial class HotspotDetailPage : ContentPage
    {
		private Hotspot _hotspotPassed = new Hotspot();
        private string UrlR = StaticVariables.YFinderApiRootUrl + "/api/rating";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<Rating> _ratings;

		public HotspotDetailPage(Hotspot hotspot)
		{
			InitializeComponent();
            BindingContext = hotspot;
            _hotspotPassed = hotspot;
		}

        protected override async void OnAppearing()
        {
			var content = await _client.GetStringAsync(UrlR);
			var ratings = JsonConvert.DeserializeObject<List<Rating>>(content);
            var matchingRatings = ratings.Where(r => r.HotspotId == _hotspotPassed.HotspotId);

			_ratings = new ObservableCollection<Rating>(matchingRatings);
			ratingsListView.ItemsSource = _ratings;

			base.OnAppearing();
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
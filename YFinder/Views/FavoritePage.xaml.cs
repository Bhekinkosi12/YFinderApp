using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;
using YFinder.Models;

namespace YFinder.Views
{
    public partial class FavoritePage : ContentPage
    {
        private string UrlR = StaticVariables.YFinderApiRootUrl + "/api/rating";
        private string UrlH = StaticVariables.YFinderApiRootUrl + "/api/hotspot";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<Rating> _ratings;

        public FavoritePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(UrlR);
            var content2 = await _client.GetStringAsync(UrlH);
            var ratings = JsonConvert.DeserializeObject<List<Rating>>(content);
            var hotspots = JsonConvert.DeserializeObject<List<Hotspot>>(content2);

            foreach (Rating rating in ratings)
            {
                rating.Hotspot = hotspots.First(h => h.HotspotId == rating.HotspotId);
            }

            _ratings = new ObservableCollection<Rating>(ratings);
            ratingsListView.ItemsSource = _ratings;

            base.OnAppearing();
        }

        async void OnDelete(object sender, System.EventArgs e)
        {
            var rating = (sender as MenuItem).CommandParameter as Rating;
            await _client.DeleteAsync(UrlR + "/" + rating.RatingId);
            _ratings.Remove(rating);
        }

    }
}

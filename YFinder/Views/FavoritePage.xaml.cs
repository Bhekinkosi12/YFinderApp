using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;
using YFinder.Models;

namespace YFinder.Views
{
    public partial class FavoritePage : ContentPage
    {
        private string Url = StaticVariables.YFinderApiRootUrl + "/api/rating";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<Rating> _ratings;

        public FavoritePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            var ratings = JsonConvert.DeserializeObject<List<Rating>>(content);

            _ratings = new ObservableCollection<Rating>(ratings);
            ratingsListView.ItemsSource = _ratings;

            base.OnAppearing();
        }

        async void OnDelete(object sender, System.EventArgs e)
        {
            var rating = (sender as MenuItem).CommandParameter as Rating;
            await _client.DeleteAsync(Url + "/" + rating.RatingId);
            _ratings.Remove(rating);
        }

    }
}

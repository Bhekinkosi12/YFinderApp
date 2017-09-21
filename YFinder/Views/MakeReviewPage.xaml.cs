using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CoreLocation;
using MapKit;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using YFinder.Models;
using YFinder.Views;

namespace YFinder
{
	public partial class MakeReviewPage : ContentPage
	{
		private string UrlR = StaticVariables.YFinderApiRootUrl + "/api/rating";
        private string UrlH = StaticVariables.YFinderApiRootUrl + "/api/hotspot";
		private HttpClient _client = new HttpClient();

        public MakeReviewPage()
        {
            InitializeComponent();
            BindingContext = new NewRating();
        }

        async void MakeNewReview(object sender, System.EventArgs e)
        {
            var hotspot = new NewHotspot(); // new hotspot to be added if doesn't yet exist in db
            var rating = (NewRating)BindingContext; // binding context from page to create review

			CLLocationManager locationManager = new CLLocationManager();
			locationManager.RequestWhenInUseAuthorization();

			var latitude = locationManager.Location.Coordinate.Latitude;
			var longitude = locationManager.Location.Coordinate.Longitude;

            string HotspotName = hotspotName.Text;

			var content = await _client.GetStringAsync(UrlH);
            var hotspots = JsonConvert.DeserializeObject<List<Hotspot>>(content);

			foreach (var h in hotspots)
			{
				if (h.Title == HotspotName)
				{
                    rating.HotspotId = h.HotspotId;
                    rating.Public = 1;
                    rating.Score = 4;
                    rating.Speed = (float)6.23;
					var content3 = JsonConvert.SerializeObject(rating);
					HttpResponseMessage response1 = await _client.PostAsync(UrlR, new StringContent(content3, Encoding.UTF8, "application/json"));
					response1.EnsureSuccessStatusCode();
					string responseBody1 = await response1.Content.ReadAsStringAsync();
                    await Navigation.PushAsync(new UserProfilePage());
                    break;
                } 
            }

			var hotspotNew = new NewHotspot();
			hotspotNew.Title = HotspotName;
			hotspotNew.Latitude = latitude;
			hotspotNew.Longitude = longitude;
			var content2 = JsonConvert.SerializeObject(hotspot);
			HttpResponseMessage response = await _client.PostAsync(UrlH, new StringContent(content2, Encoding.UTF8, "application/json"));
			response.EnsureSuccessStatusCode();
			string responseBody = await response.Content.ReadAsStringAsync();
			var WantThisToBeHotspotId = JsonConvert.DeserializeObject<Hotspot>(responseBody);
			
        }

  //      async void PostNewRating()
  //      {
		//	var content3 = JsonConvert.SerializeObject(rating);
		//	HttpResponseMessage response = await _client.PostAsync(UrlR, new StringContent(content3, Encoding.UTF8, "application/json"));
		//	response.EnsureSuccessStatusCode();
  //          string responseBody = await response.Content.ReadAsStringAsync();
		//}



    }
}

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
        }

        async void MakeNewReview(object sender, System.EventArgs e)
        {
			CLLocationManager locationManager = new CLLocationManager();
			locationManager.RequestWhenInUseAuthorization();

			var latitude = locationManager.Location.Coordinate.Latitude;
			var longitude = locationManager.Location.Coordinate.Longitude;

            int hotspotIdForRating = 0;

			var content = await _client.GetStringAsync(UrlH);
            var hotspots = JsonConvert.DeserializeObject<List<Hotspot>>(content);

			foreach (var hotspot in hotspots)
			{
				if (hotspot.Title == hotspotName.Text)
				{
                    hotspotIdForRating = hotspot.HotspotId;
                } else {
                    var hotspotNew = new NewHotspot();
                    hotspotNew.Title = hotspotName.Text;
                    hotspotNew.Latitude = latitude;
                    hotspotNew.Longitude = longitude;
					// get the new hotspot's ID back from object
					// then post below the rating with that hotspot id attached to it.
                }
            }

            // set rating values here before posting

        }
    }
}

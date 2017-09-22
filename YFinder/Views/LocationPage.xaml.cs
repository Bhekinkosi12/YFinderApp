using System;
using System.Collections.Generic;
using System.Net.Http;
using CoreLocation;
using MapKit;
using Newtonsoft.Json;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using YFinder.Models;

namespace YFinder
{
	public partial class LocationPage : ContentPage
	{
        void HandleEventHandler(object sender, EventArgs e)
        {

        }

        private string UrlH = StaticVariables.YFinderApiRootUrl + "/api/hotspot";
		private HttpClient _client = new HttpClient();

		public LocationPage()
		{
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(UrlH);
            var hotspots = JsonConvert.DeserializeObject<List<Hotspot>>(content);

			// requesting device permissions for location
			CLLocationManager locationManager = new CLLocationManager();
			locationManager.RequestWhenInUseAuthorization();
			
			// getting device coordinates
			var latitude = locationManager.Location.Coordinate.Latitude;
			var longitude = locationManager.Location.Coordinate.Longitude;
			
			// initiate map object using device coordinates
			var map = new Map(
				MapSpan.FromCenterAndRadius(
					new Position(latitude, longitude), Distance.FromMiles(0.3)))
			{
				IsShowingUser = true,
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			
			// slider for zooming
			var slider = new Slider(1, 18, 1);
			slider.ValueChanged += (sender, e) => {
				var zoomLevel = e.NewValue; // between 1 and 18
				var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
				map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
			};

            // pins for each hotspot
            foreach (Hotspot hotspot in hotspots)
            {
                var position = new Position(hotspot.Latitude, hotspot.Longitude);
                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = position,
                    Label = hotspot.Title,
                };
				pin.Clicked += (object sender, EventArgs e) =>
				{
					Navigation.PushModalAsync(new ReviewDetailPage(hotspot));
				};

                map.Pins.Add(pin);
            }
			
			// adding all of the above to the view stack
			var stack = new StackLayout { Spacing = 0 };
			stack.Children.Add(map);
			stack.Children.Add(slider);
			Content = stack;
		}

	}
}
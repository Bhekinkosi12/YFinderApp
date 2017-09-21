using System;
using System.Collections.Generic;
using CoreLocation;
using MapKit;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace YFinder.Views
{
	public partial class LocationPage : ContentPage
	{
		public LocationPage()
		{
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
			var position = new Position(36.1177254, -86.74888650000003);
			var pin = new Pin
			{
				Type = PinType.Place,
				Position = position,
				Label = "Red Bicycle",
				Address = "something about red bike"
			};
			map.Pins.Add(pin);

            // adding all of the above to the view stack
			var stack = new StackLayout { Spacing = 0 };
			stack.Children.Add(map);
            stack.Children.Add(slider);
			Content = stack;

		}
	}
}
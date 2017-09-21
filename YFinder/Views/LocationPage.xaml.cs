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

            var latitude = locationManager.Location.Coordinate.Latitude;
            var longitude = locationManager.Location.Coordinate.Longitude;

			var map = new Map(
			MapSpan.FromCenterAndRadius(
                    new Position(latitude, longitude), Distance.FromMiles(0.3)))
			{
				IsShowingUser = true,
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

            var slider = new Slider(1, 18, 1);
            slider.ValueChanged += (sender, e) => {
                var zoomLevel = 13; // between 1 and 18
                slider.Value = 13;
                var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
                map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
            };

			var stack = new StackLayout { Spacing = 0 };
			stack.Children.Add(map);
            stack.Children.Add(slider);
			Content = stack;

		}
	}
}
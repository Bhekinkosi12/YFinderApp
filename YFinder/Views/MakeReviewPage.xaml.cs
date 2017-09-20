using System;
using System.Collections.Generic;
using CoreLocation;
using MapKit;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace YFinder.Views
{
	public partial class MakeReviewPage : ContentPage
	{
		public MakeReviewPage()
		{
			CLLocationManager locationManager = new CLLocationManager();
			locationManager.RequestWhenInUseAuthorization();

			var latitude = locationManager.Location.Coordinate.Latitude;
			var longitude = locationManager.Location.Coordinate.Longitude;

		}
	}
}
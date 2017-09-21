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
		private string Url = StaticVariables.YFinderApiRootUrl + "/api";
		private HttpClient _client = new HttpClient();

		public MakeReviewPage()
		{
            InitializeComponent();

			CLLocationManager locationManager = new CLLocationManager();
			locationManager.RequestWhenInUseAuthorization();

			var latitude = locationManager.Location.Coordinate.Latitude;
			var longitude = locationManager.Location.Coordinate.Longitude;



			// get all hotspots
			// for each hotspot, is there one matching the name given?
			// if yes then add that hotspot's id to the rating
			// if no then create a hotspot with the user's coodinates
			// get the new hotspot's ID back from object
			// then send the rating with that hotspot id attached to it.

		}
	}
}
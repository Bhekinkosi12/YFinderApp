using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using YFinder.Models;

namespace YFinder
{
	public partial class UserPage : ContentPage
	{
		private const string Url = "http://localhost:5000/api/user";
		private HttpClient _client = new HttpClient();
		private ObservableCollection<User> _users;

        public UserPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			var content = await _client.GetStringAsync(Url);
			var users = JsonConvert.DeserializeObject<List<User>>(content);

			_users = new ObservableCollection<User>(users);
			usersListView.ItemsSource = _users;

			base.OnAppearing();
		}

		async void OnAdd(object sender, System.EventArgs e)
		{
            var user = new User 
            {
                bio = "coolest example ever",
                email = "xample@example.com",
                fullName = "Xavier Ample",
                host = 0,userName = "Xample",
                zip = 37208,
                favorite = null
            };

            var content = JsonConvert.SerializeObject(user);
            await _client.PostAsync(Url, new StringContent(content));

            OnAppearing();

		}

		async void OnUpdate(object sender, System.EventArgs e)
		{
			var user = _users[0];
            user.userName += " UPDATED";

			var content = JsonConvert.SerializeObject(user);
            await _client.PutAsync(Url, new StringContent(content));
		}

		async void OnDelete(object sender, System.EventArgs e)
		{
			var user = _users[0];

            await _client.DeleteAsync(Url + "/" + user.userId);

			_users.Remove(user);
		}
	}
}


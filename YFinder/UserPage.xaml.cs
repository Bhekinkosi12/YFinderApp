using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;
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
            var user = new NewUser 
            {
                bio = "coolest example ever",
                email = "xample@example.com",
                fullName = "Xavier Ample3333",
                host = 0,
                userName = "Xample333",
                zip = 37208,
                favorite = null
            };

            var content = JsonConvert.SerializeObject(user);
			await _client.PostAsync(Url, new StringContent(content, Encoding.UTF8,"application/json"));
            OnAppearing();

		}

		async void OnUpdate(object sender, System.EventArgs e)
		{
			var user = (sender as MenuItem).CommandParameter as User;
            user.userName += " UPDATED";
			var content = JsonConvert.SerializeObject(user);
			await _client.PutAsync(Url + "/" + user.userId, new StringContent(content, Encoding.UTF8, "application/json"));
            OnAppearing();
		}

		async void OnDelete(object sender, System.EventArgs e)
		{
			var user = (sender as MenuItem).CommandParameter as User;
            await _client.DeleteAsync(Url + "/" + user.userId);
            _users.Remove(user);
		}

	}
}
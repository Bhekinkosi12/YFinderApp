using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace YFinder
{
	public class Post
	{
		public int userId { get; set; }
		public object bio { get; set; }
		public string email { get; set; }
		public string fullName { get; set; }
		public int host { get; set; }
		public string userName { get; set; }
		public int zip { get; set; }
		public object favorite { get; set; }
	}

	public partial class UserPage : ContentPage
	{
		private const string Url = "http://localhost:5000/api/user";
		private HttpClient _client = new HttpClient();
		private ObservableCollection<Post> _posts;

        public UserPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{

			var content = await _client.GetStringAsync(Url);
			var posts = JsonConvert.DeserializeObject<List<Post>>(content);

			_posts = new ObservableCollection<Post>(posts);
			postsListView.ItemsSource = _posts;

			base.OnAppearing();
		}

		async void OnAdd(object sender, System.EventArgs e)
		{
            var post = new Post { userName = "UserTest " + DateTime.Now.Ticks };

			var content = JsonConvert.SerializeObject(post);
			await _client.PostAsync(Url, new StringContent(content));

			_posts.Insert(0, post);
		}

		async void OnUpdate(object sender, System.EventArgs e)
		{
			var post = _posts[0];
            post.userName += " UPDATED";

			var content = JsonConvert.SerializeObject(post);
            await _client.PutAsync(Url + "/" + post.userId, new StringContent(content));
		}

		async void OnDelete(object sender, System.EventArgs e)
		{
			var post = _posts[0];

            await _client.DeleteAsync(Url + "/" + post.userId);

			_posts.Remove(post);
		}
	}
}


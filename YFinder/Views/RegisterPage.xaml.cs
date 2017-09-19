using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;
using YFinder.Models;

namespace YFinder.Views
{
    public partial class RegisterPage : ContentPage
    {

        private string Url = StaticVariables.YFinderApiRootUrl + "/api/user";
        private HttpClient _client = new HttpClient();

		public RegisterPage()
		{
			InitializeComponent();
		}

        async void OnAdd(object sender, System.EventArgs e)
        {
            var user = new NewUser
            {
                bio = bio.Text,
                email = email.Text,
                fullName = fullName.Text,
                host = 0,
                userName = userName.Text,
                zip = zip.Text,
                favorite = null
            };

            var content = JsonConvert.SerializeObject(user);
            await _client.PostAsync(Url, new StringContent(content, Encoding.UTF8, "application/json"));

            //var content2 = await _client.GetStringAsync(Url);
            //var users = JsonConvert.DeserializeObject<List<User>>(content2);

            var page = new UserPage();   // temp

            //await Navigation.PushAsync(page);
        }
	}
}
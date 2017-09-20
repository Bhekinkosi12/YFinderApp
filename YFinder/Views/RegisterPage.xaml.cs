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
		    BindingContext = new NewUser();
        }

        async void OnAdd(object sender, System.EventArgs e)
        {
            var user = (NewUser)BindingContext;

            var content = JsonConvert.SerializeObject(user);
            HttpResponseMessage response = await _client.PostAsync(Url, new StringContent(content, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var newUser = JsonConvert.DeserializeObject<User>(responseBody);

            await Navigation.PushModalAsync(new MasterPage());
        }
	}
}g
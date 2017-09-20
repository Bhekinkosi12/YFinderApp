using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;
using YFinder.Models;
using YFinder.Views;

namespace YFinder
{
	public partial class LoginPage : ContentPage
	{
        private string Url = StaticVariables.YFinderApiRootUrl + "/api/user";
        private HttpClient _client = new HttpClient();

		public LoginPage()
		{
			InitializeComponent();
		}

        async void LogThisUserIn(object sender, System.EventArgs e)
        {
            var content = await _client.GetStringAsync(Url);
            var users = JsonConvert.DeserializeObject<List<User>>(content);
            var userToLogIn = new User();
            var entry = userNameInput.Text;

            foreach (var user in users)
            {
                if (user.userName == entry)
                {
                    userToLogIn = user;
                    StaticVariables.setActiveUser(userToLogIn);
                    await Navigation.PushModalAsync(new MasterPage());
                }
            }

			if (userToLogIn.userName == "") {
				await DisplayAlert ("Oops!", "Looks like that username isn't recognized", "OK");   
            } 
        }

        async void BackToLanding(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new LandingPage());
        }

	}
}
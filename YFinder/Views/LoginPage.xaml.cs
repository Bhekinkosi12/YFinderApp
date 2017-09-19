using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;
using YFinder.Models;

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

            foreach (var user in users)
            {
                if (user.userName == "deeveloper")
                {
                    var userToLogIn = user;
                    await Navigation.PushModalAsync(new UserProfilePage(userToLogIn));
                }
            }
        }
	}
}
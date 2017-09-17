using System; using System.Collections.Generic; using System.Collections.ObjectModel; using System.Net.Http;
using Newtonsoft.Json; using Xamarin.Forms; //using YFinder.Models;  namespace YFinder.Views {
    public class User
    {
    	public int UserId { get; set; }
    	public string Bio { get; set; }
    	public string Email { get; set; }
    	public string FullName { get; set; }
    	public int Host { get; set; } // int as bool
    	public string UserName { get; set; }
    	public int Zip { get; set; }
    	//public virtual ICollection<Favorite> Favorite { get; set; }
    }      public partial class UserPage : ContentPage     {       private const string Url = "http://localhost:5000/api/user";       private HttpClient _client = new HttpClient();       private ObservableCollection<User> _users;          public UserPage()         {             InitializeComponent();         }          protected override async void OnAppearing()         {              var content = await _client.GetStringAsync(Url);             var users = JsonConvert.DeserializeObject<List<User>>(content);              _users = new ObservableCollection<User>(users);             usersListView.ItemsSource = _users;              base.OnAppearing();         }     }   } 
using System;
using System.Collections.Generic;
using YFinder.ViewModels;
using Xamarin.Forms;
using YFinder.Views;
using YFinder;

namespace YFinder.Views
{
	public partial class NavBarPage : ContentPage
	{

		public ListView NavBarList { get { return navbarlist; } }

		public NavBarPage()
		{
			InitializeComponent();
			Title = "Menu";

			var NavBarItems = new List<NavBarItem>
			{
				new NavBarItem
				{
					Title = "My Favorites",
					IconSrc = "list.png",
					TargetType = typeof(FavoritePage)
				},
				new NavBarItem
				{
					Title = "All Users",
					IconSrc = "allUsers.png",
					TargetType = typeof(UserPage)
				},
				new NavBarItem
				{
					Title = "Leave New Review",
					IconSrc = "allUsers.png",
					TargetType = typeof(MakeReviewPage)
				},
				new NavBarItem
				{
					Title = "Leave New Review",
					IconSrc = "logout.png",
					TargetType = typeof(LandingPage)
				}
			};

			navbarlist.ItemsSource = NavBarItems;

		}
	}
}
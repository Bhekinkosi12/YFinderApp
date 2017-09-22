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
					Title = "Nearby Hotspots",
					IconSrc = "map.png",
					TargetType = typeof(LocationPage)
				},
                new NavBarItem
                {
                    Title = "See Reviews",
                    IconSrc = "list.png",
                    TargetType = typeof(FavoritePage)
                },
                new NavBarItem
                {
                    Title = "Leave New Review",
                    IconSrc = "newReview.png",
                    TargetType = typeof(MakeReviewPage)
                },
                new NavBarItem
                {
                    Title = "View Fellow YFinders",
                    IconSrc = "allUsers.png",
                    TargetType = typeof(UserPage)
                },
				new NavBarItem
				{
					Title = "My Profile",
					IconSrc = "editUser.png",
					TargetType = typeof(EditProfilePage)
				},
                new NavBarItem
				{
					Title = "Log Out",
					IconSrc = "logout.png",
					TargetType = typeof(LandingPage)
				}
			};

			navbarlist.ItemsSource = NavBarItems;

		}
	}
}
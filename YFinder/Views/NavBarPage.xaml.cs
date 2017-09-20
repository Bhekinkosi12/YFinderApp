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
					IconSrc = "",
					TargetType = typeof(FavoritePage)
				},
				new NavBarItem
				{
					Title = "All Users",
					IconSrc = "",
					TargetType = typeof(UserPage)
				},
				new NavBarItem
				{
					Title = "Leave New Review",
					IconSrc = "",
					TargetType = typeof(MakeReviewPage)
				}
			};

			navbarlist.ItemsSource = NavBarItems;

		}
	}
}
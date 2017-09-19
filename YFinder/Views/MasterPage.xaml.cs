using System;
using YFinder;
using System.Collections.Generic;
using YFinder.ViewModels;
using Xamarin.Forms;

namespace YFinder.Views
{
	public partial class MasterPage : MasterDetailPage
	{
		public MasterPage()
		{
			InitializeComponent();
			navBarPage.NavBarList.ItemSelected += OnItemSelected;
		}

		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as NavBarItem;
			if (item != null)
			{
				Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
				navBarPage.NavBarList.SelectedItem = null;
				IsPresented = false;
			}
		}
	}
}
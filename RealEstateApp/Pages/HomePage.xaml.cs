using RealEstateApp.Models;
using RealEstateApp.Services;

namespace RealEstateApp.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		LblUsername.Text = "Hi " + Preferences.Get("username", string.Empty);
		GetCategories();
		GetTrendingProperties();
	}

	private async void GetTrendingProperties()
	{
		var properties = await ApiService.GetTrendingProperties();
		CvTopPicks.ItemsSource = properties;
	}

	private async void GetCategories()
	{
		var categories = await ApiService.GetCategories();
		CvCategories.ItemsSource = categories;
	}

	private void CvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		var currentSelection = e.CurrentSelection.FirstOrDefault() as Category;
		if(currentSelection == null)
		{
			return;
		}
		else
		{
			Navigation.PushAsync(new PropertiesListPage(currentSelection.Id, currentSelection.Name));
			((CollectionView)sender).SelectedItem = null;
		}
	}
}
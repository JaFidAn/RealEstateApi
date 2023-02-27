using RealEstateApp.Services;

namespace RealEstateApp.Pages;

public partial class PropertiesListPage : ContentPage
{
	public PropertiesListPage(int categoryId, string categoryName)
	{
		InitializeComponent();
		Title = categoryName;
		GetPropertiesList(categoryId);
	}

	private async void GetPropertiesList(int categoryId)
	{
		var properties = await ApiService.GetPropertyByCategory(categoryId);
		CvProperties.ItemsSource = properties;
	}
}
using RealEstateApp.Services;

namespace RealEstateApp.Pages;

public partial class PropertyDetailPage : ContentPage
{
	private string phoneNumber;
	public PropertyDetailPage(int propertyId)
	{
		InitializeComponent();
		GetPropertyDetail(propertyId);
	}

	private async void GetPropertyDetail(int propertyId)
	{
		var property = await ApiService.GetPropertyDetail(propertyId);
		LblPrice.Text = "$ " + property.Price;
		LblDescription.Text = property.Detail;
		LblAddress.Text = property.Address;
		ImgProperty.Source = property.FullImageUrl;
		phoneNumber = property.Phone;
	}

	private void TapMessage_Tapped(object sender, TappedEventArgs e)
	{
		var message = new SmsMessage("Hi, I'm interested in your property", phoneNumber);
		Sms.ComposeAsync(message);
	}

	private void TapCall_Tapped(object sender, TappedEventArgs e)
	{
		PhoneDialer.Open(phoneNumber);
	}

	private void ImgBackBtn_Clicked(object sender, EventArgs e)
	{
		Navigation.PopModalAsync();
	}
}
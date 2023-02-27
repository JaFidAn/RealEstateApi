using RealEstateApp.Services;

namespace RealEstateApp.Pages;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

	async void BtnRegister_Clicked(object sender, EventArgs e)
	{
		var response = await ApiService.RegisterUser(EntFullName.Text, EntEmail.Text, EntPassword.Text, EntPhone.Text);
		if (response)
		{
			await DisplayAlert("", "Your account has been created", "Allright");
			await Navigation.PushAsync(new LoginPage());
		}
		else
		{
			await DisplayAlert("", "Something went wrong", "Cancel");
		}
	}

	private async void TapLogin_Tapped(object sender, TappedEventArgs e)
	{
		await Navigation.PushAsync(new LoginPage());
	}
}
using BabylonScore.Services;

namespace BabylonScore.Pages;

public partial class AdminLoginPage : ContentPage
{
    public AdminLoginPage()
    {
        InitializeComponent();
        BindingContext = LocalizationManager.Instance;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ErrorLabel.IsVisible = false;
        UsernameEntry.Text = string.Empty;
        PasswordEntry.Text = string.Empty;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var username = UsernameEntry.Text?.Trim();
        var password = PasswordEntry.Text;

        if (username == "adminmurtada2007" && password == "azlm12345")
        {
            ErrorLabel.IsVisible = false;
            await Navigation.PushAsync(new AdminDashboardPage());
        }
        else
        {
            ErrorLabel.Text = LocalizationManager.Instance["InvalidLogin"];
            ErrorLabel.IsVisible = true;
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}

using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using CommunityToolkit.Mvvm.Input;
using MauiPeopleApp.Views;

namespace MauiPeopleApp.ViewModels;

public partial class LoginViewModel: BaseViewModel
{
    [RelayCommand]
    public async Task LoginWithFingerprint()
    {
#if IOS
            await App.Current.MainPage.DisplayAlert("Platform", "You're on iOS", "OK");
#endif
        var isAvailable = false;
        try
        {
            isAvailable = await CrossFingerprint.Current.IsAvailableAsync(allowAlternativeAuthentication:true);
            await App.Current.MainPage.DisplayAlert("Info", $"Biometric available: {isAvailable}", "OK");
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Error", ex.ToString(), "OK");
        }
            
        if (!isAvailable)
        {
            await Shell.Current.DisplayAlert("Error", "Biometric authentication not available.", "OK");
            return;
        }

        var result = await CrossFingerprint.Current.AuthenticateAsync(new AuthenticationRequestConfiguration("Authentication", "Authenticate to continue")
        {
            CancelTitle = "Cancel",
            FallbackTitle = "Use PIN"
        });
        Console.WriteLine(result);

        if (result.Authenticated)
        {
            await Shell.Current.GoToAsync($"//{nameof(PersonListPage)}");
        }
        
        else
        {
            await Shell.Current.DisplayAlert("Failed", "Authentication failed.", "OK");
        }
    }
}
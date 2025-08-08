using MauiPeopleApp.ViewModels;
using MauiPeopleApp.Models;

namespace MauiPeopleApp.Views;

public partial class PersonListPage : ContentPage
{
    private PersonListViewModel ViewModel => BindingContext as PersonListViewModel;

    public PersonListPage()
    {
        InitializeComponent();
        BindingContext = new PersonListViewModel();
    }

    public async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Person selectedPerson)
        {
            // Clear the selection
            ((CollectionView)sender).SelectedItem = null;
            
            // Navigate to detail page
            await Navigation.PushAsync(new PersonDetailPage(selectedPerson));
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (ViewModel.People.Count == 0)
            ViewModel.LoadPeopleCommand.Execute(null);
    }


}
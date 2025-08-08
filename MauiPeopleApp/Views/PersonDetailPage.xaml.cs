using MauiPeopleApp.Models;
using MauiPeopleApp.ViewModels;

namespace MauiPeopleApp.Views;

public partial class PersonDetailPage : ContentPage
{
    private PersonDetailViewModel ViewModel => BindingContext as PersonDetailViewModel;
    
    public PersonDetailPage()
    {
        InitializeComponent();
    }
    
    public PersonDetailPage(Person person)
    {
        InitializeComponent();
        BindingContext = new PersonDetailViewModel(person);
    }
}
using MauiPeopleApp.Models;

namespace MauiPeopleApp.ViewModels;

public class PersonDetailViewModel: BaseViewModel
{
    public Person Person { get; }

    public PersonDetailViewModel(Person person)
    {
        Person = person;
    }
    
    public PersonDetailViewModel() {}
}
using System.Net.Http.Json;
using MauiPeopleApp.Models;

namespace MauiPeopleApp.Services;

public class PersonService
{
    private readonly HttpClient _httpClient;

    public PersonService()
    {
        _httpClient = new Http();
    }

    public async Task<List<Person>> GetPeopleAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<ApiResponse>("https://reqres.in/api/users");
        return response?.Data ?? new List<Person>();
    }

    private class ApiResponse
    {
        public List<Person> Data { get; set; }
    }
}
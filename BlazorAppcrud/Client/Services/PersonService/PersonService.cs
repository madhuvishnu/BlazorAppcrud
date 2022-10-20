using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorAppcrud.Client.Services.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public PersonService(HttpClient http,NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<person> persons { get; set; }= new List<person>();

        public async Task CreatePerson(person person)
        {
            var result = await _http.PostAsJsonAsync("api/Person", person);
            await Setpersons(result);
        }

        public async Task DeletePerson(int id)
        {
            var result = await _http.DeleteAsync($"api/Person/{id}");
            await Setpersons(result);
        }

        private async Task Setpersons(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<person>>();
            persons = response;
            _navigationManager.NavigateTo("Person");
        }

        public async Task<person> GetPersonById(int id)
        {
            var result = await _http.GetFromJsonAsync<person>($"api/Person/{id}");
            if (result!=null)
                return result;
            throw new Exception("not found here!");
        }

        public async Task GetPersons()
        {
            var result = await _http.GetFromJsonAsync<List<person>>("api/Person");
            if(result!=null)
                persons= result;
        }

        public async Task UpdatePerson(person person)
        {
            var result = await _http.PutAsJsonAsync($"api/Person/{person.id}", person);
            await Setpersons(result);
        }
    }
}

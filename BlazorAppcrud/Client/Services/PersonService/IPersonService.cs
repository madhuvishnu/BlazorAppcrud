using BlazorAppcrud.Shared;

namespace BlazorAppcrud.Client.Services.PersonService
{
    public interface IPersonService
    {
        List<person> persons { get; set; }

        Task GetPersons();

        Task<person> GetPersonById(int id);

        Task CreatePerson(person person);
        Task UpdatePerson(person person);
        Task DeletePerson(int id);

    }
}

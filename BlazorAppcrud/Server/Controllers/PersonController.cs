
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAppcrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly Dbcontext _context;

        public PersonController(Dbcontext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<person>>> GetPersons()
        {
            var persons = await _context.Persons.ToListAsync();
            return Ok(persons);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<person>> Getpersonsbyid(int id)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(h => h.id == id);
            if (person == null)
            {
                return NotFound("sorry! No data here: ");
            }
            return Ok(person);
        }

        [HttpPost]

        public async Task<ActionResult<List<person>>> CreatePerson(person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return Ok(await GetDbpersons());
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<List<person>>> UpdatePerson(person person,int id)
        {
            var dbperson = await _context.Persons.FirstOrDefaultAsync(l=>l.id == id);
            if (dbperson == null)
                return NotFound("Sorry! not found anything here");

            dbperson.Name = person.Name;
            dbperson.city=person.city;
            dbperson.age=person.age;
            dbperson.Role = person.Role;

            await _context.SaveChangesAsync();

            return Ok(await GetDbpersons());
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<person>>> DeletePerson(int id)
        {
            var dbperson = await _context.Persons.FirstOrDefaultAsync(l => l.id == id);
            if (dbperson == null)
                return NotFound("Sorry! not found anything here");

            _context.Persons.Remove(dbperson);
            await _context.SaveChangesAsync();

            return Ok(await GetDbpersons());
        }

        private async Task<List<person>> GetDbpersons()
        {
            return await _context.Persons.ToListAsync();
        }
    }
}

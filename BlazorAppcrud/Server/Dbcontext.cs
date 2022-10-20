

namespace BlazorAppcrud.Server
{
    public class Dbcontext : DbContext
    {
        public Dbcontext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<person>().HasData(
                new person
                {
                    id = 1,
                    Name = "Madhu Kumar",
                    age = 20,
                    Role = "Student",
                    city = "Chamarajanagar"
                },

            new person
            {
                id = 2,
                Name = "Madhu",
                age = 20,
                Role = "Student",
                city = "Mysore"
            }
        );
        }

        
        public DbSet<person> Persons { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using PetCareISW.Entities;
using System;


namespace PetCareISW.DataAccess
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)  { }
        public AppDbContext() {}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB;Database=PetCareISW;Integrated Security=true;");
            //optionsBuilder.UseMySQL("Server=localhost;userid=root;Password=root;Database=PetCareISW2"); 
        }

       
        public DbSet<PersonProfile> PeopleProfiles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<Review> Review { get; set; }
    }
}

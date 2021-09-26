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

            optionsBuilder.UseMySQL("Server=localhost;userid=root;Password=root;Database=PetCareISW2"); 
        }

       
        public DbSet<PersonProfile> PeopleProfiles { get; set; }
    

    }
}

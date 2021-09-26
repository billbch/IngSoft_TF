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

            optionsBuilder.UseSqlServer(@"Server = DESKTOP-44K5N6D\MSSQLSERVER2; Database = PetCare; Integrated Security = true; "); 
        }


        
        public DbSet<Business> Business { get; set; }
        public DbSet<MedicalProfile> MedicalProfile { get; set; }

        public DbSet<PersonProfile> PeopleProfiles { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<Review> Review { get; set; }


    }
}

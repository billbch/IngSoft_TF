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
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-44K5N6D\MSSQLSERVER2;Database=PetCareISW;Integrated Security=true;");
            //optionsBuilder.UseMySQL("Server=localhost;userid=root;Password=root;Database=PetCareISW2"); 
        }

        public DbSet<PersonProfile> PeopleProfiles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<VaccinationRecord> VaccinationRecords { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<MedicalProfile> MedicalProfiles { get; set; }
    }
}

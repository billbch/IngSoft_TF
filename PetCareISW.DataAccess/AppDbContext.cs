using Microsoft.EntityFrameworkCore;
using PetCareISW.Entities;


namespace PetCareISW.DataAccess
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)  { }
        public AppDbContext() {}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
             optionsBuilder.UseSqlServer(@"Server =(localdb)\MSSQLLocalDB;Database=PetCareISW;Integrated Security=true;"); 
            //  optionsBuilder.UseSqlServer(@"Server = LAPTOP-6QJ5S582\MSSQLSERVER01;Database=PetCareISW;Integrated Security=true;");
            //   optionsBuilder.UseMySQL("Server=localhost;userid=root;Password=root;Database=PetCareISW3");
            //optionsBuilder.UseMySQL("Server=us-cdbr-east-04.cleardb.com/;userid=bed40aedacd27b;Password=cb3dc8b6;Database=heroku_cf2c2f5d2d83558");
        }

        public DbSet<PersonProfile> PeopleProfiles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<VaccinationRecord> VaccinationRecords { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<MedicalProfile> MedicalProfiles { get; set; }

        public DbSet<Account> Accounts { get; set; }

    }
}

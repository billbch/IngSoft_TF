using Microsoft.EntityFrameworkCore;
using PetCareISW.DataAccess;

using PetCareISW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCareISW.Services
{
    public class PersonProfileRepository : IPersonProfileRepository
    {
        private readonly AppDbContext _context;
        public PersonProfileRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(PersonProfile personprofile)
        {
            await _context.Set<PersonProfile>().AddAsync(personprofile);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Entry(new PersonProfile
            {
                Id = id
            }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<PersonProfile>> GetCollection(/*string filter*/)
        {
           var collection = await _context.PeopleProfiles/*
                .Where(c => c.Name.Contains(filter))*/
                .ToListAsync();

            return collection;

        }



        public async Task<PersonProfile> GetItem(int id)
        {
            return await _context.PeopleProfiles.FindAsync(id);
        }

        public async Task Update(PersonProfile personprofile)
        {
            _context.Set<PersonProfile>().Attach(personprofile);
            _context.Entry(personprofile).State = EntityState.Modified;
            await _context.SaveChangesAsync(); ;
        }

       
    }
}

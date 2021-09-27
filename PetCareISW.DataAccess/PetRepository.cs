using Microsoft.EntityFrameworkCore;
using PetCareISW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCareISW.DataAccess
{
    public class PetRepository : IPetRepository
    {
        private readonly AppDbContext _context;

        public PetRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Pet entity)
        {
            await _context.Set<Pet>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Entry(new Pet
            {
                Id = id
            }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Pet>> GetCollection(string filter)
        {
            var collection = await _context.Pets
                .Where(c => c.Name.Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task<Pet> GetItem(int id)
        {
            return await _context.Pets.FindAsync(id);
        }

        public async Task Update(Pet entity)
        {
            _context.Set<Pet>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

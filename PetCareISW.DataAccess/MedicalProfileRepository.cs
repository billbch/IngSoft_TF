using Microsoft.EntityFrameworkCore;
using PetCareISW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCareISW.DataAccess
{
    public class MedicalProfileRepository : IMedicalProfileRepository
    {
        private readonly AppDbContext _context;

        public MedicalProfileRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(MedicalProfile entity)
        {
            await _context.Set<MedicalProfile>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Entry(new MedicalProfile
            {
                Id = id
            }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<MedicalProfile>> GetCollection(string filter)
        {
            var collection = await _context.MedicalProfiles
                .Where(c => c.Photo.Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task<MedicalProfile> GetItem(int id)
        {
            return await _context.MedicalProfiles.FindAsync(id);
        }

        public async Task Update(MedicalProfile entity)
        {
            _context.Set<MedicalProfile>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(); ;
        }
    }
}

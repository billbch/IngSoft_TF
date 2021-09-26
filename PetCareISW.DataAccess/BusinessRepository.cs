using Microsoft.EntityFrameworkCore;
using PetCareISW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCareISW.DataAccess
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly AppDbContext _context;

        public BusinessRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Business>> GetCollection(string filter)
        {
            var collection = await _context.Businesses
                .Where(c => c.BusinessName.Contains(filter))
                .ToListAsync();

            return collection;
        }

        public async Task<Business> GetItem(int id)
        {
            return await _context.Businesses.FindAsync(id);
        }

        public async Task Create(Business entity)
        {
            await _context.Set<Business>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Business entity)
        {
            _context.Set<Business>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(); ;
        }

        public async Task Delete(int id)
        {
            _context.Entry(new Business
            {
                Id = id
            }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}

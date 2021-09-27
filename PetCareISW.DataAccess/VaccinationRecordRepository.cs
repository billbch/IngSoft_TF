using Microsoft.EntityFrameworkCore;
using PetCareISW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCareISW.DataAccess
{
    public class VaccinationRecordRepository : IVaccinationRecordRepository
    {
        private readonly AppDbContext _context;

        public VaccinationRecordRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(VaccinationRecord entity)
        {
            await _context.Set<VaccinationRecord>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Entry(new VaccinationRecord
            {
                Id = id
            }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<VaccinationRecord>> GetCollection(string filter)
        {
            var collection = await _context.VaccinationRecords
                .Where(c => c.Name.Contains(filter)).ToListAsync();

            return collection;
        }

        public async Task<VaccinationRecord> GetItem(int id)
        {
            return await _context.VaccinationRecords.FindAsync(id);
        }

        public async Task Update(VaccinationRecord entity)
        {
            _context.Set<VaccinationRecord>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(); ;
        }
    }
}

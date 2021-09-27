using Microsoft.EntityFrameworkCore;
using PetCareISW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCareISW.DataAccess
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {

        private readonly AppDbContext _context;

        public MedicalRecordRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(MedicalRecord entity)
        {
            await _context.Set<MedicalRecord>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _context.Entry(new MedicalRecord
            {
                Id = id
            }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<MedicalRecord>> GetCollection(string filter)
        {
            var collection = await _context.MedicalRecords
                .Where(c => c.AttendantName.Contains(filter)).ToListAsync();

            return collection;
        }

        public async Task<MedicalRecord> GetItem(int id)
        {
            return await _context.MedicalRecords.FindAsync(id);
        }

        public async Task Update(MedicalRecord entity)
        {
            _context.Set<MedicalRecord>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(); ;
        }
    }
}

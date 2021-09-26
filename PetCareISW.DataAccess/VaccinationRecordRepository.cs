using Microsoft.EntityFrameworkCore;
using PetCareISW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCareISW.DataAccess
{
    class VaccinationRecordRepository : IVaccinationRecordRepository
    {
        private readonly AppDbContext _context;

        public VaccinationRecordRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(VaccinationRecord entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<VaccinationRecord>> GetCollection(string filter)
        {
            throw new NotImplementedException();
        }

        public async Task<VaccinationRecord> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(VaccinationRecord entity)
        {
            throw new NotImplementedException();
        }
    }
}

using PetCareISW.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetCareISW.DataAccess
{
    public interface IMedicalRecordRepository
    {
        Task<ICollection<MedicalRecord>> GetCollection(string filter);

        Task<MedicalRecord> GetItem(int id);

        Task Create(MedicalRecord entity);

        Task Update(MedicalRecord entity);

        Task Delete(int id);
    }
}

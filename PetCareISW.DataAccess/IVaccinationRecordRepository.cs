using PetCareISW.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetCareISW.DataAccess
{
    public interface IVaccinationRecordRepository
    {
        Task<ICollection<VaccinationRecord>> GetCollection(string filter);

        Task<VaccinationRecord> GetItem(int id);

        Task Create(VaccinationRecord entity);

        Task Update(VaccinationRecord entity);

        Task Delete(int id);
    }
}

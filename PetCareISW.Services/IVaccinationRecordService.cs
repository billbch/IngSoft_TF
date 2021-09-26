using PetCareISW.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetCareISW.Services
{
    public class IVaccinationRecordService
    {
        Task<ICollection<VaccinationRecordDto>> GetCollection(string filter);
        Task<ResponseDto<VaccinationRecordDto>> GetCustomer(int id);

        Task Create(VaccinationRecordDto request);
        
        Task Update(int id,VaccinationRecordDto request);

        Task Delete(int id);
    }
}
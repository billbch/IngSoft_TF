using PetCareISW.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetCareISW.Services
{
    public interface IVaccinationRecordService
    {
        Task<ICollection<VaccinationRecordDto>> GetCollection(string filter);

        Task<ResponseDto<VaccinationRecordDto>> GetBusiness(int id);

        Task Create(VaccinationRecordDto entity);

        Task Update(int id, VaccinationRecordDto entity);

        Task Delete(int id);
    }
}

using PetCareISW.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetCareISW.Services
{
    public interface IMedicalRecordService
    {
        Task<ICollection<MedicalRecordDto>> GetCollection(string filter);

        Task<ResponseDto<MedicalRecordDto>> GetMedicalRecord(int id);

        Task Create(MedicalRecordDto entity);

        Task Update(int id, MedicalRecordDto entity);

        Task Delete(int id);
    }
}

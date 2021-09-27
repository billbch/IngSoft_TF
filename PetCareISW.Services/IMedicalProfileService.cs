using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PetCareISW.DTO;

namespace PetCareISW.Services
{
    public interface IMedicalProfileService
    {
        Task<ICollection<MedicalProfileDto>> GetCollection(string filter);
        Task<ResponseDto<MedicalProfileDto>> GetCustomer(int id);

        Task Create(MedicalProfileDto request);

        Task Update(int id, MedicalProfileDto request);

        Task Delete(int id);
    }
}

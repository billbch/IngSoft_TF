using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PetCareISW.DTO;

namespace PetCareISW.Services
{
    public interface IMedicalProfileService
    {
        Task<ICollection<MedicalProfileDto>> GetCollection();
        Task<ResponseDto<MedicalProfileDto>> GetCustomer(int id);

        Task Create(MedicalProfileDto_WithoutID request);

        Task Update(MedicalProfileDto_WithoutID request, int id);

        Task Delete(int id);
    }
}

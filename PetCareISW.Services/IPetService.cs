using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PetCareISW.DTO;

namespace PetCareISW.Services
{
    public interface IPetService
    {
        Task<ICollection<PetDto>> GetCollection();
        Task<ResponseDto<PetDto>> GetCustomer(int id);

        Task Create(PetDto_WithoutID request);

        Task Update(PetDto_WithoutID request, int id);

        Task Delete(int id);
    }
}

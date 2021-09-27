using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PetCareISW.DTO;

namespace PetCareISW.Services
{
    public interface IPetService
    {
        Task<ICollection<PetDto>> GetCollection(string filter);
        Task<ResponseDto<PetDto>> GetCustomer(int id);

        Task Create(PetDto request);

        Task Update(int id, PetDto request);

        Task Delete(int id);
    }
}

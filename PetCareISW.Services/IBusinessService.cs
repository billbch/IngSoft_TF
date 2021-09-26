using PetCareISW.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetCareISW.Services
{
    public interface IBusinessService
    {
        Task<ICollection<BusinessDto>> GetCollection(string filter);

        Task<ResponseDto<BusinessDto>> GetBusiness(int id);

        Task Create(BusinessDto entity);

        Task Update(int id, BusinessDto entity);

        Task Delete(int id);
    }
}

using PetCareISW.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetCareISW.Services
{
    public interface IBusinessService
    {
        Task<ICollection<BusinessDto>> GetCollection(string filter);

        Task<ResponseDto<BusinessDto>> GetBusiness(int id);

        Task<ICollection<BusinessDto>> ListByAddressAsync(string address);

        Task<ICollection<BusinessDto>> ListByDistrict(string district);

        Task Create(BusinessDto entity);

        Task Update(int id, BusinessDto entity);

        Task Delete(int id);

    }
}

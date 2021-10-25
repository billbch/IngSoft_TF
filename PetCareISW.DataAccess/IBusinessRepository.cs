using PetCareISW.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetCareISW.DataAccess
{
    public interface IBusinessRepository
    {
        Task<ICollection<Business>> GetCollection(string filter);

        Task<ICollection<Business>> ListByAddressAsync(string Address);

        Task<ICollection<Business>> ListByDistrict(string District);

        Task<Business> GetItem(int id);

        Task Create(Business entity);

        Task Update(Business entity);

        Task Delete(int id);
    }
}

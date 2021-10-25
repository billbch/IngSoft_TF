using PetCareISW.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetCareISW.DataAccess
{
    public interface IPetRepository
    {
        Task<ICollection<Pet>> GetCollection(string filter);

        Task<Pet> GetItem(int id);

        Task Create(Pet entity);

        Task Update(Pet entity);

        Task Delete(int id);
    }
}

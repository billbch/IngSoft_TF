using PetCareISW.Entities;
using System;
using System.Collections.Generic;
using System.Text;
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

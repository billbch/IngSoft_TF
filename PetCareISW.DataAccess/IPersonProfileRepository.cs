using PetCareISW.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetCareISW.DataAccess
{
    public interface IPersonProfileRepository
    {
        Task<ICollection<PersonProfile>> GetCollection(/*string filter*/);

        Task<PersonProfile> GetItem(int id);

        Task Create(PersonProfile personprofile);
        Task Update(PersonProfile personprofile);
        Task Delete(int id);
    }
}

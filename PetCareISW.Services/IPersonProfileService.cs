
using PetCareISW.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetCareISW.Services
{
    public interface IPersonProfileService
    {
         Task<ICollection<PersonProfileDTO>> GetCollection(/*string filter*/);

        Task<ResponseDto<PersonProfileDTO>> GetItem(int id);

        Task Create(PersonProfileDTO personprofile);
        Task Update(PersonProfileDTO personprofile, int id);
        Task Delete(int id);
    }
}

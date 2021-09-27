using PetCareISW.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetCareISW.DataAccess
{
    public interface IMedicalProfileRepository
    {
        Task<ICollection<MedicalProfile>> GetCollection(string filter);

        Task<MedicalProfile> GetItem(int id);

        Task Create(MedicalProfile entity);

        Task Update(MedicalProfile entity);

        Task Delete(int id);
    }
}

using PetCareISW.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetCareISW.DataAccess
{
    public interface IAppointmentRepository
    {
        Task<ICollection<Appointment>> GetCollection(/*string filter*/);

        Task<Appointment> GetItem(int id);

        Task Create(Appointment Appointment);
        Task Update(Appointment Appointment);
        Task Delete(int id);
    }
}

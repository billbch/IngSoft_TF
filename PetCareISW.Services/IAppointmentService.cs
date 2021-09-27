
using PetCareISW.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetCareISW.Services
{
    public interface IAppointmentService
    {
        Task<ICollection<AppointmentDTO>> GetCollection(/*string filter*/);

        Task<ResponseDto<AppointmentDTO>> GetItem(int id);

        Task Create(AppointmentDTO Appointment);
        Task Update(AppointmentDTO Appointment);
        Task Delete(int id);
    }
}

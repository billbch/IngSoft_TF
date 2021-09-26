
using PetCareISW.DataAccess;
using PetCareISW.DTO;
using PetCareISW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCareISW.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _AppointmentRepository;
        public AppointmentService(IAppointmentRepository AppointmentRepository)
        {
            _AppointmentRepository = AppointmentRepository;
        }
        public async Task Create(AppointmentDTO Appointment)
        {

            try
            {
                await _AppointmentRepository.Create(new Appointment
                {

                    CreatedAt = DateTime.Now,
                    StartTime = Appointment.StartTime,
                    EndTime= Appointment.EndTime,
                    Status =true,
                    Veteryname = Appointment.Veteryname,
                    ProductTypeName = Appointment.ProductTypeName,
                   // Age = Appointment.Age,
                   // Phone=Appointment.Phone,
                   

                }); ;;;
            }
            catch (Exception ex)
            {

                throw;
            }
         
        }

        public async Task Delete(int id)
        {
           await _AppointmentRepository.Delete(id);
        }

        public async Task<ICollection<AppointmentDTO>> GetCollection(/*string filter*/)
        {
            var collection = await _AppointmentRepository.GetCollection(/*filter??string.Empty*/);
            return collection
                .Select(c => new AppointmentDTO
                {

                    CreatedAt = c.CreatedAt,
                    StartTime = c.StartTime,
                    EndTime = c.EndTime,
                    Status = true,
                    Veteryname = c.Veteryname,
                    ProductTypeName = c.ProductTypeName,
                   
                   
                }).ToList();

        }

        public async Task<ResponseDto<AppointmentDTO>> GetItem(int id)
        {
            var response = new ResponseDto<AppointmentDTO>();
            var Appointment = await _AppointmentRepository.GetItem(id);

            if (Appointment == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new AppointmentDTO
            {
                CreatedAt = Appointment.CreatedAt,
                StartTime = Appointment.StartTime,
                EndTime = Appointment.EndTime,
                Status = true,
                Veteryname = Appointment.Veteryname,
                ProductTypeName = Appointment.ProductTypeName,
            };

            response.Success = true;

            return response;
        }

        public async Task Update(AppointmentDTO Appointment)
        {
            await _AppointmentRepository.Update(new Appointment
            {

                CreatedAt = DateTime.Now,
                StartTime = Appointment.StartTime,
                EndTime = Appointment.EndTime,
                Status = true,
                Veteryname = Appointment.Veteryname,
                ProductTypeName = Appointment.ProductTypeName,


            });
        }
    }
}

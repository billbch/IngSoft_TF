using PetCareISW.DataAccess;
using PetCareISW.DTO;
using PetCareISW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ICollection<AppointmentDTO>> GetCollection(/*string filter*/)
        {
            var collection = await _AppointmentRepository.GetCollection(/*filter??string.Empty*/);
            return collection
                .Select(c => new AppointmentDTO
                {
                    Id = c.Id,
                    CreatedAt = c.CreatedAt,
                    StartTime = c.StartTime,
                    EndTime = c.EndTime,
                    Status = c.Status,
                    Veteryname = c.Veteryname,
                    ProductTypeName = c.ProductTypeName,
                    PersonProfileId = c.PersonProfileId,
                    BusinessId = c.BusinessId
                   
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
                Status = Appointment.Status,
                Veteryname = Appointment.Veteryname,
                ProductTypeName = Appointment.ProductTypeName,
                PersonProfileId = Appointment.PersonProfileId,
                BusinessId = Appointment.BusinessId
            };

            response.Success = true;

            return response;
        }

        public async Task Update(int id, AppointmentDTO Appointment)
        {
            await _AppointmentRepository.Update(new Appointment
            {
                Id = id,
                CreatedAt = DateTime.Now,
                StartTime = Appointment.StartTime,
                EndTime = Appointment.EndTime,
                Status = Appointment.Status,
                Veteryname = Appointment.Veteryname,
                ProductTypeName = Appointment.ProductTypeName,
                PersonProfileId = Appointment.PersonProfileId,
                BusinessId = Appointment.BusinessId


            });
        }

        public async Task Create(AppointmentDTO Appointment)
        {

            try
            {
                await _AppointmentRepository.Create(new Appointment
                {

                    CreatedAt = DateTime.Now,
                    StartTime = Appointment.StartTime,
                    EndTime = Appointment.EndTime,
                    Status = Appointment.Status,
                    Veteryname = Appointment.Veteryname,
                    ProductTypeName = Appointment.ProductTypeName,
                    PersonProfileId = Appointment.PersonProfileId,
                    BusinessId = Appointment.BusinessId
                    // Age = Appointment.Age,
                    // Phone=Appointment.Phone,
                }); ; ; ;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task Delete(int id)
        {
            await _AppointmentRepository.Delete(id);
        }
    }
}

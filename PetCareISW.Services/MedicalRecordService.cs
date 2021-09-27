using PetCareISW.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PetCareISW.DataAccess;
using PetCareISW.Entities;
using System.Linq;

namespace PetCareISW.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _repository;

        public MedicalRecordService(IMedicalRecordRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(MedicalRecordDto request)
        {
            try
            {
                await _repository.Create(new MedicalRecord
                {
                    CreateAt = request.CreateAt,
                    Description = request.Description,
                    Type = request.Type,
                    Action = request.Action,
                    VetName = request.VetName,
                    AttendantName = request.AttendantName,
                    MedicalProfileId = request.MedicalProfileId
                });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ResponseDto<MedicalRecordDto>> GetMedicalRecord(int id)
        {
            var response = new ResponseDto<MedicalRecordDto>();
            var customer = await _repository.GetItem(id);

            if (customer == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new MedicalRecordDto
            {
                Id = customer.Id,
                CreateAt = customer.CreateAt,
                Description = customer.Description,
                Type = customer.Type,
                Action = customer.Action,
                VetName = customer.VetName,
                AttendantName = customer.AttendantName,
                MedicalProfileId = customer.MedicalProfileId
            };

            response.Success = true;

            return response;
        }

        public async Task<ICollection<MedicalRecordDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(p => new MedicalRecordDto
                {
                    Id = p.Id,
                    CreateAt = p.CreateAt,
                    Description = p.Description,
                    Type = p.Type,
                    Action = p.Action,
                    VetName = p.VetName,
                    AttendantName = p.AttendantName,
                    MedicalProfileId = p.MedicalProfileId
                })
                .ToList();
        }

        public async Task Update(int id, MedicalRecordDto request)
        {
            await _repository.Update(new MedicalRecord
            {
                CreateAt = request.CreateAt,
                Description = request.Description,
                Type = request.Type,
                Action = request.Action,
                VetName = request.VetName,
                AttendantName = request.AttendantName,
                MedicalProfileId = request.MedicalProfileId
            });
        }
    }
}

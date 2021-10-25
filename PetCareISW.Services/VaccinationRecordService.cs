using PetCareISW.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetCareISW.DataAccess;
using PetCareISW.Entities;
using System.Linq;

namespace PetCareISW.Services
{
    public class VaccinationRecordService : IVaccinationRecordService
    {
        private readonly IVaccinationRecordRepository _repository;

        public VaccinationRecordService(IVaccinationRecordRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseDto<VaccinationRecordDto>> GetVaccinationRecord(int id)
        {
            var response = new ResponseDto<VaccinationRecordDto>();
            var customer = await _repository.GetItem(id);

            if (customer == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new VaccinationRecordDto
            {
                Id = customer.Id,
                Name = customer.Name,
                CreateAt = customer.CreateAt,
                Description = customer.Description,
                VetName = customer.VetName,
                MedicalProfileId = customer.MedicalProfileId
            };

            response.Success = true;

            return response;
        }

        public async Task<ICollection<VaccinationRecordDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(p => new VaccinationRecordDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    CreateAt = p.CreateAt,
                    Description = p.Description,
                    VetName = p.VetName,
                    MedicalProfileId = p.MedicalProfileId
                })
                .ToList();
        }

        public async Task Update(int id, VaccinationRecordDto request)
        {
            await _repository.Update(new VaccinationRecord
            {
                Id = id,
                Name = request.Name,
                CreateAt = request.CreateAt,
                Description = request.Description,
                VetName = request.VetName,
                MedicalProfileId = request.MedicalProfileId
            });
        }

        public async Task Create(VaccinationRecordDto request)
        {
            try
            {
                await _repository.Create(new VaccinationRecord
                {
                    CreateAt = request.CreateAt,
                    Name = request.Name,
                    Description = request.Description,
                    VetName = request.VetName,
                    MedicalProfileId = request.MedicalProfileId
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
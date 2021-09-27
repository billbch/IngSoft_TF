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
    public class MedicalProfileService : IMedicalProfileService
    {
        private readonly IMedicalProfileRepository _repository;

        public MedicalProfileService(IMedicalProfileRepository repository)
        {
            _repository = repository;
        }
        public async Task Create(MedicalProfileDto request)
        {
            try
            {
                await _repository.Create(new MedicalProfile
                {
                    Weight = request.Weight,
                    Height = request.Height,
                    Lenght = request.Lenght,
                    Description = request.Description,
                    Photo = request.Photo,
                    PetId = request.PetId
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

        public async Task<ICollection<MedicalProfileDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(p => new MedicalProfileDto
                {
                    Id=p.Id,
                    Weight = p.Weight,
                    Height = p.Height,
                    Lenght = p.Lenght,
                    Description = p.Description,
                    Photo = p.Photo,
                    PetId = p.PetId
                })
                .ToList();
        }

        public async Task<ResponseDto<MedicalProfileDto>> GetCustomer(int id)
        {
            var response = new ResponseDto<MedicalProfileDto>();
            var customer = await _repository.GetItem(id);

            if (customer == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new MedicalProfileDto
            {
                Id = customer.Id,
                Weight = customer.Weight,
                Height = customer.Height,
                Lenght = customer.Lenght,
                Description = customer.Description,
                Photo = customer.Photo,
                PetId = customer.PetId
            };

            response.Success = true;

            return response;
        }

        public async Task Update(int id, MedicalProfileDto request)
        {
            await _repository.Update(new MedicalProfile
            {
                Weight = request.Weight,
                Height = request.Height,
                Lenght = request.Lenght,
                Description = request.Description,
                Photo = request.Photo,
                PetId = request.PetId
            });
        }
    }
}

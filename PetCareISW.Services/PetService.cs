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
    public class PetService : IPetService
    {

        private readonly IPetRepository _repository;

        public PetService(IPetRepository repository)
        {
            _repository = repository;
        }
        public async Task Create(PetDto request)
        {
            try
            {
                await _repository.Create(new Pet
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    BirthDate = request.BirthDate,
                    Age = request.Age,
                    Breed = request.Breed,
                    Photo = request.Photo,
                    Gender = request.Gender,
                    PersonProfileId = request.PersonProfileId
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

        public async Task<ICollection<PetDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(p => new PetDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    LastName = p.LastName,
                    BirthDate = p.BirthDate,
                    Age = p.Age,
                    Breed = p.Breed,
                    Photo = p.Photo,
                    Gender = p.Gender,
                    PersonProfileId = p.PersonProfileId
                })
                .ToList();
        }

        public async Task<ResponseDto<PetDto>> GetCustomer(int id)
        {
            var response = new ResponseDto<PetDto>();
            var customer = await _repository.GetItem(id);

            if (customer == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new PetDto
            {
                Id = customer.Id,
                Name = customer.Name,
                LastName = customer.LastName,
                BirthDate = customer.BirthDate,
                Age = customer.Age,
                Breed = customer.Breed,
                Photo = customer.Photo,
                Gender = customer.Gender,
                PersonProfileId = customer.PersonProfileId
            };

            response.Success = true;

            return response;
        }

        public async Task Update(int id, PetDto request)
        {
            await _repository.Update(new Pet
            {
                Name = request.Name,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                Age = request.Age,
                Breed = request.Breed,
                Photo = request.Photo,
                Gender = request.Gender,
                PersonProfileId = request.PersonProfileId
            });
        }
    }
}

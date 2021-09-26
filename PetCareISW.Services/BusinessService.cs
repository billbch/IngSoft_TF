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
    public class BusinessService : IBusinessService
    {
        private readonly IBusinessRepository _repository;

        public BusinessService(IBusinessRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<BusinessDto>> GetCollection(string filter)
        {
            var collection = await _repository.GetCollection(filter ?? string.Empty);

            return collection.
                Select(p => new BusinessDto
                {
                    Id = p.Id,
                    RUC = p.RUC,
                    BusinessName = p.BusinessName,
                    District = p.District,
                    City = p.City,
                    Address = p.Address,
                    email = p.email,
                    Score = p.Score,
                    Description = p.Description
                })
                .ToList();

        }
        public async Task<ResponseDto<BusinessDto>> GetBusiness(int id)
        {
            var response = new ResponseDto<BusinessDto>();
            var business = await _repository.GetItem(id);

            if (business == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new BusinessDto
            {
                Id = business.Id,
                RUC = business.RUC,
                BusinessName = business.BusinessName,
                District = business.District,
                City = business.City,
                Address = business.Address,
                email = business.email,
                Score = business.Score,
                Description = business.Description
            };

            response.Success = true;

            return response;
        }

        public async Task Create(BusinessDto request)
        {
            try
            {
                await _repository.Create(new Business
                {
                    RUC = request.RUC,
                    BusinessName = request.BusinessName,
                    District = request.District,
                    City = request.City,
                    Address = request.Address,
                    email = request.email,
                    Score = request.Score,
                    Description = request.Description
                });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task Update(int id, BusinessDto request)
        {
            await _repository.Update(new Business
            {
                RUC = request.RUC,
                BusinessName = request.BusinessName,
                District = request.District,
                City = request.City,
                Address = request.Address,
                email = request.email,
                Score = request.Score,
                Description = request.Description
            });
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}

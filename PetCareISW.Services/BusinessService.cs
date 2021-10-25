using PetCareISW.DataAccess;
using PetCareISW.DTO;
using PetCareISW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCareISW.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly IBusinessRepository _repository;
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;
        public BusinessService(IBusinessRepository repository, IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;

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
                    Email = p.Email,
                    Password = p.Password,
                    Score = p.Score,
                    Description = p.Description
                })
                .ToList();

        }


        public async Task<ICollection<BusinessDto>> ListByAddressAsync(string address)
        {
            var collection = await _repository.ListByAddressAsync(address);

            return collection.
                Select(p => new BusinessDto
                {
                    Id = p.Id,
                    RUC = p.RUC,
                    BusinessName = p.BusinessName,
                    District = p.District,
                    City = p.City,
                    Address = p.Address,
                    Email = p.Email,
                    Password = p.Password,
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
                Email = business.Email,
                Password= business.Password,
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
                Account account = new Account();
                Business business = new Business
                {
                    RUC = request.RUC,
                    BusinessName = request.BusinessName,
                    District = request.District,
                    City = request.City,
                    Address = request.Address,
                    Email = request.Email,
                    Password = request.Password,
                    Score = request.Score,
                    Description = request.Description
                };
                await _repository.Create(business);
                account.User =business.Email;
                account.Password = business.Password;
                await _unitOfWork.CompleteAsync();
                account.Idf =business.Id;
                account.RolId = 1;

                await _accountRepository.AddAsyn(account);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Update(int id, BusinessDto request)
        {
            await _repository.Update(new Business
            {
                Id = id,
                RUC = request.RUC,
                BusinessName = request.BusinessName,
                District = request.District,
                City = request.City,
                Address = request.Address,
                Email = request.Email,
                Password = request.Password,
                Score = request.Score,
                Description = request.Description
            });
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ICollection<BusinessDto>> ListByDistrict(string district)
        {
            var collection = await _repository.ListByDistrict(district);

            return collection.
                Select(p => new BusinessDto
                {
                    Id = p.Id,
                    RUC = p.RUC,
                    BusinessName = p.BusinessName,
                    District = p.District,
                    City = p.City,
                    Address = p.Address,
                    Email = p.Email,
                    Password = p.Password,
                    Score = p.Score,
                    Description = p.Description
                })
                .ToList();
        }
    }
}

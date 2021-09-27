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
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repository;

        public ReviewService(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<ReviewDto>> GetCollection()
        {
            var collection = await _repository.GetCollection();

            return collection.
                Select(p => new ReviewDto
                {
                    Id = p.Id,
                    Qualification = p.Qualification,
                    Comment = p.Comment,
                    PersonProfileId = p.PersonProfileId,
                    BusinessId = p.BusinessId
                })
                .ToList();

        }
        public async Task<ResponseDto<ReviewDto>> GetReview(int id)
        {
            var response = new ResponseDto<ReviewDto>();
            var review = await _repository.GetItem(id);

            if (review == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new ReviewDto
            {
                Id = review.Id,
                Qualification = review.Qualification,
                Comment = review.Comment,
                PersonProfileId = review.PersonProfileId,
                BusinessId = review.BusinessId
            };

            response.Success = true;

            return response;
        }

        public async Task Create(ReviewDto request)
        {
            try
            {
                await _repository.Create(new Review
                {
                    Id = request.Id,
                    Qualification = request.Qualification,
                    Comment = request.Comment,
                    PersonProfileId = request.PersonProfileId,
                    BusinessId = request.BusinessId
                });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task Update(int id, ReviewDto request)
        {
            await _repository.Update(new Review
            {
                Id = request.Id,
                Qualification = request.Qualification,
                Comment = request.Comment,
                PersonProfileId = request.PersonProfileId,
                BusinessId = request.BusinessId
            });
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}

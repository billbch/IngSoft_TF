using PetCareISW.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetCareISW.Services
{
    public interface IReviewService
    {
        Task<ICollection<ReviewDto>> GetCollection();

        Task<ResponseDto<ReviewDto>> GetReview(int id);

        Task Create(ReviewDto entity);

        Task Update(int id, ReviewDto entity);

        Task Delete(int id);
    }
}

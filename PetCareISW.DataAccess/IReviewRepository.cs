using PetCareISW.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetCareISW.DataAccess
{
    public interface IReviewRepository
    {
        Task<ICollection<Review>> GetCollection();

        Task<Review> GetItem(int id);

        Task Create(Review entity);

        Task Update(Review entity);

        Task Delete(int id);
    }
}

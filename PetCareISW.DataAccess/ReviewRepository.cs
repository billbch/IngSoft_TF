using Microsoft.EntityFrameworkCore;
using PetCareISW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PetCareISW.DataAccess
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;

        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Review>> GetCollection()
        {
            var collection = await _context.Reviews
                .ToListAsync();

            return collection;
        }

        public async Task<Review> GetItem(int id)
        {
            return await _context.Reviews.FindAsync(id);
        }

        public async Task Create(Review entity)
        {
            await _context.Set<Review>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Review entity)
        {
            _context.Set<Review>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(); ;
        }

        public async Task Delete(int id)
        {
            _context.Entry(new Review
            {
                Id = id
            }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}

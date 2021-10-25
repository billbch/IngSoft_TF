using System.Threading.Tasks;

namespace PetCareISW.DataAccess
{
    public class unitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public unitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;

using PetCareISW.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCareISW.DataAccess
{

    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;
        public AccountRepository(AppDbContext context) 
        {
             _context=context;
           }

        public async Task AddAsyn(Account account)
        {
            await _context.Set<Account>().AddAsync(account);
            await _context.SaveChangesAsync();
            // await _context.Accounts.AddAsync(account);
        }

        public async Task<IEnumerable<Account>> ListAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public Task<Account> GetByUserandPasswordIdAsync(string username, string password) =>
            _context.Accounts
           .Where(x => x.User == username && x.Password == password)
           .FirstAsync();
        //.Include(p => p.User)
    }
}


using PetCareISW.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCareISW.DataAccess
{
    public interface IAccountRepository
    {
        Task AddAsyn(Account account);
        Task<IEnumerable<Account>> ListAsync();

        Task<Account> GetByUserandPasswordIdAsync(string username, string password);
    }

}

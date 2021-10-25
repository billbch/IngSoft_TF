using PetCareISW.Entities;

using System.Collections.Generic;
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

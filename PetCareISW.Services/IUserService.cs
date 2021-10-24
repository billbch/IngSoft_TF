using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace PetCareISW.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest body/*, Task<List<Account>> list*/);

        // Task<List<Account>> ListAsync();
    }
}

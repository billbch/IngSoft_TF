using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;




using PetCareISW.DataAccess;
using PetCareISW.Entities;
using PetCareISW.Services.Settings;

namespace PetCareISW.Services
{

    public class UserService : IUserService
    {


        private IAccountRepository _accountRepository;
        // TODO: Replace by Persistence Implementation
        

        // Secret Settings
        private readonly AppSettings _appSettings;

       
        public UserService(IOptions<AppSettings> appSettings, IAccountRepository accountRepository)
        {

            _appSettings = appSettings.Value;
            _accountRepository = accountRepository;
        }


        public AuthenticateResponse Authenticate(AuthenticateRequest body)
        {
            // var user = _users.SingleOrDefault(x =>
            // x.User == body.Username && x.Password == body.Password);
            try
            {
                var user = _accountRepository.GetByUserandPasswordIdAsync(body.Username,body.Password);
             //Return null when user not found
                if (user.Result == null)
                {
                    return null;
                }
            var token = generateJwtToken(user.Result);
            return new AuthenticateResponse(user.Result, token);
            }
            catch (Exception)
            {
                return null;
            }

            
        }
        

        private string generateJwtToken(Account user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    
    }
}


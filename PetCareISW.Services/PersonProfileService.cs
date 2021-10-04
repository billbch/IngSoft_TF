
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
    public class PersonProfileService : IPersonProfileService
    {
        private readonly IPersonProfileRepository _personProfileRepository;
        public PersonProfileService(IPersonProfileRepository personProfileRepository)
        {
            _personProfileRepository = personProfileRepository;
        }
        public async Task Create(PersonProfileDTO personprofile)
        {

            try
            {
                await _personProfileRepository.Create(new PersonProfile
                {

                    Name = personprofile.Name,
                    LastName = personprofile.LastName,
                    Email = personprofile.Email,
                    Password = personprofile.Password,
                    Document = personprofile.Document,
                    Rol = personprofile.Rol,
                   // Age = personprofile.Age,
                   // Phone=personprofile.Phone,
                    Photo = ""

                }); ;;;
            }
            catch (Exception ex)
            {

                throw;
            }
         
        }

        public async Task Delete(int id)
        {
           await _personProfileRepository.Delete(id);
        }

        public async Task<ICollection<PersonProfileDTO>> GetCollection(/*string filter*/)
        {
            var collection = await _personProfileRepository.GetCollection(/*filter??string.Empty*/);
            return collection
                .Select(c => new PersonProfileDTO
                {
                    Id=c.Id,
                    Name=c.Name,
                    Email=c.Email,
                    Password=c.Password,
                   
                }).ToList();

        }

        public async Task<ResponseDto<PersonProfileDTO>> GetItem(int id)
        {
            var response = new ResponseDto<PersonProfileDTO>();
            var personprofile = await _personProfileRepository.GetItem(id);

            if (personprofile == null)
            {
                response.Success = false;
                return response;
            }

            response.Result = new PersonProfileDTO
            {
                Id = personprofile.Id,
                Name = personprofile.Name,
                Email = personprofile.Email,
                Password = personprofile.Password,
            };

            response.Success = true;

            return response;
        }

        public async Task Update(PersonProfileDTO personprofile, int id)
        {
            await _personProfileRepository.Update(new PersonProfile
            {

                Id = id,
                Name = personprofile.Name,
                LastName = personprofile.LastName,
                Email = personprofile.Email,
                Password = personprofile.Password,
                Document = personprofile.Document,
                Rol = personprofile.Rol,
                Photo = personprofile.Photo


            });
        }
    }
}
//´pusheando desde vs


using Microsoft.AspNetCore.Mvc;
using PetCareISW.DTO;
using PetCareISW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCareISW.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class PersonProfileController : Controller
    {
        /* public IActionResult Index()
         {
             return View();
         }*/
        private readonly IPersonProfileService _personProfileService;
        public PersonProfileController(IPersonProfileService personProfileService)
        {
            _personProfileService = personProfileService;
        }



        [HttpGet]
        public async Task<IEnumerable<PersonProfileDTO>> List()
        {
            return await _personProfileService.GetCollection();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto<PersonProfileDTO>> Get(int id)
        {

            return await _personProfileService.GetItem(id);
        }

        [HttpPost]
        public async Task Post([FromBody] PersonProfileDTO request)
        {
            await _personProfileService.Create(request);

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task Put([FromBody] PersonProfileDTO request,int id)
        {
            await _personProfileService.Update(request,id);

        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task Delete(int id)
        {
            await _personProfileService.Delete(id);

        }
    }
}





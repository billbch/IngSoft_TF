using PetCareISW.DTO;
using PetCareISW.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCareISW.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class MedicalProfileController : ControllerBase
    {
        private readonly IMedicalProfileService _service;

        public MedicalProfileController(IMedicalProfileService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IEnumerable<MedicalProfileDto>> List([FromQuery] string filter)
        {
            return await _service.GetCollection(filter);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto<MedicalProfileDto>> Get(int id)
        {
            return await _service.GetCustomer(id);
        }

        [HttpPost]
        public async Task Post([FromBody] MedicalProfileDto request)
        {
            await _service.Create(request);
        }

    }
}

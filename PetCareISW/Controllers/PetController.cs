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
    public class PetController : ControllerBase
    {
        private readonly IPetService _service;

        public PetController(IPetService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IEnumerable<PetDto>> List([FromQuery] string filter)
        {
            return await _service.GetCollection(filter);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto<PetDto>> Get(int id)
        {
            return await _service.GetCustomer(id);
        }

        [HttpPost]
        public async Task Post([FromBody] PetDto request)
        {
            await _service.Create(request);
        }

    }
}
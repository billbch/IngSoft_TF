using PetCareISW.DTO;
using PetCareISW.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PetCareISW.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
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

        [HttpPut]
        [Route("{id:int}")]
        public async Task Put([FromBody] PetDto request, int id)
        {
            await _service.Update(id, request);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);

        }
    }
}

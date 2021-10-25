using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetCareISW.Services;
using PetCareISW.DTO;

namespace PetCareISW.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessService _service;

        public BusinessController(IBusinessService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("/zone")]
        public async Task<IEnumerable<BusinessDto>> GetProviderbyAdress([FromQuery] string city)
        {
            return await _service.ListByAddressAsync(city);
        
            
        }

        [HttpGet]
        [Route("/district")]
        public async Task<IEnumerable<BusinessDto>> GetByDistrict([FromQuery] string district)
        {
            return await _service.ListByDistrict(district);

        }

        [HttpGet]
        public async Task<IEnumerable<BusinessDto>> List([FromQuery] string filter)
        {
            return await _service.GetCollection(filter);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto<BusinessDto>> Get(int id)
        {
            return await _service.GetBusiness(id);
        }

        [HttpPost]
        public async Task Post([FromBody] BusinessDto request)
        {
            await _service.Create(request);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task Put([FromBody] BusinessDto request, int id)
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

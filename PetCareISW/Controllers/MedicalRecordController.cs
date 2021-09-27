using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetCareISW.Services;
using PetCareISW.DTO;

namespace PetCareISW.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IMedicalRecordService _service;

        public MedicalRecordController(IMedicalRecordService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IEnumerable<MedicalRecordDto>> List([FromQuery] string filter)
        {
            return await _service.GetCollection(filter);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto<MedicalRecordDto>> Get(int id)
        {
            return await _service.GetMedicalRecord(id);
        }

        [HttpPost]
        public async Task Post([FromBody] MedicalRecordDto request)
        {
            await _service.Create(request);
        }
    }
}

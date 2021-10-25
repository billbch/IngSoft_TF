/*using System.Runtime.InteropServices;

// En proyectos de estilo SDK como este, varios atributos de ensamblado que definían
// en este archivo se agregan ahora automáticamente durante la compilación y se rellenan
// con valores definidos en las propiedades del proyecto. Para obtener detalles acerca
// de los atributos que se incluyen y cómo personalizar este proceso, consulte https://aka.ms/assembly-info-properties


// Al establecer ComVisible en false, se consigue que los tipos de este ensamblado
// no sean visibles para los componentes COM. Si tiene que acceder a un tipo en este
// ensamblado desde COM, establezca el atributo ComVisible en true en ese tipo.

[assembly: ComVisible(false)]

// El siguiente GUID es para el identificador de typelib, si este proyecto se expone
// en COM.

[assembly: Guid("fb677c63-23a8-4916-9658-33e1aaccd1e9")]
*/

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
    public class VaccinationRecordController : ControllerBase
    {
        private readonly IVaccinationRecordService _service;

        public VaccinationRecordController(IVaccinationRecordService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IEnumerable<VaccinationRecordDto>> List([FromQuery] string filter)
        {
            return await _service.GetCollection(filter);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto<VaccinationRecordDto>> Get(int id)
        {
            return await _service.GetVaccinationRecord(id);
        }

        [HttpPost]
        public async Task Post([FromBody] VaccinationRecordDto request)
        {
            await _service.Create(request);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task Put([FromBody] VaccinationRecordDto request, int id)
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

using Microsoft.AspNetCore.Mvc;
using PetCareISW.DTO;
using PetCareISW.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetCareISW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        /* public IActionResult Index()
         {
             return View();
         }*/
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<IEnumerable<AppointmentDTO>> List()
        {
            return await _appointmentService.GetCollection();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto<AppointmentDTO>> Get(int id)
        {

            return await _appointmentService.GetItem(id);
        }

        [HttpPost]
        public async Task Post([FromBody] AppointmentDTO request)
        {
            await _appointmentService.Create(request);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task Put([FromBody] AppointmentDTO request, int id)
        {
            await _appointmentService.Update(id, request);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task Delete(int id)
        {
            await _appointmentService.Delete(id);

        }

    }
}

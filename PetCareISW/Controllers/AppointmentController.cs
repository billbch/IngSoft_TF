
using Microsoft.AspNetCore.Mvc;
using PetCareISW.DTO;
using PetCareISW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}

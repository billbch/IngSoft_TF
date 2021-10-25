﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetCareISW.Services;
using PetCareISW.DTO;

namespace PetCareISW.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _service;

        public ReviewController(IReviewService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IEnumerable<ReviewDto>> List()
        {
            return await _service.GetCollection();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto<ReviewDto>> Get(int id)
        {
            return await _service.GetReview(id);
        }

        [HttpPost]
        public async Task Post([FromBody] ReviewDto request)
        {
            await _service.Create(request);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task Put([FromBody] ReviewDto request, int id)
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

using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HotelFinder.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _service;

        public HotelsController(IHotelService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var otels = await _service.GetAllHotels();
            return Ok(otels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var otels = await _service.GetHotelById(id);
            if(otels.Id != 0)
            {
                return Ok(otels);
            }
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Hotel hotel) {
            if (ModelState.IsValid)
            {
                var createOtel = await _service.CreateHotel(hotel);
                return CreatedAtAction("Get", new { id = createOtel.Id });
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                var otel = _service.UpdateHotel(hotel);
                if(otel != null)
                {
                    return Ok(otel);
                }

                else
                {
                    return Problem("Otel gğncellenirken hata oluştu", null, (int)HttpStatusCode.InternalServerError, "Error");

                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           _service.DeleteHotelById(id);
        }
    }
}

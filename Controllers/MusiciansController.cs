using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium.Controllers
{
    [Route("[controller]")]
    public class MusiciansController : ControllerBase
    {
        private readonly IMusiciansService _service;

        public MusiciansController(IMusiciansService service){
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetALbumAsync(int id){
            var album = await _service.GetAlbumByIdAsync(id);

            if(album is null)
                return NotFound("Nie ma takiego albumy");
            else
                return Ok(album);
        }


    }
}
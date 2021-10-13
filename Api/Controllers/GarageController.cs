using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarageController : ControllerBase
    {
        private readonly IGarageRepository _garageRepository;
        public GarageController(IGarageRepository garageRepository)
        {
            _garageRepository = garageRepository;
        }

        [HttpPost]
        [Route("{bookmot}")]
        public IActionResult BookMot([FromBody] Car car)
        {
            string message;
            try
            {
                var bookedDate = this._garageRepository.BookMot(car);
                message = $"{car.Make} {car.Model} MOT booked for {bookedDate} ";
            }
            catch (Exception ex)
            {
                message = ex.Message; 
               
            }

            return this.Ok(message);
        }
    }
}

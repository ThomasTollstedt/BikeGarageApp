using BikeGarageApp.Core.Entities;
using BikeGarageApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BikeGarageApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController(IBikeRepository bikeRepository) : ControllerBase
    {


        // GET: api/<BikeController>
        [HttpGet]
        public async Task<IActionResult> GetAllBikes(CancellationToken cancellationToken)
        {
            var bikes = await bikeRepository.GetAllBikesAsync(cancellationToken);

            return Ok(bikes);
        }

        // GET api/<BikeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBikeById(int id, CancellationToken cancellationToken)
        {
            var bike = await bikeRepository.GetBikeByIdAsync(id, cancellationToken);
            if (bike == null)
            {
                return NotFound();
            }

            return Ok(bike);
        }

        // POST api/<BikeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Bike bike, CancellationToken cancellationToken)
        {
            await bikeRepository.AddAsync(bike, cancellationToken);
            return CreatedAtAction(nameof(GetBikeById), new { id = bike.Id }, bike);
        }

        // PUT api/<BikeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Bike bike, CancellationToken cancellationToken)
        {
            if (id != bike.Id)
            {
                return BadRequest();
            }

            var wasUpdated = await bikeRepository.UpdateAsync(bike, cancellationToken);

            if(!wasUpdated)
            {
                return NotFound();
            }

            return NoContent();

        }

        // DELETE api/<BikeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var wasDeleted = await bikeRepository.DeleteAsync(id, cancellationToken);

            if (!wasDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

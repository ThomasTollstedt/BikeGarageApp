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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BikeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BikeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BikeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BikeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

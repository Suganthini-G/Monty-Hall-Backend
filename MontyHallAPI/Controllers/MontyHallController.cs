using Microsoft.AspNetCore.Mvc;
using MontyHallAPI.IRepository;

namespace MontyHallAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MontyHallController : Controller
    {
        private readonly IMontyHall _montyHall;

        public MontyHallController(IMontyHall montyHall)
        {
            _montyHall = montyHall;
        }

        [HttpGet("simulate")]
        public IActionResult Simulate(int simulations, bool changeDoor)
        {
            if (simulations <= 0)
            {
                return BadRequest("Number of simulations must be greater than zero.");
            }

            var result = _montyHall.Simulation(simulations, changeDoor);
            return Ok(result);
        }
    }
}

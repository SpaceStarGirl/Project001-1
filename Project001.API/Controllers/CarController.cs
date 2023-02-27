using Microsoft.AspNetCore.Mvc;
using Project001.Repo.Interface;
using Project001.Repo.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project001.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private ICarRepository carRepository;

        public CarController(ICarRepository temp)
        {
            carRepository = temp;
        }

        [HttpGet("GetCars")]
        public async Task<IActionResult> GetCars1()
        {
            CarRepository repo = new CarRepository();
            return Ok(await carRepository.getCars());
        }

       

        
    }
}

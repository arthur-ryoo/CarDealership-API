using CarDealership.Data;
using CarDealership.Models;
using CarDealership.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarDealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private CarDbContext _dbContext;
        private readonly ICarRepository _carRepository;

        public CarsController(CarDbContext dbContext, ICarRepository carRepository)
        {
            _dbContext = dbContext;
            _carRepository = carRepository;
        }
         
        // GET: api/<CarsController>
        [HttpGet]
        public IActionResult Get([FromQuery]string[] colors, bool sunRoof = false, bool fourWheelDrive = false, bool lowMiles = false, bool powerWindows = false, bool navigation = false, bool heatedSeats = false)
        {
            var car = _dbContext.Cars.Where(c => c.HasSunroof == sunRoof && c.IsFourWheelDrive == fourWheelDrive && c.HasLowMiles == lowMiles
            && c.HasPowerWindows == powerWindows && c.HasNavigation == navigation && c.HasHeatedSeats == heatedSeats
            );

            List<Car> result = new List<Car>(); 
            if (colors.Length > 0)
            {
                foreach(var color in colors)
                {
                    result.AddRange(car.Where(c => c.Color == color).ToList());
                }
            }
               
            return Ok(result);
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var car = await _carRepository.GetCar(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // POST api/<CarsController>
        [HttpPost]
        public IActionResult Post([FromBody] Car carObject)
        {
            _dbContext.Cars.Add(carObject);
            _dbContext.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Car carObject)
        {
            var car = _dbContext.Cars.Find(id);
            if (car == null)
            {
                return NotFound("No data found with the given ID");
            }
            else
            {
                car.Make = carObject.Make;
                car.Year = carObject.Year;
                car.Color = carObject.Color;
                car.Price = carObject.Price;
                car.HasSunroof = carObject.HasSunroof;
                car.IsFourWheelDrive = carObject.IsFourWheelDrive;
                car.HasLowMiles = carObject.HasLowMiles;
                car.HasPowerWindows = carObject.HasPowerWindows;
                car.HasNavigation = carObject.HasNavigation;
                car.HasHeatedSeats = carObject.HasHeatedSeats;
                _dbContext.SaveChanges();

                return Ok("Successfully updated record");
            }
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var car = _dbContext.Cars.Find(id);
            if (car == null)
            {
                return NotFound("No data found with the given ID");
            }
            else
            {
                _dbContext.Cars.Remove(car);
                _dbContext.SaveChanges();

                return Ok("Successfully deleted record");
            }
        }
    }
}

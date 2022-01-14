using CarDealership.Data;
using CarDealership.Models;
using CarDealership.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Repository
{
    public class CarRepository : ICarRepository
    {
        private CarDbContext _dbContext;
        public CarRepository(CarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Car> GetCar(int id)
        {
            var car = await _dbContext.Cars.FirstOrDefaultAsync(c => c.Id == id);
            return car;
        }
    }
}

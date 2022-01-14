using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Repository.IRepository
{
    public interface ICarRepository
    {
        Task<Car> GetCar(int id);
    }
}

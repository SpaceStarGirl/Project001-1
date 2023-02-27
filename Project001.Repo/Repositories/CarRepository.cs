using Microsoft.EntityFrameworkCore;
using Project001.Repo.Interface;
using Project001.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project001.Repo.Repositories
{
    public class CarRepository : ICarRepository
    {
        private DatabaseContext context { get; set; } = new();
        public async Task<List<Car>> getCars()
        {
            return await context.Car.ToListAsync();
        }
    }
}

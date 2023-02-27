using Project001.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project001.Repo.Interface
{
    public interface ICarRepository
    {
        public Task<List<Car>> getCars();
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using Project001.API.Controllers;
using Project001.Repo.Interface;
using Project001.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project001.Test
{
    public class CarControllerTest
    {
        private readonly CarController carController;

        private readonly Mock<ICarRepository> repo = new();
        
        public CarControllerTest()
        {
            this.carController = new CarController(repo.Object);
        }
        [Fact]

        public async void getCarsReturns200()
        {
            List<Car> cars = new List<Car>()
            {
                new Car {Id = 1, Brand = "Volvo"},
                new Car {Id = 2, Brand = "Mazda"},
                new Car {Id = 3, Brand = "Ford"}
            };
            repo.Setup(c => c.getCars()).ReturnsAsync(cars);
            var result = await carController.GetCars1();
            ////var res = await carController.GetCars();
            var statuscode = (IStatusCodeActionResult)result;
            Assert.Equal(200, statuscode.StatusCode);

        }

        

        
    }
}

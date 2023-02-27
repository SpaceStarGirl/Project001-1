using Moq;
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
        private readonly CarControllerTest carController;

        private readonly Mock<ICarRepository> repoCar = new();

        public CarControllerTest()
        {
            this.carController = new CarControllerTest();
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
            repoCar.Setup(c => c.getCars()).ReturnsAsync(cars);

            var res = await carController
            Assert.Equal(3, res.Cars.Count);

        }

        
    }
}

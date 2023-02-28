using Project001.API.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project001.Repo.Repositories;
using Project001.Repo.Interface;
using Project001.Repo.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Project001.Test
{
    public class PersonControllerTest
    {
        // Simulate our PersonController...
        // Cause, we dont use it.

        private readonly PersonController personController;
        //using Moq
        private readonly Mock<IPersonRepository> repo = new (); // Prøv med en class her

        public PersonControllerTest()
        {
            //this.repo = _repo;
            this.personController = new PersonController(repo.Object);
        }
        [Fact]
        public async void getPersonsShouldReturn200()
        {
            //Arrange - Data, initialize objects etc.
            List<Person> persons = new List<Person>
            {
                new Person {id = 1, name = "Casper"},
                new Person {id = 2, name = "Hans"},
                new Person {id = 3, name = "Ulla"}
            };
            //we need to Mock our data
            //repo is an object, that is started with method Setup()
            //ReturnsAsync - returns an object, when getPersons() is invoked
            repo.Setup(s => s.getPersons()).ReturnsAsync(persons);
            //Act - Invoke our methods
            var result = await personController.GetPersons1();
            //Assert - call Assert, basically a bool 
            //Check the result and then assert
            var statuscode = (IStatusCodeActionResult)result; // get type eller typeof mm.
            Assert.Equal(200, statuscode.StatusCode);
        }
        [Fact]
        public async void createPerson()
        {

            //Arrange
            Person person = (new Person { id = 2, name = "Anna", age = 25 });
            repo.Setup(c => c.createPerson(It.IsAny<Person>())).ReturnsAsync(person);

            //Act - Invoke your method
            var result = await personController.CreatePerson(person);

            //Assert
            var statuscode = (IStatusCodeActionResult)result;
            Assert.Equal(200, statuscode.StatusCode);

        }
        [Fact]
        public async void getPersonByIdReturn2000()
        {
            List<Person> persons = new List<Person>
            {
                new Person {id = 1, name = "Casper"},
                new Person {id = 2, name = "Hans"},
                new Person {id = 3, name = "Ulla"}
            };
            Person pp = new Person { id = 1, name = "Ulla" };

            repo.Setup(obj => obj.getPersonById(1)).ReturnsAsync(pp);

            var result = await personController.GetPersonById(1);
            var temp = (ObjectResult)result;
            Person p = (Person)temp.Value;
            Assert.Equal(p.name, "Ulla");
        }

        [Fact]
        public async void deletePerson()
        {

        }
        // ? er om vores objekt skal initialiseres

        // Method getPersons..


    }


}

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
    public class PersonRepository : IPersonRepository
    {
        // how do I use the Database? // ORM
        private DatabaseContext context { get; set; } = new();

        public PersonRepository(DatabaseContext d)
        {
            context = d; // runtime
            //context = new DatabaseContext(); //compiletime
        }

        public PersonRepository()
        {
        }
        #region start


        public Task DeletePerson(int id)
        {
            throw new NotImplementedException();
        }


        // make a method that can be called
        public string getName() { return "I am the Jedi"; }

        public async Task<Person> getPersonById(int id)
        {
            return await context.Person.FirstOrDefaultAsync(obj=> obj.id == id);
            //throw new NotImplementedException();
        }

        public Task<Person> getPersonByName(string name)
        {
            throw new NotImplementedException();
        }

        #endregion start
        public async Task<List<Person>> getPersons()
        {
            //Jeg skal benytte EF
            // til at skrive noget LINQ som returnerer alle
            // personer tilbage til en var variabel
            // og dernæst returnerer denne...

            return await context.Person.ToListAsync();
        }

        public async Task<Person> createPerson(Person person)
        {

            context.Add(person);
            context.SaveChangesAsync();
            return person;

        }

        public Task<Person> updatePerson(Person person)
        {
            return null;
        }
        public async Task<Person> deletePerson(int id)
        {
            var temp = await context.Person.FindAsync(id);

            if( temp != null)
            {
                context.Person.Remove(temp);
                await context.SaveChangesAsync();
                return temp;

            }
            else
            {
                return null;
            }
        }
    }
}

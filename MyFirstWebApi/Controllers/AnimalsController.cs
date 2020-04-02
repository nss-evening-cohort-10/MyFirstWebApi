using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebApi.Models;

namespace MyFirstWebApi.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {

        static List<Animal> _animals = new List<Animal>
                                    {
                                        new Animal {Id = 1, Name = "Steve", Type = "Elephant", Weight = 2000},
                                        new Animal {Id = 2, Name = "George", Type = "Monkey", Weight = 87},
                                        new Animal {Id = 3, Name = "Tony", Type = "Tiger", Weight = 1200}
                                    };

        // GET /api/animals
        [HttpGet]
        public IActionResult GetAllAnimals()
        {
            return Ok(_animals);
        }

        // GET /api/animals/{id}
        [HttpGet("{id}")]
        public IActionResult GetSingleAnimal(int id)
        {
            var animalIWant = _animals.FirstOrDefault(a => a.Id == id);

            if (animalIWant == null)
            {
                return NotFound($"Animal with the id {id} was not found.");
            }

            return Ok(animalIWant);
        }

        // POST /api/animals
        [HttpPost]
        public IActionResult AddAnAnimal(Animal animalToAdd)
        {
            _animals.Add(animalToAdd);

            return Ok(_animals);
        }

        // PUT /api/animals/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAnAnimal(int id, Animal animal)
        {
            var animalToUpdate = _animals.FirstOrDefault(a => a.Id == id);

            if (animalToUpdate == null)
            {
                return NotFound("Can't Update cause it doesn't exist");
            }

            animalToUpdate.Name = animal.Name;
            animalToUpdate.Weight = animal.Weight;
            animalToUpdate.Type = animal.Type;

            return Ok(animalToUpdate);
        }


    }
}
using Cwiczenia4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia4.Controllers;

[Route("api/[controller]")]
[ApiController]
 public class AnimalsController : ControllerBase
    {
        
        // GET api/animals
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Database.Animals);
        }

        // GET api/animals/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
                return NotFound();
            return Ok(animal);
        }
    
        // POST api/animals
        [HttpPost]
        public IActionResult Post([FromBody] Animal animal)
        {
            animal.Id = Database.Animals.Count > 0 ? Database.Animals.Max(a => a.Id) + 1 : 1;
            Database.Animals.Add(animal);
            return CreatedAtAction(nameof(Get), new { id = animal.Id }, animal);
        }

        // PUT api/animals/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Animal updatedAnimal)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
                return NotFound();

            animal.Name = updatedAnimal.Name;
            animal.Category = updatedAnimal.Category;
            animal.Weight = updatedAnimal.Weight;
            animal.FurColor = updatedAnimal.FurColor;

            return NoContent();
        }

        // DELETE api/animals/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
                return NotFound();

            Database.Animals.Remove(animal);
            return NoContent();
        }

        // GET api/animals/search?name=Imie
        [HttpGet("search")]
        public IActionResult Search([FromQuery] string name)
        {
            var result = Database.Animals.Where(a => a.Name.ToLower() == name.ToLower()).ToList();
            return Ok(result);
        }
        
        // GET: api/animals/{id}/visits
        [HttpGet("{id}/visits")]
        public IActionResult GetVisits(int id)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
                return NotFound("Nie znaleziono zwierzęcia o podanym id.");
            return Ok(animal.Visits);
        }

        // POST: api/animals/{id}/visits
        [HttpPost("{id}/visits")]
        public IActionResult AddVisit(int id, [FromBody] Visit visit)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
                return NotFound("Nie znaleziono zwierzęcia o podanym id.");
            animal.Visits.Add(visit);
            return Ok(visit);
        }
    }


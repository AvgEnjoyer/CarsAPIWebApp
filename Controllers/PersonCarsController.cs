using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarsAPIWebApp.Models;

namespace CarsAPIWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonCarsController : ControllerBase
    {
        private readonly CarsAPIContext _context;

        public PersonCarsController(CarsAPIContext context)
        {
            _context = context;
        }

        // GET: api/PersonCars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonCar>>> GetPersonCars()
        {
          if (_context.PersonCars == null)
          {
              return NotFound();
          }
            return await _context.PersonCars.ToListAsync();
        }

        // GET: api/PersonCars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonCar>> GetPersonCar(int id)
        {
          if (_context.PersonCars == null)
          {
              return NotFound();
          }
            var personCar = await _context.PersonCars.FindAsync(id);

            if (personCar == null)
            {
                return NotFound();
            }

            return personCar;
        }

        // PUT: api/PersonCars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonCar(int id, PersonCar personCar)
        {
            if (id != personCar.Id)
            {
                return BadRequest();
            }

            _context.Entry(personCar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonCarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PersonCars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonCar>> PostPersonCar(PersonCar personCar)
        {
          if (_context.PersonCars == null)
          {
              return Problem("Entity set 'CarsAPIContext.PersonCars'  is null.");
          }
            _context.PersonCars.Add(personCar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonCar", new { id = personCar.Id }, personCar);
        }

        // DELETE: api/PersonCars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonCar(int id)
        {
            if (_context.PersonCars == null)
            {
                return NotFound();
            }
            var personCar = await _context.PersonCars.FindAsync(id);
            if (personCar == null)
            {
                return NotFound();
            }

            _context.PersonCars.Remove(personCar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonCarExists(int id)
        {
            return (_context.PersonCars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

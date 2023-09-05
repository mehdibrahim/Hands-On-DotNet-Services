using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Models;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public SchoolsController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/Schools
        [HttpGet("get-all-schools")]

        public async Task<ActionResult<IEnumerable<School>>> GetSchools()
        {
            if (_context.Schools == null)
            {
                return NotFound();
            }
            return await _context.Schools.ToListAsync();
        }

        // GET: api/Schools/5
        [HttpGet("get-schools-by-id/{id}")]

        public async Task<ActionResult<School>> GetSchool(int id)
        {
            if (_context.Schools == null)
            {
                return NotFound();
            }
            var school = await _context.Schools.FindAsync(id);

            if (school == null)
            {
                return NotFound();
            }

            return school;
        }

        // PUT: api/Schools/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("edit-school/{id}")]
        public async Task<IActionResult> PutSchool(int id, School school)
        {
            if (id != school.Id)
            {
                return BadRequest();
            }

            _context.Entry(school).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolExists(id))
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

        // POST: api/Schools
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("create-school")]
        public async Task<ActionResult<School>> PostSchool(School school)
        {
            if (_context.Schools == null)
            {
                return Problem("Entity set 'SchoolDbContext.Schools'  is null.");
            }
            _context.Schools.Add(school);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchool", new { id = school.Id }, school);
        }

        // DELETE: api/Schools/5
        [HttpDelete("delete-school/{id}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            if (_context.Schools == null)
            {
                return NotFound();
            }
            var school = await _context.Schools.FindAsync(id);
            if (school == null)
            {
                return NotFound();
            }

            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SchoolExists(int id)
        {
            return (_context.Schools?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        [HttpGet("list-of-school")]
        public async Task<ActionResult<IEnumerable<School>>> SearchByName(String name = "")
        {
            var liste = from m in _context.Schools
                        where m.Name.Contains(name)
                        select m;
            return await liste.ToListAsync();
        }


    }
}

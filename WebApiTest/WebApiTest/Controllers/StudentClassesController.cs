using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTest.Data;
using WebApiTest.Model;

namespace WebApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentClassesController : ControllerBase
    {
        private readonly ApiDataContext _context;

        public StudentClassesController(ApiDataContext context)
        {
            _context = context;
        }

        // GET: api/StudentClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentClass>>> GetStudent()
        {
            return await _context.Student.ToListAsync();
        }

        // GET: api/StudentClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentClass>> GetStudentClass(int id)
        {
            var studentClass = await _context.Student.FindAsync(id);

            if (studentClass == null)
            {
                return NotFound();
            }

            return studentClass;
        }

        // PUT: api/StudentClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentClass(int id, StudentClass studentClass)
        {
            if (id != studentClass.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentClassExists(id))
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

        // POST: api/StudentClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentClass>> PostStudentClass(StudentClass studentClass)
        {
            _context.Student.Add(studentClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentClass", new { id = studentClass.Id }, studentClass);
        }

        // DELETE: api/StudentClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentClass(int id)
        {
            var studentClass = await _context.Student.FindAsync(id);
            if (studentClass == null)
            {
                return NotFound();
            }

            _context.Student.Remove(studentClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentClassExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}

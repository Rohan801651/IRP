using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Students.Data;
using Students.Models;

namespace Students.Controllers
{
    [ApiController]
    [Route("AzCoaching/[controller]")]
    public class StudentController : Controller
    {
        private readonly StudentContext _context;

        public StudentController(StudentContext context)
        {
            _context = context;


        }

        // In this controller we have methods like student can see their current courses, same like ZABDESK

        /* // GET: Student
         public async Task<IActionResult> Index()
         {
             return View(await _context.Students.ToListAsync());
         }

         // GET: Student/Details/5
         public async Task<IActionResult> Details(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var student = await _context.Students
                 .FirstOrDefaultAsync(m => m.StudentId == id);
             if (student == null)
             {
                 return NotFound();
             }

             return View(student);
         }

         // GET: Student/Create
         public IActionResult Create()
         {
             return View();
         }

         // POST: Student/Create
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Create([Bind("StudentId,StudentName,StudentContact,DateOfRegistration,Field,StudentClass")] Student student)
         {
             if (ModelState.IsValid)
             {
                 _context.Add(student);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             return View(student);
         }

         // GET: Student/Edit/5
         public async Task<IActionResult> Edit(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var student = await _context.Students.FindAsync(id);
             if (student == null)
             {
                 return NotFound();
             }
             return View(student);
         }

         // POST: Student/Edit/5
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,StudentContact,DateOfRegistration,Field,StudentClass")] Student student)
         {
             if (id != student.StudentId)
             {
                 return NotFound();
             }

             if (ModelState.IsValid)
             {
                 try
                 {
                     _context.Update(student);
                     await _context.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!StudentExists(student.StudentId))
                     {
                         return NotFound();
                     }
                     else
                     {
                         throw;
                     }
                 }
                 return RedirectToAction(nameof(Index));
             }
             return View(student);
         }

         // GET: Student/Delete/5
         public async Task<IActionResult> Delete(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var student = await _context.Students
                 .FirstOrDefaultAsync(m => m.StudentId == id);
             if (student == null)
             {
                 return NotFound();
             }

             return View(student);
         }

         // POST: Student/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> DeleteConfirmed(int id)
         {
             var student = await _context.Students.FindAsync(id);
             if (student != null)
             {
                 _context.Students.Remove(student);
             }

             await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));
         }

         private bool StudentExists(int id)
         {
             return _context.Students.Any(e => e.StudentId == id);
         }*/  // Not Need yet...


        // GET: AZ-Coaching/students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();

        }

        // GET: AZ-Coaching/students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        // POST: AZ-Coaching/students
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudent), new { id = student.StudentId }, student);

        }

        // PUT: AZ-Coaching/students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }
            _context.Entry(student).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // DELETE: AZ-Coaching/students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}

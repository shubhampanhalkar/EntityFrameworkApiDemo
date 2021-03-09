using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoApi.Data;
using DemoApi.Models;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpProController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmpProController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/EmpPro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeesInProject>>> GetEmployeesInProjects()
        {
            return await _context.EmployeesInProjects.ToListAsync();
        }

        // GET: api/EmpPro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeesInProject>> GetEmployeesInProject(int id)
        {
            var employeesInProject = await _context.EmployeesInProjects.FindAsync(id);

            if (employeesInProject == null)
            {
                return NotFound();
            }

            return employeesInProject;
        }

        // PUT: api/EmpPro/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeesInProject(int id, EmployeesInProject employeesInProject)
        {
            if (id != employeesInProject.EmployeeID)
            {
                return BadRequest();
            }

            _context.Entry(employeesInProject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesInProjectExists(id))
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

        // POST: api/EmpPro
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeesInProject>> PostEmployeesInProject(EmployeesInProject employeesInProject)
        {
            _context.EmployeesInProjects.Add(employeesInProject);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeesInProjectExists(employeesInProject.EmployeeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeesInProject", new { id = employeesInProject.EmployeeID }, employeesInProject);
        }

        // DELETE: api/EmpPro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeesInProject(int id)
        {
            var employeesInProject = await _context.EmployeesInProjects.FindAsync(id);
            if (employeesInProject == null)
            {
                return NotFound();
            }

            _context.EmployeesInProjects.Remove(employeesInProject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeesInProjectExists(int id)
        {
            return _context.EmployeesInProjects.Any(e => e.EmployeeID == id);
        }
    }
}

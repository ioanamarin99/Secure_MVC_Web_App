using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISM_Y1_Marin_Ioana_Web_Cloud_Project.Data;
using ISM_Y1_Marin_Ioana_Web_Cloud_Project.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace ISM_Y1_Marin_Ioana_Web_Cloud_Project.Controllers
{
    [Authorize]
    public class JobsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public JobsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.jobs.Include(j => j.Employee);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.jobs == null)
            {
                return NotFound();
            }

            var job = await _context.jobs
                .Include(j => j.Employee)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.employees, "EmployeeId", "EmployeeId");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobId,JobName,WeeklyHours,EmployeeId")] Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.employees, "EmployeeId", "EmployeeId", job.EmployeeId);
            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!User.IsInRole("DeleteEditRole"))
            {
                return Unauthorized("Access denied! You do not have access to this resource.");
            }

            if (id == null || _context.jobs == null)
            {
                return NotFound();
            }

            var job = await _context.jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.employees, "EmployeeId", "EmployeeId", job.EmployeeId);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobId,JobName,WeeklyHours,EmployeeId")] Job job)
        {
            //Imperative authorization
            if (!User.IsInRole("DeleteEditRole"))
            {
                return Unauthorized("Access denied! You do not have access to this resource.");
            }
            if (id != job.JobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.JobId))
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
            ViewData["EmployeeId"] = new SelectList(_context.employees, "EmployeeId", "EmployeeId", job.EmployeeId);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!User.IsInRole("DeleteEditRole"))
            {
                return Unauthorized("Access denied! You do not have access to this resource.");
            }

            if (id == null || _context.jobs == null)
            {
                return NotFound();
            }

            var job = await _context.jobs
                .Include(j => j.Employee)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //Imperative authorization
            if (!User.IsInRole("DeleteEditRole"))
            {
                return Unauthorized("Access denied! You do not have access to this resource.");
            }
            if (_context.jobs == null)
            {
                return Problem("Entity set 'ApplicationDBContext.jobs'  is null.");
            }
            var job = await _context.jobs.FindAsync(id);
            if (job != null)
            {
                _context.jobs.Remove(job);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobExists(int id)
        {
          return (_context.jobs?.Any(e => e.JobId == id)).GetValueOrDefault();
        }
    }
}

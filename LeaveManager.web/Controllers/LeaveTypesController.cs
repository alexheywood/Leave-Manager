using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManager.web.Data;
using LeaveManager.web.Models;
using AutoMapper;
using LeaveManager.web.ViewModels;

namespace LeaveManager.web.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper; 

        public LeaveTypesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
              return _context.LeaveTypes != null ? 
                          View(mapper.Map<List<LeaveTypeViewModel>>(await _context.LeaveTypes.ToListAsync())) :
                          Problem("Entity set 'ApplicationDbContext.LeaveTypes'  is null.");
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LeaveTypes == null)
            {
                return NotFound();
            }

            var leaveType = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveType == null)
            {
                return NotFound();
            }

            var leaveTypeViewModel = mapper.Map<LeaveTypeViewModel>(leaveType); 

            return View(leaveTypeViewModel);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeViewModel leaveTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                var leaveType = mapper.Map<LeaveType>(leaveTypeViewModel);

                _context.Add(leaveType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeViewModel);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LeaveTypes == null)
            {
                return NotFound();
            }

            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }

            var leaveTypeViewModel = mapper.Map<LeaveTypeViewModel>(leaveType);

            return View(leaveTypeViewModel);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeViewModel leaveTypeViewModel)
        {
            if (id != leaveTypeViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var leaveType = mapper.Map<LeaveType>(leaveTypeViewModel);

                    _context.Update(leaveType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveTypeExists(leaveTypeViewModel.Id))
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
            return View(leaveTypeViewModel);
        }

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LeaveTypes == null)
            {
                return NotFound();
            }

            var leaveType = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LeaveTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LeaveTypes'  is null.");
            }
            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if (leaveType != null)
            {
                _context.LeaveTypes.Remove(leaveType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveTypeExists(int id)
        {
          return (_context.LeaveTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

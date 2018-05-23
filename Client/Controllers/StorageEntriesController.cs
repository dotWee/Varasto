using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Varasto.Core.Database;
using Varasto.Core.Model;

namespace Varasto.Client.Controllers
{
    public class StorageEntriesController : Controller
    {
        private readonly DatabaseContext _context;

        public StorageEntriesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: StorageEntries
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.StorageEntries.Include(s => s.Storage);
            return View(await databaseContext.ToListAsync());
        }

        // GET: StorageEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storageEntry = await _context.StorageEntries
                .Include(s => s.Storage)
                .SingleOrDefaultAsync(m => m.StorageEntryId == id);
            if (storageEntry == null)
            {
                return NotFound();
            }

            return View(storageEntry);
        }

        // GET: StorageEntries/Create
        public IActionResult Create()
        {
            ViewData["StorageId"] = new SelectList(_context.Storages, "StorageId", "StorageId");
            return View();
        }

        // POST: StorageEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StorageEntryId,StorageId,Amount")] StorageEntry storageEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storageEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StorageId"] = new SelectList(_context.Storages, "StorageId", "StorageId", storageEntry.StorageId);
            return View(storageEntry);
        }

        // GET: StorageEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storageEntry = await _context.StorageEntries.SingleOrDefaultAsync(m => m.StorageEntryId == id);
            if (storageEntry == null)
            {
                return NotFound();
            }
            ViewData["StorageId"] = new SelectList(_context.Storages, "StorageId", "StorageId", storageEntry.StorageId);
            return View(storageEntry);
        }

        // POST: StorageEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StorageEntryId,StorageId,Amount")] StorageEntry storageEntry)
        {
            if (id != storageEntry.StorageEntryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storageEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StorageEntryExists(storageEntry.StorageEntryId))
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
            ViewData["StorageId"] = new SelectList(_context.Storages, "StorageId", "StorageId", storageEntry.StorageId);
            return View(storageEntry);
        }

        // GET: StorageEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storageEntry = await _context.StorageEntries
                .Include(s => s.Storage)
                .SingleOrDefaultAsync(m => m.StorageEntryId == id);
            if (storageEntry == null)
            {
                return NotFound();
            }

            return View(storageEntry);
        }

        // POST: StorageEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var storageEntry = await _context.StorageEntries.SingleOrDefaultAsync(m => m.StorageEntryId == id);
            _context.StorageEntries.Remove(storageEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StorageEntryExists(int id)
        {
            return _context.StorageEntries.Any(e => e.StorageEntryId == id);
        }
    }
}

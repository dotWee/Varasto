using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Varasto.Core.Database;
using Varasto.Core.Model;

namespace Varasto.Client.Controllers
{
    public class LabelController : Controller
    {
        private readonly DatabaseContext _context;

        public LabelController(DatabaseContext databaseContext)
        {
            _context = databaseContext;
        }

        // GET: Labels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Labels.ToListAsync());
        }

        // GET: Labels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var label = await _context.Labels
                .SingleOrDefaultAsync(l => l.LabelId == id);
            if (label == null) return NotFound();

            return View(label);
        }

        // GET: Labels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Labels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LabelID,Description")] Label label)
        {
            if (ModelState.IsValid)
            {
                _context.Add(label);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(label);
        }

        // GET: Labels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var label = await _context.Labels.SingleOrDefaultAsync(l => l.LabelId == id);
            if (label == null) return NotFound();
            return View(label);
        }

        // POST: Labels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LabelId,Description")] Label label)
        {
            if (id != label.LabelId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(label);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabelExists(label.LabelId))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(label);
        }

        // GET: Labels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var label = await _context.Labels
                .SingleOrDefaultAsync(l => l.LabelId == id);
            if (label == null) return NotFound();

            return View(label);
        }

        // POST: Labels/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var label = await _context.Labels.SingleOrDefaultAsync(l => l.LabelId == id);
            _context.Labels.Remove(label);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabelExists(int id)
        {
            return _context.Labels.Any(e => e.LabelId == id);
        }
    }
}
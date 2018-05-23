using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Varasto.Core.Database;
using Varasto.Core.Model;

namespace Varasto.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/StorageEntries")]
    public class StorageEntriesController : Controller
    {
        private readonly DatabaseContext _context;

        public StorageEntriesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/StorageEntries
        [HttpGet]
        public IEnumerable<StorageEntry> GetStorageEntries()
        {
            return _context.StorageEntries;
        }

        // GET: api/StorageEntries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStorageEntry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var storageEntry = await _context.StorageEntries.SingleOrDefaultAsync(m => m.StorageEntryId == id);

            if (storageEntry == null)
            {
                return NotFound();
            }

            return Ok(storageEntry);
        }

        // PUT: api/StorageEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStorageEntry([FromRoute] int id, [FromBody] StorageEntry storageEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != storageEntry.StorageEntryId)
            {
                return BadRequest();
            }

            _context.Entry(storageEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StorageEntryExists(id))
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

        // POST: api/StorageEntries
        [HttpPost]
        public async Task<IActionResult> PostStorageEntry([FromBody] StorageEntry storageEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StorageEntries.Add(storageEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStorageEntry", new { id = storageEntry.StorageEntryId }, storageEntry);
        }

        // DELETE: api/StorageEntries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStorageEntry([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var storageEntry = await _context.StorageEntries.SingleOrDefaultAsync(m => m.StorageEntryId == id);
            if (storageEntry == null)
            {
                return NotFound();
            }

            _context.StorageEntries.Remove(storageEntry);
            await _context.SaveChangesAsync();

            return Ok(storageEntry);
        }

        private bool StorageEntryExists(int id)
        {
            return _context.StorageEntries.Any(e => e.StorageEntryId == id);
        }
    }
}
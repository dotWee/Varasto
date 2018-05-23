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
    [Route("api/Storages")]
    public class StoragesController : Controller
    {
        private readonly DatabaseContext _context;

        public StoragesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Storages
        [HttpGet]
        public IEnumerable<Storage> GetStorages()
        {
            return _context.Storages;
        }

        // GET: api/Storages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStorage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var storage = await _context.Storages.SingleOrDefaultAsync(m => m.StorageId == id);

            if (storage == null)
            {
                return NotFound();
            }

            return Ok(storage);
        }

        // PUT: api/Storages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStorage([FromRoute] int id, [FromBody] Storage storage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != storage.StorageId)
            {
                return BadRequest();
            }

            _context.Entry(storage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StorageExists(id))
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

        // POST: api/Storages
        [HttpPost]
        public async Task<IActionResult> PostStorage([FromBody] Storage storage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Storages.Add(storage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStorage", new { id = storage.StorageId }, storage);
        }

        // DELETE: api/Storages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStorage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var storage = await _context.Storages.SingleOrDefaultAsync(m => m.StorageId == id);
            if (storage == null)
            {
                return NotFound();
            }

            _context.Storages.Remove(storage);
            await _context.SaveChangesAsync();

            return Ok(storage);
        }

        private bool StorageExists(int id)
        {
            return _context.Storages.Any(e => e.StorageId == id);
        }
    }
}
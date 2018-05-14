using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreSpa.Server;
using AspNetCoreSpa_master.Server.Entities;

namespace AspNetCoreSpa.Server.Controllers.api
{
    [Produces("application/json")]
    [Route("api/BookContracts")]
    public class BookContractsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookContractsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BookContracts
        [HttpGet]
        public IEnumerable<BookContract> GetBookContracts()
        {
            return _context.BookContracts;
        }

        // GET: api/BookContracts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookContract([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookContract = await _context.BookContracts.SingleOrDefaultAsync(m => m.Id == id);

            if (bookContract == null)
            {
                return NotFound();
            }

            return Ok(bookContract);
        }

        // PUT: api/BookContracts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookContract([FromRoute] int id, [FromBody] BookContract bookContract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookContract.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookContract).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookContractExists(id))
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

        // POST: api/BookContracts
        [HttpPost]
        public async Task<IActionResult> PostBookContract([FromBody] BookContract bookContract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BookContracts.Add(bookContract);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookContract", new { id = bookContract.Id }, bookContract);
        }

        // DELETE: api/BookContracts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookContract([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookContract = await _context.BookContracts.SingleOrDefaultAsync(m => m.Id == id);
            if (bookContract == null)
            {
                return NotFound();
            }

            _context.BookContracts.Remove(bookContract);
            await _context.SaveChangesAsync();

            return Ok(bookContract);
        }

        private bool BookContractExists(int id)
        {
            return _context.BookContracts.Any(e => e.Id == id);
        }
    }
}
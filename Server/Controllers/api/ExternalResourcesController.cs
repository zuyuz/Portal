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
    [Route("api/ExternalResources")]
    public class ExternalResourcesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExternalResourcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ExternalResources
        [HttpGet]
        public IEnumerable<ExternalResource> GetExternalResources()
        {
            return _context.ExternalResources;
        }

        // GET: api/ExternalResources/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExternalResource([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var externalResource = await _context.ExternalResources.SingleOrDefaultAsync(m => m.Id == id);

            if (externalResource == null)
            {
                return NotFound();
            }

            return Ok(externalResource);
        }

        // PUT: api/ExternalResources/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExternalResource([FromRoute] int id, [FromBody] ExternalResource externalResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != externalResource.Id)
            {
                return BadRequest();
            }

            _context.Entry(externalResource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExternalResourceExists(id))
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

        // POST: api/ExternalResources
        [HttpPost]
        public async Task<IActionResult> PostExternalResource([FromBody] ExternalResource externalResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ExternalResources.Add(externalResource);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExternalResource", new { id = externalResource.Id }, externalResource);
        }

        // DELETE: api/ExternalResources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExternalResource([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var externalResource = await _context.ExternalResources.SingleOrDefaultAsync(m => m.Id == id);
            if (externalResource == null)
            {
                return NotFound();
            }

            _context.ExternalResources.Remove(externalResource);
            await _context.SaveChangesAsync();

            return Ok(externalResource);
        }

        private bool ExternalResourceExists(int id)
        {
            return _context.ExternalResources.Any(e => e.Id == id);
        }
    }
}
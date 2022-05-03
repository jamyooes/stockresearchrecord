#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stockResearchAPI.Models;

namespace stockResearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyEventController : ControllerBase
    {
        private readonly StockAPIDBContext _context;

        public CompanyEventController(StockAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/CompanyEvent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyEvent>>> GetCompanyEvents()
        {
            return await _context.CompanyEvent.ToListAsync();
        }

        // GET: api/CompanyEvent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyEvent>> GetCompanyEvent(int id)
        {
            var companyEvent = await _context.CompanyEvent.FindAsync(id);

            if (companyEvent == null)
            {
                return NotFound();
            }

            return companyEvent;
        }

        // PUT: api/CompanyEvent/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyEvent(int id, CompanyEvent companyEvent)
        {
            if (id != companyEvent.StockId)
            {
                return BadRequest();
            }

            _context.Entry(companyEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyEventExists(id))
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

        // POST: api/CompanyEvent
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyEvent>> PostCompanyEvent(CompanyEvent companyEvent)
        {
            _context.CompanyEvent.Add(companyEvent);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCompanyEvent", new { id = companyEvent.StockId }, companyEvent);
        }

        // DELETE: api/CompanyEvent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyEvent(int id)
        {
            var companyEvent = await _context.CompanyEvent.FindAsync(id);
            if (companyEvent == null)
            {
                return NotFound();
            }

            _context.CompanyEvent.Remove(companyEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyEventExists(int id)
        {
            return _context.CompanyEvent.Any(e => e.StockId == id);
        }
    }
}

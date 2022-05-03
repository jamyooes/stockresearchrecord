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
    public class ResearchController : ControllerBase
    {
        private readonly StockAPIDBContext _context;

        public ResearchController(StockAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Research
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Research>>> GetResearch()
        {
            return await _context.Research.ToListAsync();
        }

        // GET: api/Research/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Research>> GetResearch(int id)
        {
            var research = await _context.Research.FindAsync(id);

            if (research == null)
            {
                return NotFound();
            }

            return research;
        }

        // PUT: api/Research/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResearch(int id, Research research)
        {
            if (id != research.StockId)
            {
                return BadRequest();
            }

            _context.Entry(research).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResearchExists(id))
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

        // POST: api/Research
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Research>> PostResearch(Research research)
        {
            _context.Research.Add(research);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ResearchExists(research.StockId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetResearch", new { id = research.StockId }, research);
        }

        // DELETE: api/Research/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResearch(int id)
        {
            var research = await _context.Research.FindAsync(id);
            if (research == null)
            {
                return NotFound();
            }

            _context.Research.Remove(research);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResearchExists(int id)
        {
            return _context.Research.Any(e => e.StockId == id);
        }
    }
}

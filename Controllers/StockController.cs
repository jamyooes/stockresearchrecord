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
    public class StockController : ControllerBase
    {
        private readonly StockAPIDBContext _context;

        public StockController(StockAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Stock
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetStocks()
        {
            var stocks = await _context.Stock.Include(e => e.CompanyEvent)
                                  .Include(e => e.Research)
                                  .ToListAsync();
            return stocks;
        }

        // GET: api/Stock/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetStock(int id)
        {
            var stock = await _context.Stock.Include(e => e.CompanyEvent)
                                          .Include(e => e.Research)
                                          .SingleOrDefaultAsync(i => i.StockId == id);

            var response = new Response();

            response.statusCode = 404;
            response.statusDescription = "Not Found. Either there is no entries or you are entering the wrong id. Try checking api/stock to check the possible id's from the stock list";

            if (stock != null)
            {
                response.statusCode = 200;
                response.statusDescription = "Valid get request nice job!";
                response.stock.Add(stock);
            }

            return response;
        }

        // GET: api/Stock/5/research
        [HttpGet("{id}/research")]
        public async Task<ActionResult<Response>> GetStockResearch(int id)
        {
            var stock = await _context.Stock.Include(e => e.Research)
                                          .SingleOrDefaultAsync(i => i.StockId == id);

            var response = new Response();

            response.statusCode = 404;
            response.statusDescription = "Not Found. Either there is no entries or you are entering the wrong id. Try checking api/stock to check the possible id's from the stock list";

            if (stock != null)
            {
                response.statusCode = 200;
                response.statusDescription = "Valid get request nice job!";
                response.stock.Add(stock);
            }

            return response;
        }

        // GET: api/Stock/5/companyevent
        [HttpGet("{id}/companyevent")]
        public async Task<ActionResult<Response>> GetStockCompanyEvent(int id)
        {
            var stock = await _context.Stock.Include(e => e.CompanyEvent)
                                          .SingleOrDefaultAsync(i => i.StockId == id);

            var response = new Response();

            response.statusCode = 404;
            response.statusDescription = "Not Found. Either there is no entries or you are entering the wrong id. Try checking api/stock to check the possible id's from the stock list";

            if (stock != null)
            {
                response.statusCode = 200;
                response.statusDescription = "Valid get request nice job!";
                response.stock.Add(stock);
            }

            return response;
        }

        // PUT: api/Stock/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStock(int id, Stock stock)
        {
            if (id != stock.StockId)
            {
                return BadRequest();
            }

            _context.Entry(stock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(id))
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

        // POST: api/Stock
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Response> PostStock(Stock stock)
        {
            _context.Stock.Add(stock);
            await _context.SaveChangesAsync();

            var response = new Response();

            response.statusCode = 404;
            response.statusDescription = "Bad request, double check your response body";

            if (stock != null)
            {
                response.statusCode = 200;
                response.statusDescription = "Valid post request nice job!";
            }

            return response;
        }

        // DELETE: api/Stock/5
        [HttpDelete("{id}")]
        public async Task<Response> DeleteStock(int id)
        {
            var stocks = await _context.Stock.Include(e => e.CompanyEvent)
                      .Include(e => e.Research).FirstOrDefaultAsync(c => c.StockId == id);
            var response = new Response();

            if (stocks == null)
            {
                response.statusCode = 404;
                response.statusDescription = "Bad request, this stock id doesn't exist";
                return response;
            }
            _context.Stock.Remove(stocks);

            if (stocks.Research != null)
            { 
                var research = await _context.Research.FirstOrDefaultAsync(l => l.StockId == stocks.Research.StockId);

                _context.Research.Remove(research);
            }

            if (stocks.CompanyEvent != null)
            {
                var events = await _context.CompanyEvent.FirstOrDefaultAsync(l => l.StockId == stocks.CompanyEvent.StockId);

                _context.CompanyEvent.Remove(events);
            }

            await _context.SaveChangesAsync();

            if (stocks != null)
            {
                response.statusCode = 200;
                response.statusDescription = "WOW YOU DELETED!";
            }

            return response;
        }

        private bool StockExists(int id)
        {
            return _context.Stock.Any(e => e.StockId == id);
        }
    }
}

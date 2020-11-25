using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiwebpim.Models;

namespace apiwebpim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasAPagarController : ControllerBase
    {
        private readonly ApiPimcontext _context;

        public ContasAPagarController(ApiPimcontext context)
        {
            _context = context;
        }

        // GET: api/ContasAPagar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContasAPagar>>> GetContasAPagar()
        {
            return await _context.ContasAPagar.ToListAsync();
        }

        // GET: api/ContasAPagar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContasAPagar>> GetContasAPagar(int id)
        {
            var contasAPagar = await _context.ContasAPagar.FindAsync(id);

            if (contasAPagar == null)
            {
                return NotFound();
            }

            return contasAPagar;
        }

        // PUT: api/ContasAPagar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContasAPagar(int id, ContasAPagar contasAPagar)
        {
            if (id != contasAPagar.CodContasPag)
            {
                return BadRequest();
            }

            _context.Entry(contasAPagar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContasAPagarExists(id))
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

        // POST: api/ContasAPagar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ContasAPagar>> PostContasAPagar(ContasAPagar contasAPagar)
        {
            _context.ContasAPagar.Add(contasAPagar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContasAPagar", new { id = contasAPagar.CodContasPag }, contasAPagar);
        }

        // DELETE: api/ContasAPagar/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContasAPagar>> DeleteContasAPagar(int id)
        {
            var contasAPagar = await _context.ContasAPagar.FindAsync(id);
            if (contasAPagar == null)
            {
                return NotFound();
            }

            _context.ContasAPagar.Remove(contasAPagar);
            await _context.SaveChangesAsync();

            return contasAPagar;
        }

        private bool ContasAPagarExists(int id)
        {
            return _context.ContasAPagar.Any(e => e.CodContasPag == id);
        }
    }
}

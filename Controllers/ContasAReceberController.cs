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
    public class ContasAReceberController : ControllerBase
    {
        private readonly ApiPimcontext _context;

        public ContasAReceberController(ApiPimcontext context)
        {
            _context = context;
        }

        // GET: api/ContasAReceber
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContasAReceber>>> GetContasAReceber()
        {
            return await _context.ContasAReceber.ToListAsync();
        }

        // GET: api/ContasAReceber/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContasAReceber>> GetContasAReceber(int id)
        {
            var contasAReceber = await _context.ContasAReceber.FindAsync(id);

            if (contasAReceber == null)
            {
                return NotFound();
            }

            return contasAReceber;
        }

        // PUT: api/ContasAReceber/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContasAReceber(int id, ContasAReceber contasAReceber)
        {
            if (id != contasAReceber.CodContasRec)
            {
                return BadRequest();
            }

            _context.Entry(contasAReceber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContasAReceberExists(id))
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

        // POST: api/ContasAReceber
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ContasAReceber>> PostContasAReceber(ContasAReceber contasAReceber)
        {
            _context.ContasAReceber.Add(contasAReceber);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContasAReceber", new { id = contasAReceber.CodContasRec }, contasAReceber);
        }

        // DELETE: api/ContasAReceber/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContasAReceber>> DeleteContasAReceber(int id)
        {
            var contasAReceber = await _context.ContasAReceber.FindAsync(id);
            if (contasAReceber == null)
            {
                return NotFound();
            }

            _context.ContasAReceber.Remove(contasAReceber);
            await _context.SaveChangesAsync();

            return contasAReceber;
        }

        private bool ContasAReceberExists(int id)
        {
            return _context.ContasAReceber.Any(e => e.CodContasRec == id);
        }
    }
}

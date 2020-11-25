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
    public class MultaController : ControllerBase
    {
        private readonly ApiPimcontext _context;

        public MultaController(ApiPimcontext context)
        {
            _context = context;
        }

        // GET: api/Multa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Multa>>> GetMulta()
        {
            return await _context.Multa.ToListAsync();
        }

        // GET: api/Multa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Multa>> GetMulta(int id)
        {
            var multa = await _context.Multa.FindAsync(id);

            if (multa == null)
            {
                return NotFound();
            }

            return multa;
        }

        // PUT: api/Multa/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMulta(int id, Multa multa)
        {
            if (id != multa.CodMulta)
            {
                return BadRequest();
            }

            _context.Entry(multa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MultaExists(id))
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

        // POST: api/Multa
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Multa>> PostMulta(Multa multa)
        {
            _context.Multa.Add(multa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMulta", new { id = multa.CodMulta }, multa);
        }

        // DELETE: api/Multa/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Multa>> DeleteMulta(int id)
        {
            var multa = await _context.Multa.FindAsync(id);
            if (multa == null)
            {
                return NotFound();
            }

            _context.Multa.Remove(multa);
            await _context.SaveChangesAsync();

            return multa;
        }

        private bool MultaExists(int id)
        {
            return _context.Multa.Any(e => e.CodMulta == id);
        }
    }
}

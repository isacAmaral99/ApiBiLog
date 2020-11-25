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
    public class SaidaController : ControllerBase
    {
        private readonly ApiPimcontext _context;

        public SaidaController(ApiPimcontext context)
        {
            _context = context;
        }

        // GET: api/Saida
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Saida>>> GetSaida()
        {
            return await _context.Saida.ToListAsync();
        }

        // GET: api/Saida/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Saida>> GetSaida(int id)
        {
            var saida = await _context.Saida.FindAsync(id);

            if (saida == null)
            {
                return NotFound();
            }

            return saida;
        }

        // PUT: api/Saida/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaida(int id, Saida saida)
        {
            if (id != saida.CodSaida)
            {
                return BadRequest();
            }

            _context.Entry(saida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaidaExists(id))
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

        // POST: api/Saida
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Saida>> PostSaida(Saida saida)
        {
            _context.Saida.Add(saida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaida", new { id = saida.CodSaida }, saida);
        }

        // DELETE: api/Saida/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Saida>> DeleteSaida(int id)
        {
            var saida = await _context.Saida.FindAsync(id);
            if (saida == null)
            {
                return NotFound();
            }

            _context.Saida.Remove(saida);
            await _context.SaveChangesAsync();

            return saida;
        }

        private bool SaidaExists(int id)
        {
            return _context.Saida.Any(e => e.CodSaida == id);
        }
    }
}

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
    public class EntradaController : ControllerBase
    {
        private readonly ApiPimcontext _context;

        public EntradaController(ApiPimcontext context)
        {
            _context = context;
        }

        // GET: api/Entrada
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entrada>>> GetEntrada()
        {
            return await _context.Entrada.ToListAsync();
        }

        // GET: api/Entrada/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entrada>> GetEntrada(int id)
        {
            var entrada = await _context.Entrada.FindAsync(id);

            if (entrada == null)
            {
                return NotFound();
            }

            return entrada;
        }

        // PUT: api/Entrada/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntrada(int id, Entrada entrada)
        {
            if (id != entrada.CodEntrada)
            {
                return BadRequest();
            }

            _context.Entry(entrada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntradaExists(id))
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

        // POST: api/Entrada
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Entrada>> PostEntrada(Entrada entrada)
        {
            _context.Entrada.Add(entrada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntrada", new { id = entrada.CodEntrada }, entrada);
        }

        // DELETE: api/Entrada/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Entrada>> DeleteEntrada(int id)
        {
            var entrada = await _context.Entrada.FindAsync(id);
            if (entrada == null)
            {
                return NotFound();
            }

            _context.Entrada.Remove(entrada);
            await _context.SaveChangesAsync();

            return entrada;
        }

        private bool EntradaExists(int id)
        {
            return _context.Entrada.Any(e => e.CodEntrada == id);
        }
    }
}

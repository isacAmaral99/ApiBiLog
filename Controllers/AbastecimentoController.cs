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
    public class AbastecimentoController : ControllerBase
    {
        private readonly ApiPimcontext _context;

        public AbastecimentoController(ApiPimcontext context)
        {
            _context = context;
        }

        // GET: api/Abastecimento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Abastecimento>>> GetAbastecimento()
        {
            return await _context.Abastecimento.ToListAsync();
        }

        // GET: api/Abastecimento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Abastecimento>> GetAbastecimento(int id)
        {
            var abastecimento = await _context.Abastecimento.FindAsync(id);

            if (abastecimento == null)
            {
                return NotFound();
            }

            return abastecimento;
        }

        // PUT: api/Abastecimento/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbastecimento(int id, Abastecimento abastecimento)
        {
            if (id != abastecimento.CodAbastecimento)
            {
                return BadRequest();
            }

            _context.Entry(abastecimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbastecimentoExists(id))
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

        // POST: api/Abastecimento
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Abastecimento>> PostAbastecimento(Abastecimento abastecimento)
        {
            _context.Abastecimento.Add(abastecimento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAbastecimento", new { id = abastecimento.CodAbastecimento }, abastecimento);
        }

        // DELETE: api/Abastecimento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Abastecimento>> DeleteAbastecimento(int id)
        {
            var abastecimento = await _context.Abastecimento.FindAsync(id);
            if (abastecimento == null)
            {
                return NotFound();
            }

            _context.Abastecimento.Remove(abastecimento);
            await _context.SaveChangesAsync();

            return abastecimento;
        }

        private bool AbastecimentoExists(int id)
        {
            return _context.Abastecimento.Any(e => e.CodAbastecimento == id);
        }
    }
}

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
    public class ManutencaoController : ControllerBase
    {
        private readonly ApiPimcontext _context;

        public ManutencaoController(ApiPimcontext context)
        {
            _context = context;
        }

        // GET: api/Manutencao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manutencao>>> GetManutencao()
        {
            return await _context.Manutencao.ToListAsync();
        }

        // GET: api/Manutencao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manutencao>> GetManutencao(int id)
        {
            var manutencao = await _context.Manutencao.FindAsync(id);

            if (manutencao == null)
            {
                return NotFound();
            }

            return manutencao;
        }

        // PUT: api/Manutencao/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManutencao(int id, Manutencao manutencao)
        {
            if (id != manutencao.CodManutencao)
            {
                return BadRequest();
            }

            _context.Entry(manutencao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManutencaoExists(id))
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

        // POST: api/Manutencao
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Manutencao>> PostManutencao(Manutencao manutencao)
        {
            _context.Manutencao.Add(manutencao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManutencao", new { id = manutencao.CodManutencao }, manutencao);
        }

        // DELETE: api/Manutencao/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Manutencao>> DeleteManutencao(int id)
        {
            var manutencao = await _context.Manutencao.FindAsync(id);
            if (manutencao == null)
            {
                return NotFound();
            }

            _context.Manutencao.Remove(manutencao);
            await _context.SaveChangesAsync();

            return manutencao;
        }

        private bool ManutencaoExists(int id)
        {
            return _context.Manutencao.Any(e => e.CodManutencao == id);
        }
    }
}

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
    public class Perfis : ControllerBase
    {
        private readonly ApiPimcontext _context;

        public Perfis(ApiPimcontext context)
        {
            _context = context;
        }

        // GET: api/Perfis
        [HttpGet]
        public async Task<ActionResult> GetPerfis()
        {
            var lista = await _context.Perfis.ToListAsync();
            return Ok(lista);
        }

        // GET: api/Perfis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Perfis>> GetPerfis(int id)
        {
            var perfis = await _context.Perfis.FindAsync(id);

            if (perfis == null)
            {
                return NotFound();
            }

            return Ok(perfis);
        }

        // PUT: api/Perfis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfis(int id, Perfis perfis)
        {
            // primeiro eu vejo se o id nao é nulo, se for eu dou o bad, caso nao for, eu consulto e altero
            if (id == null)
            {
                return BadRequest();
            }else{
                _context.Perfis.FindAsync(id);
            }

            _context.Entry(perfis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfisExists(id))
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

        // POST: api/Perfis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        // [HttpPost]
        // public async Task<ActionResult<Perfis>> PostPerfis(Perfis perfis)
        // {
        //     _context.Perfis.Add(perfis);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetPerfis", new { id = perfis.CodPerfil }, perfis);
        // }

        // DELETE: api/Perfis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Perfis>> DeletePerfis(int id)
        {
            var perfis = await _context.Perfis.FindAsync(id);
            if (perfis == null)
            {
                return NotFound();
            }

            _context.Perfis.Remove(perfis);
            await _context.SaveChangesAsync();

            return Ok(perfis);
        }

        private bool PerfisExists(int id)
        {
            return _context.Perfis.Any(e => e.CodPerfil == id);
        }
    }
}

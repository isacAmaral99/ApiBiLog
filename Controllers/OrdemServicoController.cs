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
    public class OrdemServicoController : ControllerBase
    {
        private readonly ApiPimcontext _context;

        public OrdemServicoController(ApiPimcontext context)
        {
            _context = context;
        }

        // GET: api/OrdemServico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderServico>>> GetOrderServico()
        {
            return await _context.OrderServico.ToListAsync();
        }

        // GET: api/OrdemServico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderServico>> GetOrderServico(int id)
        {
            var orderServico = await _context.OrderServico.FindAsync(id);

            if (orderServico == null)
            {
                return NotFound();
            }

            return orderServico;
        }

        // PUT: api/OrdemServico/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderServico(int id, OrderServico orderServico)
        {
            if (id != orderServico.CodOrdemServico)
            {
                return BadRequest();
            }

            _context.Entry(orderServico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderServicoExists(id))
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

        // POST: api/OrdemServico
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrderServico>> PostOrderServico(OrderServico orderServico)
        {
            _context.OrderServico.Add(orderServico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderServico", new { id = orderServico.CodOrdemServico }, orderServico);
        }

        // DELETE: api/OrdemServico/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderServico>> DeleteOrderServico(int id)
        {
            var orderServico = await _context.OrderServico.FindAsync(id);
            if (orderServico == null)
            {
                return NotFound();
            }

            _context.OrderServico.Remove(orderServico);
            await _context.SaveChangesAsync();

            return orderServico;
        }

        private bool OrderServicoExists(int id)
        {
            return _context.OrderServico.Any(e => e.CodOrdemServico == id);
        }
    }
}

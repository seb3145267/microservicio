using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreWebApiComputadoras.Data;
using CoreWebApiComputadoras.Modelo;

namespace CoreWebApiComputadoras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputadorasController : ControllerBase
    {
        private readonly CoreWebApiComputadorasContext _context;

        public ComputadorasController(CoreWebApiComputadorasContext context)
        {
            _context = context;
        }

        // GET: api/Computadoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Computadoras>>> GetComputadoras()
        {
            return await _context.Computadoras.ToListAsync();
        }

        // GET: api/Computadoras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Computadoras>> GetComputadoras(int id)
        {
            var computadoras = await _context.Computadoras.FindAsync(id);

            if (computadoras == null)
            {
                return NotFound();
            }

            return computadoras;
        }

        // PUT: api/Computadoras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComputadoras(int id, Computadoras computadoras)
        {
            if (id != computadoras.id)
            {
                return BadRequest();
            }

            _context.Entry(computadoras).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputadorasExists(id))
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

        // POST: api/Computadoras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Computadoras>> PostComputadoras(Computadoras computadoras)
        {
            _context.Computadoras.Add(computadoras);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComputadoras", new { id = computadoras.id }, computadoras);
        }

        // DELETE: api/Computadoras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComputadoras(int id)
        {
            var computadoras = await _context.Computadoras.FindAsync(id);
            if (computadoras == null)
            {
                return NotFound();
            }

            _context.Computadoras.Remove(computadoras);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComputadorasExists(int id)
        {
            return _context.Computadoras.Any(e => e.id == id);
        }
    }
}

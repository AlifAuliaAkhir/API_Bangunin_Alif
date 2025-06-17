using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bangun.Data;
using bangun.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace bangun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TokoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Toko>>> GetAll()
        {
            return await _context.Toko.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Toko>> Get(int id)
        {
            var toko = await _context.Toko.FindAsync(id);
            if (toko == null) return NotFound();
            return toko;
        }

        [HttpPost]
        public async Task<ActionResult<Toko>> Post(Toko toko)
        {
            _context.Toko.Add(toko);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = toko.IdToko }, toko);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Toko toko)
        {
            if (id != toko.IdToko) return BadRequest();
            _context.Entry(toko).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var toko = await _context.Toko.FindAsync(id);
            if (toko == null) return NotFound();
            _context.Toko.Remove(toko);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

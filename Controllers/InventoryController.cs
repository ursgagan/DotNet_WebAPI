using InventoryAPIs.Data;
using InventoryAPIs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace InventoryAPIs.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public InventoryController(InventoryDbContext context) => _context = context;
        
        [HttpGet]

        public async Task<IEnumerable<Inventory>> Get() => await _context.Inventories.ToListAsync();

        [HttpGet("id")]
        [ProducesResponseType(typeof(Inventory), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByID(int id)
        {
            var inventoryDetails = await _context.Inventories.FindAsync(id);
            return inventoryDetails == null ? NotFound() : Ok(inventoryDetails);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Inventory inventoryDetails)
        {
            await _context.Inventories.AnyAsync();
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByID), new { id = inventoryDetails.Id }, inventoryDetails);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Inventory inventorydetails)
        {
            if (id != inventorydetails.Id) return BadRequest();
            _context.Entry(inventorydetails).State = System.Data.Entity.EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var DeleteDetails = await _context.Inventories.FindAsync(id);
            if (DeleteDetails == null) return NotFound();

            _context.Inventories.Remove(DeleteDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

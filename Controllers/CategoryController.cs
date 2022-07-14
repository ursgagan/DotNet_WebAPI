using InventoryAPIs.Data;
using InventoryAPIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace InventoryAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public CategoryController(InventoryDbContext context) => _context = context;

        [HttpGet]

        public async Task<IEnumerable<Category>> Get() => await _context.Category.ToListAsync();

        [HttpGet("id")]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByID(int id)
        {
            var category = await _context.Category.FindAsync(id);
            return category == null ? NotFound() : Ok(category);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Category category)
        {
            await _context.Category.AnyAsync();
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByID), new { id = category.id }, category);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Category category)
        {
            if (id != category.id) return BadRequest();
            _context.Entry(category).State = System.Data.Entity.EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var DeleteCategory = await _context.Category.FindAsync(id);
            if (DeleteCategory == null) return NotFound();

            _context.Category.Remove(DeleteCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

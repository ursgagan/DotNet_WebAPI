using System.Data.Entity;
using InventoryAPIs.Data;
using InventoryAPIs.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly InventoryDbContext _context = new InventoryDbContext();

        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            var list = await _context.Categories.ToListAsync();
            if (list.Any())
            {
                return list;
            }
            else
            {
                return new List<Category>()
                {
                    new Category(){Id=1,CategoryName="foobar",CreateDateTime=DateTime.UtcNow,IsActive=false}
                };
            }
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(Category), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByID(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category == null ? NotFound() : Ok(category);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Category category)
        {
            await _context.Categories.AnyAsync();
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByID), new { id = category.Id }, category);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Category category)
        {
            if (id != category.Id) return BadRequest();
            _context.Entry(category).State = System.Data.Entity.EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var DeleteCategory = await _context.Categories.FindAsync(id);
            if (DeleteCategory == null) return NotFound();

            _context.Categories.Remove(DeleteCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

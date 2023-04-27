using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamMemberFinalProject.Data;

namespace TeamMemberFinalProject.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class FavoriteBreakFastsController : ControllerBase
        {
            private readonly AppDbContext _context;

            public FavoriteBreakFastsController(AppDbContext context)
            {
                _context = context;
            }

            [HttpGet("{id?}")]
            public async Task<ActionResult<IEnumerable<FavoriteBreakFast>>> Get(int? id)
            {
                if (id == null || id == 0)
                {
                    return await _context.FavoriteBreakFasts.Take(5).ToListAsync();
                }

                var favoriteBreakFast = await _context.FavoriteBreakFasts.FindAsync(id);

                if (favoriteBreakFast == null)
                {
                    return NotFound();
                }

                return Ok(favoriteBreakFast);
            }

            [HttpPost]
            public async Task<ActionResult<FavoriteBreakFast>> Post(FavoriteBreakFast favoriteBreakFast)
            {
                _context.FavoriteBreakFasts.Add(favoriteBreakFast);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = favoriteBreakFast.Id }, favoriteBreakFast);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Put(int id, FavoriteBreakFast favoriteBreakFast)
            {
                if (id != favoriteBreakFast.Id)
                {
                    return BadRequest();
                }

                _context.Entry(favoriteBreakFast).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var favoriteBreakFast = await _context.FavoriteBreakFasts.FindAsync(id);

                if (favoriteBreakFast == null)
                {
                    return NotFound();
                }

                _context.FavoriteBreakFasts.Remove(favoriteBreakFast);
                await _context.SaveChangesAsync();

                return NoContent();
            }
        }

}

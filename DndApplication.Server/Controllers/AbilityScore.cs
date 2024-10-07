using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DndApplication.Server.Data; // Ensure the correct namespace for your DbContext
using DndApplication.Server.Models; // Ensure the correct namespace for your model

namespace DndApplication.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbilityScoresController : ControllerBase
    {
        private readonly DndDbContext _context;

        public AbilityScoresController(DndDbContext context)
        {
            _context = context;
        }

        // GET: api/AbilityScores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AbilityScore>>> GetAbilityScores()
        {
            var abilityScores = await _context.AbilityScores.ToListAsync();
            return Ok(abilityScores);
        }

        // GET: api/AbilityScores/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AbilityScore>> GetAbilityScore(int id)
        {
            var abilityScore = await _context.AbilityScores.FindAsync(id);

            if (abilityScore == null)
            {
                return NotFound();
            }

            return Ok(abilityScore);
        }

        // POST: api/AbilityScores
        [HttpPost]
        public async Task<ActionResult<AbilityScore>> CreateAbilityScore(AbilityScore abilityScore)
        {
            if (abilityScore == null)
            {
                return BadRequest("Ability score data is null.");
            }

            // Add new AbilityScore to the database
            _context.AbilityScores.Add(abilityScore);
            await _context.SaveChangesAsync();

            // Return the newly created AbilityScore
            return CreatedAtAction(nameof(GetAbilityScore), new { id = abilityScore.Id }, abilityScore);
        }

        // DELETE: api/AbilityScores/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbilityScore(int id)
        {
            var abilityScore = await _context.AbilityScores.FindAsync(id);

            if (abilityScore == null)
            {
                return NotFound();
            }

            // Remove the AbilityScore from the database
            _context.AbilityScores.Remove(abilityScore);
            await _context.SaveChangesAsync();

            // Return 204 No Content to indicate successful deletion
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DndApplication.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace DndApplication.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly DndDbContext _context;

        public CharactersController(DndDbContext context)
        {
            _context = context;
        }

        // POST: api/Characters
        [HttpPost]
        public async Task<ActionResult<Character>> CreateCharacter(Character character)
        {
            if (character == null)
            {
                return BadRequest("Character data is null.");
            }

            // Add character to the context
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            // Return CreatedAtAction with the character entity
            return CreatedAtAction(nameof(GetCharacter), new { id = character.Id }, character);
        }

        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            return Ok(character);
        }

        // PUT: api/Characters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCharacter(int id, Character character)
        {
            if (id != character.Id)
            {
                return BadRequest("Character ID mismatch.");
            }

            _context.Entry(character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
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

        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
    }
}

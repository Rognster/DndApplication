using DndApplication.Server.Data;
using DndApplication.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DndApplication.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly DndDbContext _context;
        private readonly ILogger<CharacterController> _logger;
        private readonly DnD5eApiService _dndApiService;

        public CharacterController(DndDbContext context, ILogger<CharacterController> logger, DnD5eApiService dndApiService)
        {
            _context = context;
            _logger = logger;
            _dndApiService = dndApiService;
        }

        [HttpGet("{characterId}")]
        public async Task<ActionResult<Character>> GetCharacter(int characterId)
        {
            var character = await _context.Characters
                .Include(c => c.Equipments)
                .FirstOrDefaultAsync(c => c.Id == characterId);

            if (character == null)
            {
                return NotFound();
            }

            return Ok(character);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetAllCharacters()
        {
            var characters = await _context.Characters
                .Include(c => c.Equipments) // Include the equipment list
                .Include(c => c.Stats) // Include stats
                .ToListAsync();

            return Ok(characters);
        }

        [HttpPost]
        public async Task<ActionResult<Character>> AddCharacter(Character character)
        {
            // Validate input (optional, additional validation logic can be added)
            if (character == null || string.IsNullOrEmpty(character.Name))
            {
                return BadRequest("Invalid character data.");
            }

            // Ensure equipments have the correct state set
            if (character.Equipments != null && character.Equipments.Count > 0)
            {
                foreach (var equipment in character.Equipments)
                {
                    // If equipment Id is 0, it's a new equipment that needs to be added
                    if (equipment.Id == 0)
                    {
                        _context.Equipments.Add(equipment);
                    }
                }
            }

            // Add the new character to the database
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            // Return the newly created character
            return CreatedAtAction(nameof(GetCharacter), new { characterId = character.Id }, character);
        }

        [HttpDelete("{characterId}")]
        public async Task<IActionResult> DeleteCharacter(int characterId)
        {
            // Find the character in the database
            var character = await _context.Characters
                .Include(c => c.Equipments) // Include equipments to delete them too
                .FirstOrDefaultAsync(c => c.Id == characterId);

            if (character == null)
            {
                return NotFound(); // Return 404 if character not found
            }

            // Remove the character from the database
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            // Return 204 No Content to indicate successful deletion
            return NoContent();
        }

    }
}

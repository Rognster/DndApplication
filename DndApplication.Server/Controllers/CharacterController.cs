using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DndApplication.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        // Temporary in-memory list of characters
        private static readonly List<CharacterDto> Characters = new List<CharacterDto>
        {
            new CharacterDto { Id = 1, Name = "Aragorn" },
            new CharacterDto { Id = 2, Name = "Legolas" },
            new CharacterDto { Id = 3, Name = "Gimli" }
        };

        // GET: api/Character
        [HttpGet]
        public IActionResult GetAllCharacters()
        {
            return Ok(Characters);
        }

        // GET: api/Character/{id}
        [HttpGet("{id}")]
        public IActionResult GetCharacterById(int id)
        {
            var character = Characters.Find(c => c.Id == id);
            if (character == null)
            {
                return NotFound($"Character with Id {id} not found.");
            }

            return Ok(character);
        }

        // DELETE: api/Character/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCharacter(int id)
        {
            var character = Characters.Find(c => c.Id == id);
            if (character == null)
            {
                return NotFound($"Character with Id {id} not found.");
            }

            Characters.Remove(character);
            return NoContent(); // 204 No Content
        }

        // POST: api/Character
        [HttpPost]
        public IActionResult AddCharacter([FromBody] CharacterDto newCharacter)
        {
            if (newCharacter == null || string.IsNullOrEmpty(newCharacter.Name))
            {
                return BadRequest("Invalid character data.");
            }

            newCharacter.Id = Characters.Count > 0 ? Characters[^1].Id + 1 : 1; // Assign a new ID
            Characters.Add(newCharacter);

            return CreatedAtAction(nameof(GetCharacterById), new { id = newCharacter.Id }, newCharacter);
        }
    }

    // Temporary DTO class for characters
    public class CharacterDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}

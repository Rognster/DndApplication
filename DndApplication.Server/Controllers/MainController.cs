using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DndApplication.Server.Models;
using DndApplication.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace DndApplication.Server.Controllers
{
    [ApiController]
    [Route("api")]
    public class MainController : ControllerBase
    {
        private readonly DndDbContext _context;

        public MainController(DndDbContext context)
        {
            _context = context;
        }

        // Main endpoint that returns links to all resources
        [HttpGet]
        public ActionResult<Dictionary<string, string>> GetResources()
        {
            var resources = new Dictionary<string, string>
            {
                { "characters", "/api/characters" },
                { "equipment", "/api/equipment" },
                { "ability-scores", "/api/ability-scores" },
                { "alignments", "/api/alignments" },
                { "backgrounds", "/api/backgrounds" },
                { "classes", "/api/classes" },
                { "conditions", "/api/conditions" },
                { "damage-types", "/api/damage-types" },
                { "equipment-categories", "/api/equipment-categories" },
                { "feats", "/api/feats" },
                { "features", "/api/features" },
                { "languages", "/api/languages" },
                { "magic-items", "/api/magic-items" },
                { "magic-schools", "/api/magic-schools" },
                { "monsters", "/api/monsters" },
                { "proficiencies", "/api/proficiencies" },
                { "races", "/api/races" },
                { "rule-sections", "/api/rule-sections" },
                { "rules", "/api/rules" },
                { "skills", "/api/skills" },
                { "spells", "/api/spells" },
                { "subclasses", "/api/subclasses" },
                { "subraces", "/api/subraces" },
                { "traits", "/api/traits" },
                { "weapon-properties", "/api/weapon-properties" }
            };

            return Ok(resources);
        }

        // GET: api/characters
        //[HttpGet("characters")]
        //public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        //{
        //    var characters = await _context.Characters.ToListAsync();

        //    if (characters == null || characters.Count == 0)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(characters);
        //}

        /*// GET: api/characters/{id}
        [HttpGet("characters/{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            return Ok(character);
        }*/
    }
}

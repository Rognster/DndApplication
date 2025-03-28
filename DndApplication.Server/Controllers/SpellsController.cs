using DndApplication.Server.Data;
using DndApplication.Server.Dtos;
using DndApplication.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DndApplication.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpellsController : ControllerBase
    {
        private readonly DndDbContext _context;

        public SpellsController(DndDbContext context)
        {
            _context = context;
        }

        // GET: api/spells
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpellDto>>> GetSpells()
        {
            var spells = await _context.Spells
                .Include(s => s.School)
                .Include(s => s.SpellDamages)
                    .ThenInclude(sd => sd.DamageType)
                .Select(s => new SpellDto
                {
                    Id = s.Id,
                    SpellIndex = s.SpellIndex,
                    Name = s.Name,
                    Description = s.Description,
                    HigherLevel = s.HigherLevel,
                    Range = s.Range,
                    Components = s.Components,
                    Material = s.Material,
                    Ritual = s.Ritual,
                    Duration = s.Duration,
                    Concentration = s.Concentration,
                    CastingTime = s.CastingTime,
                    Level = s.Level,
                    School = s.School.Name,
                    Url = s.Url,
                    Damage = s.SpellDamages.Select(d => new SpellDamageDto
                    {
                        DamageType = d.DamageType.Name,
                        DamageAtSlotLevel = d.DamageAtSlotLevel,
                        DamageAtCharacterLevel = d.DamageAtCharacterLevel
                    })
                })
                .ToListAsync();

            return spells;
        }

        // GET: api/spells/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpellDto>> GetSpell(int id)
        {
            var spell = await _context.Spells
                .Include(s => s.School)
                .Include(s => s.SpellDamages)
                    .ThenInclude(sd => sd.DamageType)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (spell == null)
            {
                return NotFound();
            }

            return new SpellDto
            {
                Id = spell.Id,
                SpellIndex = spell.SpellIndex,
                Name = spell.Name,
                Description = spell.Description,
                HigherLevel = spell.HigherLevel,
                Range = spell.Range,
                Components = spell.Components,
                Material = spell.Material,
                Ritual = spell.Ritual,
                Duration = spell.Duration,
                Concentration = spell.Concentration,
                CastingTime = spell.CastingTime,
                Level = spell.Level,
                School = spell.School.Name,
                Url = spell.Url,
                Damage = spell.SpellDamages.Select(d => new SpellDamageDto
                {
                    DamageType = d.DamageType.Name,
                    DamageAtSlotLevel = d.DamageAtSlotLevel,
                    DamageAtCharacterLevel = d.DamageAtCharacterLevel
                })
            };
        }

        // GET: api/spells/level/3
        [HttpGet("level/{level}")]
        public async Task<ActionResult<IEnumerable<SpellDto>>> GetSpellsByLevel(int level)
        {
            if (level < 0 || level > 9)
            {
                return BadRequest("Spell level must be between 0 and 9");
            }

            var spells = await _context.Spells
                .Where(s => s.Level == level)
                .Include(s => s.School)
                .Include(s => s.SpellDamages)
                    .ThenInclude(sd => sd.DamageType)
                .Select(s => new SpellDto
                {
                    Id = s.Id,
                    SpellIndex = s.SpellIndex,
                    Name = s.Name,
                    Description = s.Description,
                    HigherLevel = s.HigherLevel,
                    Range = s.Range,
                    Components = s.Components,
                    Material = s.Material,
                    Ritual = s.Ritual,
                    Duration = s.Duration,
                    Concentration = s.Concentration,
                    CastingTime = s.CastingTime,
                    Level = s.Level,
                    School = s.School.Name,
                    Url = s.Url,
                    Damage = s.SpellDamages.Select(d => new SpellDamageDto
                    {
                        DamageType = d.DamageType.Name,
                        DamageAtSlotLevel = d.DamageAtSlotLevel,
                        DamageAtCharacterLevel = d.DamageAtCharacterLevel
                    })
                })
                .ToListAsync();

            return spells;
        }

        // GET: api/spells/school/evocation
        [HttpGet("school/{schoolName}")]
        public async Task<ActionResult<IEnumerable<SpellDto>>> GetSpellsBySchool(string schoolName)
        {
            var spells = await _context.Spells
                .Include(s => s.School)
                .Include(s => s.SpellDamages)
                    .ThenInclude(sd => sd.DamageType)
                .Where(s => s.School.Name.ToLower() == schoolName.ToLower() || 
                           s.School.Index.ToLower() == schoolName.ToLower())
                .Select(s => new SpellDto
                {
                    Id = s.Id,
                    SpellIndex = s.SpellIndex,
                    Name = s.Name,
                    Description = s.Description,
                    HigherLevel = s.HigherLevel,
                    Range = s.Range,
                    Components = s.Components,
                    Material = s.Material,
                    Ritual = s.Ritual,
                    Duration = s.Duration,
                    Concentration = s.Concentration,
                    CastingTime = s.CastingTime,
                    Level = s.Level,
                    School = s.School.Name,
                    Url = s.Url,
                    Damage = s.SpellDamages.Select(d => new SpellDamageDto
                    {
                        DamageType = d.DamageType.Name,
                        DamageAtSlotLevel = d.DamageAtSlotLevel,
                        DamageAtCharacterLevel = d.DamageAtCharacterLevel
                    })
                })
                .ToListAsync();

            if (!spells.Any())
            {
                return NotFound($"No spells found for school '{schoolName}'");
            }

            return spells;
        }
    }
}

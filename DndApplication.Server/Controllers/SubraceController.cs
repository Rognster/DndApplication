using Microsoft.AspNetCore.Mvc;
using DndApplication.Server.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; // Add this for async/await
using DndApplication.Server.Data;
using Microsoft.EntityFrameworkCore;
using DndApplication.Server.Dtos;

[ApiController]
[Route("api/[controller]")]
public class SubraceController : ControllerBase
{
    private readonly DndDbContext _context;

    public SubraceController(DndDbContext context)
    {
        _context = context;
    }

    // GET: api/Subrace
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubraceDto>>> GetAllSubracees()
    {
        var subraces = await _context.Subraces
            .Select(s => new SubraceDto
            {
                Id = s.Id,
                Index = s.Index,
                RaceIndex = s.Race.Index,
                Name = s.Name,
                Description = s.Description ?? string.Empty
            })
            .ToListAsync();

        return Ok(subraces);
    }

    // GET: api/Subrace/{index}
    [HttpGet("{index}")]
    public async Task<ActionResult<SubraceDto>> GetSubraceaceByIndex(string index)
    {
        var subrace = await _context.Subraces
            .Include(s => s.Race)
            .Where(s => s.Index == index)
            .Select(s => new SubraceDto
            {
                Id = s.Id,
                Index = s.Index,
                RaceIndex = s.Race.Index,
                Name = s.Name,
                Description = s.Description ?? string.Empty
            })
            .FirstOrDefaultAsync();

        if (subrace == null)
        {
            return NotFound($"Subrace with Index '{index}' not found.");
        }

        return Ok(subrace);
    }

    [HttpGet("race/{raceIndex}")]
    public async Task<ActionResult<IEnumerable<SubraceDto>>> GetSubracesByRace(string raceIndex)
    {
        var subraces = await _context.Subraces
            .Include(s => s.Race)
            .Where(s => s.Race.Index == raceIndex)
            .Select(s => new SubraceDto
            {
                Id = s.Id,
                Index = s.Index,
                RaceIndex = s.Race.Index,
                Name = s.Name,
                Description = s.Description ?? string.Empty
            })
            .ToListAsync();

        if (!subraces.Any())
        {
            return NotFound($"No subraces found for race with index '{raceIndex}'.");
        }

        return Ok(subraces);
    }
}

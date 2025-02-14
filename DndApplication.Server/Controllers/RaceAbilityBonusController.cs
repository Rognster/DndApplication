using DndApplication.Server.Data;
using DndApplication.Server.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RaceAbilityBonusController : ControllerBase
{
    private readonly DndDbContext _context;

    public RaceAbilityBonusController(DndDbContext context)
    {
        _context = context;
    }

    // GET: api/RaceAbilityBonuse
    [HttpGet]
    public ActionResult<IEnumerable<RaceAbilityBonus>> GetAllRaceAbilityBonuses()
    {
        var bonuses = _context.RaceAbilityBonuses.ToList(); // Assuming DbSet is named RaceAbilityBonuses
        return Ok(bonuses);
    }

    // GET: api/RaceAbilityBonus/{RaceId}
    [HttpGet("{RaceId}")]
    public ActionResult<IEnumerable<RaceAbilityBonus>> GetRaceAbilityBonusesByRaceId(int RaceId)
    {
        var bonuses = _context.RaceAbilityBonuses
            .Where(b => b.RaceId == RaceId) // Filter by RaceId
            .ToList();

        if (!bonuses.Any())
        {
            return NotFound($"No Race Ability Bonuses found for Race ID '{RaceId}'.");
        }

        return Ok(bonuses);
    }
}
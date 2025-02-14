using DndApplication.Server.Data;
using DndApplication.Server.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RaceAbilityBonusOptionController : ControllerBase
{
    private readonly DndDbContext _context;

    public RaceAbilityBonusOptionController(DndDbContext context)
    {
        _context = context;
    }

    // GET: api/RaceAbilityBonusOption
    [HttpGet]
    public ActionResult<IEnumerable<RaceAbilityBonusOption>> GetAllRaceAbilityBonusOptions()
    {
        var options = _context.RaceAbilityBonusOptions.ToList(); // Assuming DbSet is named RaceAbilityBonusOptions
        return Ok(options);
    }

    // GET: api/RaceAbilityBonusOption/{id}
    [HttpGet("{id}")]
    public ActionResult<RaceAbilityBonusOption> GetRaceAbilityBonusOptionById(int id)
    {
        var option = _context.RaceAbilityBonusOptions
            .FirstOrDefault(o => o.Id == id);

        if (option == null)
        {
            return NotFound($"Race Ability Bonus Option with ID '{id}' not found.");
        }

        return Ok(option);
    }
}

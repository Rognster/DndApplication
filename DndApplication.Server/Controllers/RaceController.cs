using Microsoft.AspNetCore.Mvc;
using DndApplication.Server.Models;
using System.Collections.Generic;
using System.Linq;
using DndApplication.Server.Data;
using Microsoft.EntityFrameworkCore;
using DndApplication.Server.Dtos;

[ApiController]
[Route("api/[controller]")]
public class RaceController : ControllerBase
{
    private readonly DndDbContext _context;

    public RaceController(DndDbContext context)
    {
        _context = context;
    }

    // GET: api/Race
    [HttpGet]
    public ActionResult<IEnumerable<Race>> GetAllRacees()
    {
        var racees = _context.Races.ToList();
        return Ok(racees);
    }

    // GET: api/Race/{index}
    [HttpGet("{index}")]
    public ActionResult<Race> GetRaceByIndex(string index)
    {
        var raceEntity = _context.Races
            .FirstOrDefault(c => c.Index == index); // Use IndexId for filtering

        if (raceEntity == null)
        {
            return NotFound($"Race with Index '{index}' not found.");
        }

        return Ok(raceEntity);
    }
}

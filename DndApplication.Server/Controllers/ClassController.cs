using Microsoft.AspNetCore.Mvc;
using DndApplication.Server.Models;
using System.Collections.Generic;
using System.Linq;
using DndApplication.Server.Data;
using Microsoft.EntityFrameworkCore;
using DndApplication.Server.Dtos;

[ApiController]
[Route("api/[controller]")]
public class ClassController : ControllerBase
{
    private readonly DndDbContext _context;

    public ClassController(DndDbContext context)
    {
        _context = context;
    }

    // GET: api/Class
    [HttpGet]
    public ActionResult<IEnumerable<Class>> GetAllClasses()
    {
        var classes = _context.Classes.ToList();
        return Ok(classes);
    }

    // GET: api/Class/{index}
    [HttpGet("{index}")]
    public ActionResult<Class> GetClassByIndex(string index)
    {
        var classEntity = _context.Classes
            .FirstOrDefault(c => c.IndexId == index); // Use IndexId for filtering

        if (classEntity == null)
        {
            return NotFound($"Class with Index '{index}' not found.");
        }

        return Ok(classEntity);
    }

    [HttpGet("{classId}/levels")]
    public ActionResult<IEnumerable<LevelDto>> GetClassLevels(int classId)
    {
        // Query Levels with related Features
        var levels = _context.Levels
            .Where(l => l.ClassId == classId)
            .Include(l => l.LevelFeatures)
                .ThenInclude(lf => lf.Feature) // Include related Features
            .Select(l => new LevelDto
            {
                Id = l.Id,
                Level1 = l.Level1,
                AbilityScoreBonuses = l.AbilityScoreBonuses,
                ProfBonus = l.ProfBonus,
                Features = l.LevelFeatures.Select(lf => new FeatureDto
                {
                    Id = lf.Feature.Id,
                    Name = lf.Feature.Name,
                    Description = lf.Feature.Description,
                    //Url = lf.Feature.Url
                })
            })
            .ToList();

        if (!levels.Any())
        {
            return NotFound($"No levels found for ClassId {classId}.");
        }

        return Ok(levels);
    }
}

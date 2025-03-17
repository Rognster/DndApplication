using Microsoft.AspNetCore.Mvc;
using DndApplication.Server.Models;
using DndApplication.Server.Data;
using DndApplication.Server.Dtos;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ClassSavingThrowController : ControllerBase
{
    private readonly DndDbContext _context;

    public ClassSavingThrowController(DndDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ClassSavingThrowDto>> GetAllClassSavingThrows()
    {
        var savingThrows = _context.ClassSavingThrows
            .Include(cst => cst.AbilityScoreIndex)
            .Select(cst => new ClassSavingThrowDto
            {
                Id = cst.Id,
                ClassId = cst.ClassId,
                AbilityScoreName = cst.AbilityScoreIndex.Name
            })
            .ToList();

        return Ok(savingThrows);
    }

    [HttpGet("{classId}")]
    public ActionResult<IEnumerable<ClassSavingThrowDto>> GetClassSavingThrowsByClassId(int classId)
    {
        var savingThrows = _context.ClassSavingThrows
            .Where(cst => cst.ClassId == classId) // Filter by ClassId
            .Include(cst => cst.AbilityScoreIndex) // Include related AbilityScore
            .Select(cst => new ClassSavingThrowDto
            {
                Id = cst.Id,
                ClassId = cst.ClassId,
                AbilityScoreName = cst.AbilityScoreIndex.Name // Assuming AbilityScore has a Name property
            })
            .ToList();

        if (!savingThrows.Any())
        {
            return NotFound($"No saving throws found for ClassId {classId}.");
        }

        return Ok(savingThrows);
    }
}

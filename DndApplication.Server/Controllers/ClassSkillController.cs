using Microsoft.AspNetCore.Mvc;
using DndApplication.Server.Models;
using DndApplication.Server.Data;
using DndApplication.Server.Dtos;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ClassSkillController : ControllerBase
{
    private readonly DndDbContext _context;

    public ClassSkillController(DndDbContext context)
    {
        _context = context;
    }

    // GET: api/Skill
    [HttpGet]
    public ActionResult<IEnumerable<ClassSkillsDto>> GetSkillsWithDetails()
    {
        var skills = _context.Skills
        .Include(s => s.ClassProficiencySkills) // Include related ClassProficiencySkills
            .ThenInclude(cps => cps.ProficiencyOption) // Include the related ProficiencyOption
        .Include(s => s.AbilityScoreIndexNavigation) // Include related AbilityScore
        .Select(s => new ClassSkillsDto
        {
            classId = s.ClassProficiencySkills
                .Select(cps => cps.ProficiencyOption.ClassId)
                .FirstOrDefault(), // Safely get the first ClassId
            skillId = s.Id, // Skill ID
            proficiency_option_id = s.ClassProficiencySkills
                .Select(cps => cps.ProficiencyOption.Id)
                .FirstOrDefault(), // Safely get the first ProficiencyOption ID
            SkillIndex = s.SkillIndex, // Skill Index
        })
        .ToList();

            return Ok(skills);
    }

    [HttpGet("{classId}")]
    public ActionResult<IEnumerable<ClassSkillsDto>> GetSkillsByClassId(int classId)
    {
        var skills = _context.Skills
            .Include(s => s.ClassProficiencySkills) // Include related ClassProficiencySkills
                .ThenInclude(cps => cps.ProficiencyOption) // Include ProficiencyOption
            .Where(s => s.ClassProficiencySkills // Filter based on ClassId
                .Any(cps => cps.ProficiencyOption.ClassId == classId))
            .Select(s => new ClassSkillsDto
            {
                classId = classId, // Provided ClassId
                skillId = s.Id, // Skill ID
                proficiency_option_id = s.ClassProficiencySkills
                    .Where(cps => cps.ProficiencyOption.ClassId == classId)
                    .Select(cps => cps.ProficiencyOption.Id)
                    .FirstOrDefault(), // Proficiency Option ID for the specific class
                SkillIndex = s.SkillIndex,
            })
            .ToList();

        if (!skills.Any())
        {
            return NotFound($"No skills found for classId {classId}.");
        }

        return Ok(skills);
    }
}


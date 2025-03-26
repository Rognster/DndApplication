using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DndApplication.Server.Controllers;
using DndApplication.Server.Data;
using DndApplication.Server.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;

namespace DndApplication.Server.Tests.Controllers
{
    public class ClassSkillControllerTests
    {
        [Fact]
        public void GetSkillsWithDetails_ReturnsAllSkills()
        {
            // Test should:
            // 1. Arrange: Set up a mock DbContext with sample skills data
            // 2. Act: Call the GetSkillsWithDetails method
            // 3. Assert: Verify that all skills are returned with correct details
            // 4. Verify: The response is an OkObjectResult with the list of ClassSkillsDto
        }

        [Fact]
        public void GetSkillsByClassId_WhenClassExists_ReturnsClassSkills()
        {
            // Test should:
            // 1. Arrange: Set up a mock DbContext with sample skills data for a specific class
            // 2. Act: Call GetSkillsByClassId with a valid class ID
            // 3. Assert: Verify only skills for that class are returned
            // 4. Verify: The response is an OkObjectResult containing the filtered skills
        }

        [Fact]
        public void GetSkillsByClassId_WhenClassDoesNotExist_ReturnsNotFound()
        {
            // Test should:
            // 1. Arrange: Set up a mock DbContext with no skills data for the requested class ID
            // 2. Act: Call GetSkillsByClassId with a non-existent class ID
            // 3. Assert: Verify NotFoundResult is returned
            // 4. Verify: The response includes a message indicating the class ID was not found
        }
    }
}

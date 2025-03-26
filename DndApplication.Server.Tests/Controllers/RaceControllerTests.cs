using Microsoft.AspNetCore.Mvc;
using DndApplication.Server.Controllers;
using DndApplication.Server.Data;
using DndApplication.Server.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;

namespace DndApplication.Server.Tests.Controllers
{
    public class RaceControllerTests
    {
        [Fact]
        public void GetAllRaces_ReturnsAllRaces()
        {
            // Test should:
            // 1. Arrange: Set up a mock DbContext with sample races data
            // 2. Act: Call the GetAllRacees method
            // 3. Assert: Verify all races are returned
            // 4. Verify: The response is an OkObjectResult containing the list of races
        }

        [Fact]
        public void GetRaceByIndex_WhenRaceExists_ReturnsRace()
        {
            // Test should:
            // 1. Arrange: Set up a mock DbContext with a specific race
            // 2. Act: Call GetRaceByIndex with a valid race index
            // 3. Assert: Verify the specific race is returned
            // 4. Verify: The response is an OkObjectResult containing the race
        }

        [Fact]
        public void GetRaceByIndex_WhenRaceDoesNotExist_ReturnsNotFound()
        {
            // Test should:
            // 1. Arrange: Set up a mock DbContext with no race matching the requested index
            // 2. Act: Call GetRaceByIndex with a non-existent race index
            // 3. Assert: Verify NotFoundResult is returned
            // 4. Verify: The response includes a message indicating the race was not found
        }
    }
}

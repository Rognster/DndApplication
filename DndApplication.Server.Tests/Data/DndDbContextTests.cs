using Microsoft.EntityFrameworkCore;
using DndApplication.Server.Data;
using DndApplication.Server.Models;
using System.Linq;
using Xunit;

namespace DndApplication.Server.Tests.Data
{
    public class DndDbContextTests
    {
        [Fact]
        public void DbContext_ConfiguresRelationshipsCorrectly()
        {
            // Test should:
            // 1. Arrange: Set up an in-memory database
            // 2. Act: Add related entities (e.g., Classes and ClassProficiencies)
            // 3. Assert: Verify relationships are configured correctly
            // 4. Verify: Navigation properties work as expected
        }

        [Fact]
        public void DbContext_EnforcesRequiredProperties()
        {
            // Test should:
            // 1. Arrange: Set up an in-memory database
            // 2. Act: Attempt to save an entity with missing required properties
            // 3. Assert: Verify appropriate exception is thrown
        }
        
        [Fact]
        public void DbContext_AppliesCorrectCascadeDeleteBehavior()
        {
            // Test should:
            // 1. Arrange: Set up an in-memory database with related entities
            // 2. Act: Delete a parent entity
            // 3. Assert: Verify related entities are handled according to configured delete behavior
        }
    }
}

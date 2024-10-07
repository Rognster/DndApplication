using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DndApplication.Server.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string? Index { get; set; }
        public string? Name { get; set; } 
        public string? Url { get; set; } 

    }
}


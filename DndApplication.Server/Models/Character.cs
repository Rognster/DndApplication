using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Character
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string? Nickname { get; set; } // Optional Nickname

    // Additional properties will be added in subsequent steps
}
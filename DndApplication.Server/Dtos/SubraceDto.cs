public class SubraceDto
{
    public int Id { get; set; }
    public string Index { get; set; } = null!;
    public string RaceIndex { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    //public IEnumerable<AbilityScoreIncreaseDto> AbilityScoreIncreases { get; set; } = new List<AbilityScoreIncreaseDto>();
    //public IEnumerable<FeatureDto> Features { get; set; } = new List<FeatureDto>();
}
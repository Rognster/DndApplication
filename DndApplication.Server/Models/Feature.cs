using System;
using System.Collections.Generic;

namespace DndApplication.Server.Models;

public partial class Feature
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int ClassId { get; set; }

    public int? SubclassId { get; set; }

    public int Level { get; set; }

    public string Description { get; set; } = null!;

    public string? Prerequisites { get; set; }

    public string Url { get; set; } = null!;

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<FeatureMapping> FeatureMappingChildFeatures { get; set; } = new List<FeatureMapping>();

    public virtual ICollection<FeatureMapping> FeatureMappingParentFeatures { get; set; } = new List<FeatureMapping>();

    public virtual ICollection<FeatureSpecific> FeatureSpecifics { get; set; } = new List<FeatureSpecific>();

    public virtual ICollection<LevelFeature> LevelFeatures { get; set; } = new List<LevelFeature>();

    public virtual Subclass? Subclass { get; set; }
}

using System;
using System.Collections.Generic;
using DndApplication.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DndApplication.Server.Data;

public partial class DndDbContext : DbContext
{
    public DndDbContext()
    {
    }

    public DndDbContext(DbContextOptions<DndDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AbilityScore> AbilityScores { get; set; }

    public virtual DbSet<Alignment> Alignments { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassProficiency> ClassProficiencies { get; set; }

    public virtual DbSet<ClassProficiencyOption> ClassProficiencyOptions { get; set; }

    public virtual DbSet<ClassProficiencySkill> ClassProficiencySkills { get; set; }

    public virtual DbSet<ClassSavingThrow> ClassSavingThrows { get; set; }

    public virtual DbSet<ClassSpecific> ClassSpecifics { get; set; }

    public virtual DbSet<Condition> Conditions { get; set; }

    public virtual DbSet<ConditionDescription> ConditionDescriptions { get; set; }

    public virtual DbSet<DamageType> DamageTypes { get; set; }

    public virtual DbSet<DamageTypeDescription> DamageTypeDescriptions { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<EquipmentCategory> EquipmentCategories { get; set; }

    public virtual DbSet<EquipmentOptionDetail> EquipmentOptionDetails { get; set; }

    public virtual DbSet<Feat> Feats { get; set; }

    public virtual DbSet<FeatDescription> FeatDescriptions { get; set; }

    public virtual DbSet<Feature> Features { get; set; }

    public virtual DbSet<FeatureMapping> FeatureMappings { get; set; }

    public virtual DbSet<FeatureSpecific> FeatureSpecifics { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<LanguageDescription> LanguageDescriptions { get; set; }

    public virtual DbSet<Level> Levels { get; set; }

    public virtual DbSet<LevelFeature> LevelFeatures { get; set; }

    public virtual DbSet<MagicItem> MagicItems { get; set; }

    public virtual DbSet<MagicItemVariant> MagicItemVariants { get; set; }

    public virtual DbSet<MagicSchool> MagicSchools { get; set; }

    public virtual DbSet<Monster> Monsters { get; set; }

    public virtual DbSet<MonsterSavingThrow> MonsterSavingThrows { get; set; }

    public virtual DbSet<MonsterSkill> MonsterSkills { get; set; }

    public virtual DbSet<MultiClassing> MultiClassings { get; set; }

    public virtual DbSet<MultiClassingProficiency> MultiClassingProficiencies { get; set; }

    public virtual DbSet<Prerequisite> Prerequisites { get; set; }

    public virtual DbSet<Proficiency> Proficiencies { get; set; }

    public virtual DbSet<Race> Races { get; set; }

    public virtual DbSet<RaceAbilityBonusOption> RaceAbilityBonusOptions { get; set; }

    public virtual DbSet<RaceAbilityBonus> RaceAbilityBonuses { get; set; }

    public virtual DbSet<RaceLanguage> RaceLanguages { get; set; }

    public virtual DbSet<RaceLanguageOption> RaceLanguageOptions { get; set; }

    public virtual DbSet<RaceProficiency> RaceProficiencies { get; set; }

    public virtual DbSet<RaceProficiencyOption> RaceProficiencyOptions { get; set; }

    public virtual DbSet<RaceSkill> RaceSkills { get; set; }

    public virtual DbSet<RaceTrait> RaceTraits { get; set; }

    public virtual DbSet<Rule> Rules { get; set; }

    public virtual DbSet<RuleSection> RuleSections { get; set; }

    public virtual DbSet<RuleSubsection> RuleSubsections { get; set; }

    public virtual DbSet<SavingThrow> SavingThrows { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Spell> Spells { get; set; }

    public virtual DbSet<SpellDamage> SpellDamages { get; set; }

    public virtual DbSet<SpellcastingLevel> SpellcastingLevels { get; set; }

    public virtual DbSet<StartingEquipment> StartingEquipments { get; set; }

    public virtual DbSet<StartingEquipmentOption> StartingEquipmentOptions { get; set; }

    public virtual DbSet<StartingEquipmentOptionDetail> StartingEquipmentOptionDetails { get; set; }

    public virtual DbSet<Subclass> Subclasses { get; set; }

    public virtual DbSet<Subrace> Subraces { get; set; }

    public virtual DbSet<SubraceProficiency> SubraceProficiencies { get; set; }

    public virtual DbSet<SubraceTrait> SubraceTraits { get; set; }

    public virtual DbSet<Trait> Traits { get; set; }

    public virtual DbSet<TypicalSpeaker> TypicalSpeakers { get; set; }

    public virtual DbSet<WeaponProperty> WeaponProperties { get; set; }

    public virtual DbSet<WeaponPropertyDescription> WeaponPropertyDescriptions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PC-5CG4192ZQR;Database=DnDdb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AbilityScore>(entity =>
        {
            entity.HasKey(e => e.IndexId).HasName("PK__AbilityS__9D4F318729A709A1");

            entity.Property(e => e.IndexId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("index_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("full_name");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<Alignment>(entity =>
        {
            entity.HasKey(e => e.IndexId).HasName("PK__Alignmen__9D4F31871EDD08B0");

            entity.Property(e => e.IndexId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("index_id");
            entity.Property(e => e.Abbreviation)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("abbreviation");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Classes__3213E83FAD6DA1C9");

            entity.HasIndex(e => e.IndexId, "UQ__Classes__9D4F318634CF9A83").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassLevelsUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("class_levels_url");
            entity.Property(e => e.HitDie).HasColumnName("hit_die");
            entity.Property(e => e.IndexId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("index_id");
            entity.Property(e => e.MultiClassingPrerequisite)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("multi_classing_prerequisite");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<ClassProficiency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClassPro__3213E83F712C3590");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.ProficiencyId).HasColumnName("proficiency_id");
            entity.Property(e => e.ProficiencyUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("proficiency_url");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassProficiencies)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK_ClassProficiencies_Classes");

            entity.HasOne(d => d.Proficiency).WithMany(p => p.ClassProficiencies)
                .HasForeignKey(d => d.ProficiencyId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ClassProficiencies_Proficiencies");
        });

        modelBuilder.Entity<ClassProficiencyOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClassPro__3213E83FDFFA5D52");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Choose).HasColumnName("choose");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.Description).HasColumnName("description");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassProficiencyOptions)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClassProf__class__2E70E1FD");
        });

        modelBuilder.Entity<ClassProficiencySkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClassPro__3213E83F6B7C7EEA");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProficiencyOptionId).HasColumnName("proficiency_option_id");
            entity.Property(e => e.SkillId).HasColumnName("skill_id");

            entity.HasOne(d => d.ProficiencyOption).WithMany(p => p.ClassProficiencySkills)
                .HasForeignKey(d => d.ProficiencyOptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClassProf__profi__314D4EA8");

            entity.HasOne(d => d.Skill).WithMany(p => p.ClassProficiencySkills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClassProf__skill__324172E1");
        });

        modelBuilder.Entity<ClassSavingThrow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClassSav__3213E83F3229C81A");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AbilityScoreIndexId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ability_score_index_id");
            entity.Property(e => e.ClassId).HasColumnName("class_id");

            entity.HasOne(d => d.AbilityScoreIndex).WithMany(p => p.ClassSavingThrows)
                .HasForeignKey(d => d.AbilityScoreIndexId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClassSavi__abili__2B947552");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassSavingThrows)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClassSavi__class__2AA05119");
        });

        modelBuilder.Entity<ClassSpecific>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClassSpe__3213E83F6129B4DC");

            entity.ToTable("ClassSpecific");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.KeyName)
                .HasMaxLength(255)
                .HasColumnName("key_name");
            entity.Property(e => e.LevelId).HasColumnName("level_id");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.Level).WithMany(p => p.ClassSpecifics)
                .HasForeignKey(d => d.LevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClassSpec__level__0880433F");
        });

        modelBuilder.Entity<Condition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Conditio__3213E83FCD111D6A");

            entity.HasIndex(e => e.Index, "UQ__Conditio__1D0A3349F1C5474D").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Index)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("index");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<ConditionDescription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Conditio__3213E83FA853233A");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConditionId).HasColumnName("condition_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");

            entity.HasOne(d => d.Condition).WithMany(p => p.ConditionDescriptions)
                .HasForeignKey(d => d.ConditionId)
                .HasConstraintName("FK__Condition__condi__6EF57B66");
        });

        modelBuilder.Entity<DamageType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DamageTy__3213E83FF4C16FE5");

            entity.HasIndex(e => e.Index, "UQ__DamageTy__1D0A334992AE3213").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Index)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("index");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<DamageTypeDescription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DamageTy__3213E83F2640B6BB");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DamageTypeId).HasColumnName("damage_type_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");

            entity.HasOne(d => d.DamageType).WithMany(p => p.DamageTypeDescriptions)
                .HasForeignKey(d => d.DamageTypeId)
                .HasConstraintName("FK__DamageTyp__damag__74AE54BC");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Equipmen__3213E83FC4221F2D");

            entity.HasIndex(e => e.Index, "UQ__Equipmen__1D0A3349D8BA21DB").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryRange)
                .HasMaxLength(255)
                .HasColumnName("category_range");
            entity.Property(e => e.CostQuantity).HasColumnName("cost_quantity");
            entity.Property(e => e.CostUnit)
                .HasMaxLength(50)
                .HasColumnName("cost_unit");
            entity.Property(e => e.DamageDice)
                .HasMaxLength(50)
                .HasColumnName("damage_dice");
            entity.Property(e => e.DamageType)
                .HasMaxLength(255)
                .HasColumnName("damage_type");
            entity.Property(e => e.EquipmentCategoryId).HasColumnName("equipment_category_id");
            entity.Property(e => e.Index)
                .HasMaxLength(255)
                .HasColumnName("index");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.RangeLong).HasColumnName("range_long");
            entity.Property(e => e.RangeNormal).HasColumnName("range_normal");
            entity.Property(e => e.Url).HasColumnName("url");
            entity.Property(e => e.WeaponCategory)
                .HasMaxLength(255)
                .HasColumnName("weapon_category");
            entity.Property(e => e.WeaponRange)
                .HasMaxLength(255)
                .HasColumnName("weapon_range");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasMany(d => d.Properties).WithMany(p => p.Equipment)
                .UsingEntity<Dictionary<string, object>>(
                    "EquipmentWeaponProperty",
                    r => r.HasOne<WeaponProperty>().WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Equipment__prope__2B0A656D"),
                    l => l.HasOne<Equipment>().WithMany()
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Equipment__equip__2A164134"),
                    j =>
                    {
                        j.HasKey("EquipmentId", "PropertyId").HasName("PK__Equipmen__3E45D2E96147F9B4");
                        j.ToTable("EquipmentWeaponProperties");
                        j.IndexerProperty<int>("EquipmentId").HasColumnName("equipment_id");
                        j.IndexerProperty<int>("PropertyId").HasColumnName("property_id");
                    });
        });

        modelBuilder.Entity<EquipmentCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Equipmen__3213E83FF57F1ED0");

            entity.HasIndex(e => e.Index, "UQ__Equipmen__1D0A3349B29AFA83").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Index)
                .HasMaxLength(255)
                .HasColumnName("index");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Url).HasColumnName("url");

            entity.HasMany(d => d.Equipment).WithMany(p => p.Categories)
                .UsingEntity<Dictionary<string, object>>(
                    "EquipmentCategoryMapping",
                    r => r.HasOne<Equipment>().WithMany()
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Equipment__equip__25518C17"),
                    l => l.HasOne<EquipmentCategory>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Equipment__categ__245D67DE"),
                    j =>
                    {
                        j.HasKey("CategoryId", "EquipmentId").HasName("PK__Equipmen__34D9EF3EB3E80B6E");
                        j.ToTable("EquipmentCategoryMapping");
                        j.IndexerProperty<int>("CategoryId").HasColumnName("category_id");
                        j.IndexerProperty<int>("EquipmentId").HasColumnName("equipment_id");
                    });
        });

        modelBuilder.Entity<EquipmentOptionDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Equipmen__3213E83FBCC62FD5");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ItemIndex)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("item_index");
            entity.Property(e => e.ItemName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("item_name");
            entity.Property(e => e.ItemUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("item_url");
            entity.Property(e => e.OptionId).HasColumnName("option_id");
            entity.Property(e => e.OptionType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("option_type");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Option).WithMany(p => p.EquipmentOptionDetails)
                .HasForeignKey(d => d.OptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Equipment__optio__534D60F1");
        });

        modelBuilder.Entity<Feat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Feats__3213E83F71E1D1FC");

            entity.HasIndex(e => e.Index, "UQ__Feats__1D0A33494677D813").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Index)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("index");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<FeatDescription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FeatDesc__3213E83F0A6E1A50");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.FeatId).HasColumnName("feat_id");

            entity.HasOne(d => d.Feat).WithMany(p => p.FeatDescriptions)
                .HasForeignKey(d => d.FeatId)
                .HasConstraintName("FK__FeatDescr__feat___7D439ABD");
        });

        modelBuilder.Entity<Feature>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Features__3213E83F2C3D4B42");

            entity.HasIndex(e => e.Index, "UQ__Features__1D0A3349FA107840").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Index)
                .HasMaxLength(255)
                .HasColumnName("index");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Prerequisites).HasColumnName("prerequisites");
            entity.Property(e => e.SubclassId).HasColumnName("subclass_id");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");

            entity.HasOne(d => d.Class).WithMany(p => p.Features)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Features__class___3D2915A8");

            entity.HasOne(d => d.Subclass).WithMany(p => p.Features)
                .HasForeignKey(d => d.SubclassId)
                .HasConstraintName("FK__Features__subcla__3E1D39E1");
        });

        modelBuilder.Entity<FeatureMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FeatureM__3213E83F3E6F8DDB");

            entity.ToTable("FeatureMapping");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChildFeatureId).HasColumnName("child_feature_id");
            entity.Property(e => e.ParentFeatureId).HasColumnName("parent_feature_id");

            entity.HasOne(d => d.ChildFeature).WithMany(p => p.FeatureMappingChildFeatures)
                .HasForeignKey(d => d.ChildFeatureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FeatureMa__child__44CA3770");

            entity.HasOne(d => d.ParentFeature).WithMany(p => p.FeatureMappingParentFeatures)
                .HasForeignKey(d => d.ParentFeatureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FeatureMa__paren__43D61337");
        });

        modelBuilder.Entity<FeatureSpecific>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FeatureS__3213E83F2F52D4FC");

            entity.ToTable("FeatureSpecific");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Choose).HasColumnName("choose");
            entity.Property(e => e.FeatureId).HasColumnName("feature_id");
            entity.Property(e => e.OptionType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("option_type");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasOne(d => d.Feature).WithMany(p => p.FeatureSpecifics)
                .HasForeignKey(d => d.FeatureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FeatureSp__featu__351DDF8C");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Language__3213E83F4611BF43");

            entity.HasIndex(e => e.Index, "UQ__Language__1D0A3349583A369B").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Index)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("index");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Script)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("script");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<LanguageDescription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Language__3213E83F92663F95");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");

            entity.HasOne(d => d.Language).WithMany(p => p.LanguageDescriptions)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK__LanguageD__langu__02FC7413");
        });

        modelBuilder.Entity<Level>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Levels__3213E83FEC945C6F");

            entity.HasIndex(e => e.Index, "UQ__Levels__1D0A334956F42AB2").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AbilityScoreBonuses).HasColumnName("ability_score_bonuses");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.Index)
                .HasMaxLength(255)
                .HasColumnName("index");
            entity.Property(e => e.Level1).HasColumnName("level");
            entity.Property(e => e.ProfBonus).HasColumnName("prof_bonus");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");

            entity.HasOne(d => d.Class).WithMany(p => p.Levels)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Levels__class_id__7EF6D905");
        });

        modelBuilder.Entity<LevelFeature>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LevelFea__3213E83F8D706C77");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FeatureId).HasColumnName("feature_id");
            entity.Property(e => e.LevelId).HasColumnName("level_id");

            entity.HasOne(d => d.Feature).WithMany(p => p.LevelFeatures)
                .HasForeignKey(d => d.FeatureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LevelFeat__featu__02C769E9");

            entity.HasOne(d => d.Level).WithMany(p => p.LevelFeatures)
                .HasForeignKey(d => d.LevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LevelFeat__level__01D345B0");
        });

        modelBuilder.Entity<MagicItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MagicIte__3213E83F778E0DE8");

            entity.HasIndex(e => e.Index, "UQ__MagicIte__1D0A33498893050F").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EquipmentCategoryId).HasColumnName("equipment_category_id");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.Index)
                .HasMaxLength(255)
                .HasColumnName("index");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Rarity)
                .HasMaxLength(255)
                .HasColumnName("rarity");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");
            entity.Property(e => e.Variant).HasColumnName("variant");

            entity.HasOne(d => d.EquipmentCategory).WithMany(p => p.MagicItems)
                .HasForeignKey(d => d.EquipmentCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MagicItem__equip__0C50D423");
        });

        modelBuilder.Entity<MagicItemVariant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MagicIte__3213E83F5011EC35");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ParentMagicItemId).HasColumnName("parent_magic_item_id");
            entity.Property(e => e.VariantMagicItemId).HasColumnName("variant_magic_item_id");

            entity.HasOne(d => d.ParentMagicItem).WithMany(p => p.MagicItemVariantParentMagicItems)
                .HasForeignKey(d => d.ParentMagicItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MagicItem__paren__0F2D40CE");

            entity.HasOne(d => d.VariantMagicItem).WithMany(p => p.MagicItemVariantVariantMagicItems)
                .HasForeignKey(d => d.VariantMagicItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MagicItem__varia__10216507");
        });

        modelBuilder.Entity<MagicSchool>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MagicSch__3213E83F9D5A3018");

            entity.HasIndex(e => e.Index, "UQ__MagicSch__1D0A3349EB6ADAC7").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Index)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("index");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<Monster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Monsters__3213E83FD757853C");

            entity.HasIndex(e => e.Index, "UQ__Monsters__1D0A33492E50A0BC").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Actions).HasColumnName("actions");
            entity.Property(e => e.Alignment)
                .HasMaxLength(50)
                .HasColumnName("alignment");
            entity.Property(e => e.AlignmentId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("alignment_id");
            entity.Property(e => e.ArmorClass).HasColumnName("armor_class");
            entity.Property(e => e.ChallengeRating).HasColumnName("challenge_rating");
            entity.Property(e => e.Charisma).HasColumnName("charisma");
            entity.Property(e => e.Constitution).HasColumnName("constitution");
            entity.Property(e => e.Dexterity).HasColumnName("dexterity");
            entity.Property(e => e.HitDice)
                .HasMaxLength(50)
                .HasColumnName("hit_dice");
            entity.Property(e => e.HitPoints).HasColumnName("hit_points");
            entity.Property(e => e.HitPointsRoll)
                .HasMaxLength(50)
                .HasColumnName("hit_points_roll");
            entity.Property(e => e.Index)
                .HasMaxLength(255)
                .HasColumnName("index");
            entity.Property(e => e.Intelligence).HasColumnName("intelligence");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.ProficiencyBonus).HasColumnName("proficiency_bonus");
            entity.Property(e => e.Size)
                .HasMaxLength(50)
                .HasColumnName("size");
            entity.Property(e => e.SpecialAbilities).HasColumnName("special_abilities");
            entity.Property(e => e.Speed).HasColumnName("speed");
            entity.Property(e => e.Strength).HasColumnName("strength");
            entity.Property(e => e.Subtype)
                .HasMaxLength(100)
                .HasColumnName("subtype");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .HasColumnName("type");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");
            entity.Property(e => e.Wisdom).HasColumnName("wisdom");
            entity.Property(e => e.Xp).HasColumnName("xp");

            entity.HasOne(d => d.AlignmentNavigation).WithMany(p => p.Monsters)
                .HasForeignKey(d => d.AlignmentId)
                .HasConstraintName("FK__Monsters__alignm__308E3499");

            entity.HasMany(d => d.Languages).WithMany(p => p.Monsters)
                .UsingEntity<Dictionary<string, object>>(
                    "MonsterLanguage",
                    r => r.HasOne<Language>().WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__MonsterLa__langu__345EC57D"),
                    l => l.HasOne<Monster>().WithMany()
                        .HasForeignKey("MonsterId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__MonsterLa__monst__336AA144"),
                    j =>
                    {
                        j.HasKey("MonsterId", "LanguageId").HasName("PK__MonsterL__22658A3D5A328B90");
                        j.ToTable("MonsterLanguages");
                        j.IndexerProperty<int>("MonsterId").HasColumnName("monster_id");
                        j.IndexerProperty<int>("LanguageId").HasColumnName("language_id");
                    });
        });

        modelBuilder.Entity<MonsterSavingThrow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MonsterS__3213E83F3AD15B00");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AbilityScoreIndexId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ability_score_index_id");
            entity.Property(e => e.MonsterId).HasColumnName("monster_id");
            entity.Property(e => e.SavingThrowValue).HasColumnName("saving_throw_value");

            entity.HasOne(d => d.AbilityScoreIndex).WithMany(p => p.MonsterSavingThrows)
                .HasForeignKey(d => d.AbilityScoreIndexId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MonsterSa__abili__1B5E0D89");

            entity.HasOne(d => d.Monster).WithMany(p => p.MonsterSavingThrows)
                .HasForeignKey(d => d.MonsterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MonsterSa__monst__1A69E950");
        });

        modelBuilder.Entity<MonsterSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MonsterS__3213E83FA981BFAD");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MonsterId).HasColumnName("monster_id");
            entity.Property(e => e.SkillId).HasColumnName("skill_id");
            entity.Property(e => e.SkillValue).HasColumnName("skill_value");

            entity.HasOne(d => d.Monster).WithMany(p => p.MonsterSkills)
                .HasForeignKey(d => d.MonsterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MonsterSk__monst__12C8C788");

            entity.HasOne(d => d.Skill).WithMany(p => p.MonsterSkills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MonsterSk__skill__13BCEBC1");
        });

        modelBuilder.Entity<MultiClassing>(entity =>
        {
            entity.HasKey(e => new { e.ClassId, e.AbilityScoreIndex }).HasName("PK__MultiCla__1A733C0DA6665F78");

            entity.ToTable("MultiClassing");

            entity.HasIndex(e => e.ClassId, "idx_class_id");

            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.AbilityScoreIndex)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ability_score_index");
            entity.Property(e => e.AbilityScoreName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ability_score_name");
            entity.Property(e => e.MinimumScore).HasColumnName("minimum_score");

            entity.HasOne(d => d.Class).WithMany(p => p.MultiClassings)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MultiClas__class__6477ECF3");
        });

        modelBuilder.Entity<MultiClassingProficiency>(entity =>
        {
            entity.HasKey(e => new { e.ClassId, e.ProficiencyIndex }).HasName("PK__MultiCla__ED438DE380ABFCCA");

            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.ProficiencyIndex)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("proficiency_index");
            entity.Property(e => e.ProficiencyName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("proficiency_name");
            entity.Property(e => e.ProficiencyUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("proficiency_url");

            entity.HasOne(d => d.Class).WithMany(p => p.MultiClassingProficiencies)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MultiClas__class__6754599E");
        });

        modelBuilder.Entity<Prerequisite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Prerequi__3213E83F6EFE01A0");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AbilityScoreIndex)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ability_score_index");
            entity.Property(e => e.AbilityScoreName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ability_score_name");
            entity.Property(e => e.AbilityScoreUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ability_score_url");
            entity.Property(e => e.FeatId).HasColumnName("feat_id");
            entity.Property(e => e.MinimumScore).HasColumnName("minimum_score");

            entity.HasOne(d => d.Feat).WithMany(p => p.Prerequisites)
                .HasForeignKey(d => d.FeatId)
                .HasConstraintName("FK__Prerequis__feat___7A672E12");
        });

        modelBuilder.Entity<Proficiency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proficie__3213E83FC15218A7");

            entity.HasIndex(e => e.Index, "UQ__Proficie__1D0A334917040049").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Index)
                .HasMaxLength(255)
                .HasColumnName("index");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.ReferenceIndex)
                .HasMaxLength(255)
                .HasColumnName("reference_index");
            entity.Property(e => e.ReferenceName)
                .HasMaxLength(255)
                .HasColumnName("reference_name");
            entity.Property(e => e.ReferenceUrl)
                .HasMaxLength(255)
                .HasColumnName("reference_url");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Races__3213E83F8A77E699");

            entity.HasIndex(e => e.Index, "UQ__Races__1D0A334981DBFAC3").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Alignment).HasColumnName("alignment");
            entity.Property(e => e.Index)
                .HasMaxLength(255)
                .HasColumnName("index");
            entity.Property(e => e.LanguageDesc).HasColumnName("language_desc");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Size)
                .HasMaxLength(50)
                .HasColumnName("size");
            entity.Property(e => e.SizeDescription).HasColumnName("size_description");
            entity.Property(e => e.Speed).HasColumnName("speed");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");
        });

        modelBuilder.Entity<RaceAbilityBonusOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RaceAbil__3213E83F374B630D");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AbilityScoreIndex)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ability_score_index");
            entity.Property(e => e.Bonus).HasColumnName("bonus");
            entity.Property(e => e.RaceId).HasColumnName("race_id");

            entity.HasOne(d => d.Race).WithMany(p => p.RaceAbilityBonusOptions)
                .HasForeignKey(d => d.RaceId)
                .HasConstraintName("FK__RaceAbili__race___5D60DB10");
        });

        modelBuilder.Entity<RaceAbilityBonus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AbilityB__3213E83F87ED82D1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AbilityScoreId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ability_score_id");
            entity.Property(e => e.Bonus).HasColumnName("bonus");
            entity.Property(e => e.RaceId).HasColumnName("race_id");

            entity.HasOne(d => d.AbilityScore).WithMany(p => p.RaceAbilityBonuses)
                .HasForeignKey(d => d.AbilityScoreId)
                .HasConstraintName("FK__AbilityBo__abili__6225902D");

            entity.HasOne(d => d.Race).WithMany(p => p.RaceAbilityBonuses)
                .HasForeignKey(d => d.RaceId)
                .HasConstraintName("FK__AbilityBo__race___61316BF4");
        });

        modelBuilder.Entity<RaceLanguage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RaceLang__3213E83F7DA058A1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.RaceId).HasColumnName("race_id");

            entity.HasOne(d => d.Language).WithMany(p => p.RaceLanguages)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RaceLangu__langu__7B264821");

            entity.HasOne(d => d.Race).WithMany(p => p.RaceLanguages)
                .HasForeignKey(d => d.RaceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RaceLangu__race___7A3223E8");
        });

        modelBuilder.Entity<RaceLanguageOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RaceLang__3213E83F797A9F5B");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Choose).HasColumnName("choose");
            entity.Property(e => e.RaceId).HasColumnName("race_id");

            entity.HasOne(d => d.Race).WithMany(p => p.RaceLanguageOptions)
                .HasForeignKey(d => d.RaceId)
                .HasConstraintName("FK__RaceLangu__race___4F12BBB9");
        });

        modelBuilder.Entity<RaceProficiency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RaceProf__3213E83F0F109E4D");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProficiencyId).HasColumnName("proficiency_id");
            entity.Property(e => e.RaceId).HasColumnName("race_id");

            entity.HasOne(d => d.Proficiency).WithMany(p => p.RaceProficiencies)
                .HasForeignKey(d => d.ProficiencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RaceProfi__profi__7755B73D");

            entity.HasOne(d => d.Race).WithMany(p => p.RaceProficiencies)
                .HasForeignKey(d => d.RaceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RaceProfi__race___76619304");
        });

        modelBuilder.Entity<RaceProficiencyOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RaceProf__3213E83F3F400C4B");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Choose).HasColumnName("choose");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.RaceId).HasColumnName("race_id");

            entity.HasOne(d => d.Race).WithMany(p => p.RaceProficiencyOptions)
                .HasForeignKey(d => d.RaceId)
                .HasConstraintName("FK__RaceProfi__race___4C364F0E");
        });

        modelBuilder.Entity<RaceSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RaceSkil__3213E83F28188565");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.SkillId).HasColumnName("skill_id");

            entity.HasOne(d => d.Race).WithMany(p => p.RaceSkills)
                .HasForeignKey(d => d.RaceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RaceSkill__race___1E3A7A34");

            entity.HasOne(d => d.Skill).WithMany(p => p.RaceSkills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RaceSkill__skill__1F2E9E6D");
        });

        modelBuilder.Entity<RaceTrait>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RaceTrai__3213E83FA0706356");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.TraitId).HasColumnName("trait_id");

            entity.HasOne(d => d.Race).WithMany(p => p.RaceTraits)
                .HasForeignKey(d => d.RaceId)
                .HasConstraintName("FK__RaceTrait__race___42ACE4D4");

            entity.HasOne(d => d.Trait).WithMany(p => p.RaceTraits)
                .HasForeignKey(d => d.TraitId)
                .HasConstraintName("FK__RaceTrait__trait__43A1090D");
        });

        modelBuilder.Entity<Rule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rules__3213E83F49DF1FF6");

            entity.HasIndex(e => e.Index, "UQ__Rules__1D0A334927379A34").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Index)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("index");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<RuleSection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RuleSect__3213E83FDBE32405");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.RuleIndex)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("rule_index");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");
        });

        modelBuilder.Entity<RuleSubsection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RuleSubs__3213E83F9140E269");

            entity.HasIndex(e => e.Index, "UQ__RuleSubs__1D0A334966152D62").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Index)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("index");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.RuleId).HasColumnName("rule_id");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("url");

            entity.HasOne(d => d.Rule).WithMany(p => p.RuleSubsections)
                .HasForeignKey(d => d.RuleId)
                .HasConstraintName("FK__RuleSubse__rule___0F624AF8");
        });

        modelBuilder.Entity<SavingThrow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SavingTh__3213E83F89B2841C");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AbilityScoreIndex)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ability_score_index");
            entity.Property(e => e.AbilityScoreName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ability_score_name");
            entity.Property(e => e.AbilityScoreUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ability_score_url");
            entity.Property(e => e.ClassId).HasColumnName("class_id");

            entity.HasOne(d => d.Class).WithMany(p => p.SavingThrows)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SavingThr__class__5629CD9C");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skills__3213E83FD3D3C617");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AbilityScoreIndex)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ability_score_index");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.SkillIndex)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("skill_index");
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("url");

            entity.HasOne(d => d.AbilityScoreIndexNavigation).WithMany(p => p.Skills)
                .HasForeignKey(d => d.AbilityScoreIndex)
                .HasConstraintName("FK__Skills__ability___3D5E1FD2");
        });

        modelBuilder.Entity<Spell>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Spells__3213E83F45803952");

            entity.HasIndex(e => e.SpellIndex, "UQ__Spells__53E0354FD521263A").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CastingTime)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("casting_time");
            entity.Property(e => e.Components)
                .HasMaxLength(50)
                .HasColumnName("components");
            entity.Property(e => e.Concentration).HasColumnName("concentration");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duration)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("duration");
            entity.Property(e => e.HigherLevel).HasColumnName("higher_level");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Material).HasColumnName("material");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Range)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("range");
            entity.Property(e => e.Ritual).HasColumnName("ritual");
            entity.Property(e => e.SchoolId).HasColumnName("school_id");
            entity.Property(e => e.SpellIndex)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("spell_index");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("url");

            entity.HasOne(d => d.School).WithMany(p => p.Spells)
                .HasForeignKey(d => d.SchoolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Spells__school_i__69C6B1F5");
        });

        modelBuilder.Entity<SpellDamage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SpellDam__3213E83FFA3E19A5");

            entity.ToTable("SpellDamage");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DamageAtCharacterLevel).HasColumnName("damage_at_character_level");
            entity.Property(e => e.DamageAtSlotLevel).HasColumnName("damage_at_slot_level");
            entity.Property(e => e.DamageTypeId).HasColumnName("damage_type_id");
            entity.Property(e => e.SpellId).HasColumnName("spell_id");

            entity.HasOne(d => d.DamageType).WithMany(p => p.SpellDamages)
                .HasForeignKey(d => d.DamageTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SpellDama__damag__7167D3BD");

            entity.HasOne(d => d.Spell).WithMany(p => p.SpellDamages)
                .HasForeignKey(d => d.SpellId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SpellDama__spell__7073AF84");
        });

        modelBuilder.Entity<SpellcastingLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Spellcas__3213E83F8ACABABB");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CantripsKnown).HasColumnName("cantrips_known");
            entity.Property(e => e.LevelId).HasColumnName("level_id");
            entity.Property(e => e.SpellSlotsLevel1).HasColumnName("spell_slots_level_1");
            entity.Property(e => e.SpellSlotsLevel2).HasColumnName("spell_slots_level_2");
            entity.Property(e => e.SpellSlotsLevel3).HasColumnName("spell_slots_level_3");
            entity.Property(e => e.SpellSlotsLevel4).HasColumnName("spell_slots_level_4");
            entity.Property(e => e.SpellSlotsLevel5).HasColumnName("spell_slots_level_5");
            entity.Property(e => e.SpellSlotsLevel6).HasColumnName("spell_slots_level_6");
            entity.Property(e => e.SpellSlotsLevel7).HasColumnName("spell_slots_level_7");
            entity.Property(e => e.SpellSlotsLevel8).HasColumnName("spell_slots_level_8");
            entity.Property(e => e.SpellSlotsLevel9).HasColumnName("spell_slots_level_9");
            entity.Property(e => e.SpellsKnown).HasColumnName("spells_known");

            entity.HasOne(d => d.Level).WithMany(p => p.SpellcastingLevels)
                .HasForeignKey(d => d.LevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Spellcast__level__05A3D694");
        });

        modelBuilder.Entity<StartingEquipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Starting__3213E83F9C202D8D");

            entity.ToTable("StartingEquipment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.EquipmentIndex)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("equipment_index");
            entity.Property(e => e.EquipmentName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("equipment_name");
            entity.Property(e => e.EquipmentUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("equipment_url");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Class).WithMany(p => p.StartingEquipments)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StartingE__class__4D94879B");
        });

        modelBuilder.Entity<StartingEquipmentOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Starting__3213E83F69F6634C");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChooseCount).HasColumnName("choose_count");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.OptionType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("option_type");

            entity.HasOne(d => d.Class).WithMany(p => p.StartingEquipmentOptions)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StartingE__class__5070F446");
        });

        modelBuilder.Entity<StartingEquipmentOptionDetail>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.OptionId).HasColumnName("option_id");
            entity.Property(e => e.OptionIndex)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("option_index");
            entity.Property(e => e.OptionName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("option_name");
            entity.Property(e => e.OptionUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("option_url");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
        });

        modelBuilder.Entity<Subclass>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subclass__3213E83FF989A903");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.SubclassIndex)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("subclass_index");
            entity.Property(e => e.SubclassName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("subclass_name");
            entity.Property(e => e.SubclassUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("subclass_url");

            entity.HasOne(d => d.Class).WithMany(p => p.Subclasses)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subclasse__class__59063A47");
        });

        modelBuilder.Entity<Subrace>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subraces__3213E83F9204972B");

            entity.HasIndex(e => e.Index, "UQ__Subraces__1D0A33494641363C").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Index)
                .HasMaxLength(50)
                .HasColumnName("index");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .HasColumnName("url");

            entity.HasOne(d => d.Race).WithMany(p => p.Subraces)
                .HasForeignKey(d => d.RaceId)
                .HasConstraintName("FK__Subraces__race_i__4865BE2A");
        });

        modelBuilder.Entity<SubraceProficiency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SubraceP__3213E83F9910BDD7");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProficiencyId).HasColumnName("proficiency_id");
            entity.Property(e => e.SubraceId).HasColumnName("subrace_id");

            entity.HasOne(d => d.Proficiency).WithMany(p => p.SubraceProficiencies)
                .HasForeignKey(d => d.ProficiencyId)
                .HasConstraintName("FK__SubracePr__profi__0A338187");

            entity.HasOne(d => d.Subrace).WithMany(p => p.SubraceProficiencies)
                .HasForeignKey(d => d.SubraceId)
                .HasConstraintName("FK__SubracePr__subra__093F5D4E");
        });

        modelBuilder.Entity<SubraceTrait>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TraitSub__3213E83F9F740565");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SubraceId).HasColumnName("subrace_id");
            entity.Property(e => e.TraitId).HasColumnName("trait_id");

            entity.HasOne(d => d.Subrace).WithMany(p => p.SubraceTraits)
                .HasForeignKey(d => d.SubraceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TraitSubr__subra__02925FBF");

            entity.HasOne(d => d.Trait).WithMany(p => p.SubraceTraits)
                .HasForeignKey(d => d.TraitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TraitSubr__trait__019E3B86");
        });

        modelBuilder.Entity<Trait>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Traits__3213E83FEA0F0B13");

            entity.HasIndex(e => e.Index, "UQ__Traits__1D0A3349C3FA522A").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Index)
                .HasMaxLength(50)
                .HasColumnName("index");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .HasColumnName("url");
        });

        modelBuilder.Entity<TypicalSpeaker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TypicalS__3213E83F9A89E550");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.Speaker)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("speaker");

            entity.HasOne(d => d.Language).WithMany(p => p.TypicalSpeakers)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK__TypicalSp__langu__05D8E0BE");
        });

        modelBuilder.Entity<WeaponProperty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WeaponPr__3213E83FB41D3653");

            entity.HasIndex(e => e.Index, "UQ__WeaponPr__1D0A334966A6672A").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Index)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("index");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<WeaponPropertyDescription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WeaponPr__3213E83FC7AE973A");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.WeaponPropertyId).HasColumnName("weapon_property_id");

            entity.HasOne(d => d.WeaponProperty).WithMany(p => p.WeaponPropertyDescriptions)
                .HasForeignKey(d => d.WeaponPropertyId)
                .HasConstraintName("FK__WeaponPro__weapo__151B244E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

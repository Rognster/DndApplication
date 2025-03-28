// src/pages/AddCharacter.tsx
import { useState, useRef, ChangeEvent, useEffect } from 'react';
import Layout from '../components/Layout';
import { useCharacterLogic } from '../hooks/useCharacterLogic';
import { AttributeKey } from '../types/CharacterType';
import { SpellData, CharacterSpell } from '../interfaces/SpellData';
import '../styles/character.css';

type EquipmentItem = {
    id: string;
    name: string;
    quantity: number;
};

type EquipmentCategory = {
    name: string;
    items: EquipmentItem[];
    isOpen: boolean;
};

function AddCharacter() {
    const {
        classes,
        races,
        selectedClass,
        selectedRace,
        abilityScores,
        handleClassChange,
        handleRaceChange,
        DecreaseAbilityScore,
        IncreaseAbilityScore,
        unusedAbilityPoints,
        classSavingThrows,
        PoficiencyBonus,
        classSkills,
        proficientSkills,
        toggleProficiency,
        classLevels,
        characterLevel,
        updateCharacterLevel,
        currentLevelData,
        currentLevelFeatures,
        cumulativeFeatures,
        spells, // Get spells from useCharacterLogic
        isLoadingSpells // Get loading state from useCharacterLogic
    } = useCharacterLogic();

    const [selectedSubrace, setSelectedSubrace] = useState<number | null>(null);

    const subraces = [
        { id: 1, name: "Hill Dwarf", parentRaceId: 1 },
        { id: 2, name: "Mountain Dwarf", parentRaceId: 1 },
        { id: 3, name: "High Elf", parentRaceId: 2 },
        { id: 4, name: "Wood Elf", parentRaceId: 2 },
        { id: 5, name: "Dark Elf (Drow)", parentRaceId: 2 },
        { id: 6, name: "Lightfoot Halfling", parentRaceId: 3 },
        { id: 7, name: "Stout Halfling", parentRaceId: 3 },
        { id: 8, name: "Rock Gnome", parentRaceId: 5 },
        { id: 9, name: "Forest Gnome", parentRaceId: 5 },
        { id: 10, name: "Brass Dragonborn", parentRaceId: 7 },
        { id: 11, name: "Gold Dragonborn", parentRaceId: 7 },
    ];

    const handleSubraceChange = (subraceId: number) => {
        setSelectedSubrace(subraceId);
    };

    const filteredSubraces = subraces.filter(
        (subrace) => selectedRace !== null && subrace.parentRaceId === selectedRace
    );

    const [equipmentCategories, setEquipmentCategories] = useState<EquipmentCategory[]>([
        { name: 'Weapons', items: [], isOpen: true },
        { name: 'Armor', items: [], isOpen: true },
        { name: 'Consumables', items: [], isOpen: true },
        { name: 'Other', items: [], isOpen: true },
    ]);
    
    const [newItemName, setNewItemName] = useState<string>('');
    const [newItemQuantity, setNewItemQuantity] = useState<number>(1);
    const [selectedCategory, setSelectedCategory] = useState<string>('Weapons');
    
    const [currency, setCurrency] = useState({
        cp: 0,
        sp: 0,
        ep: 0,
        gp: 0,
        pp: 0,
    });

    const equipmentOptions = {
        Weapons: ['Longsword', 'Short Bow', 'Dagger', 'Greatsword', 'Crossbow', 'Staff', 'Warhammer', 'Rapier'],
        Armor: ['Leather Armor', 'Chain Mail', 'Plate Armor', 'Shield', 'Breastplate', 'Studded Leather'],
        Consumables: ['Potion of Healing', 'Rations (1 day)', 'Antitoxin', 'Holy Water', 'Acid Vial', 'Alchemist Fire'],
        Other: ['Backpack', 'Bedroll', 'Rope', 'Torch', 'Waterskin', 'Spellbook', 'Component Pouch', 'Thieves\' Tools'],
    };

    const toggleCategory = (categoryName: string) => {
        setEquipmentCategories(categories => 
            categories.map(category => 
                category.name === categoryName 
                    ? { ...category, isOpen: !category.isOpen } 
                    : category
            )
        );
    };

    const addItem = (categoryName: string) => {
        if (!newItemName) return;
        
        setEquipmentCategories(categories => 
            categories.map(category => {
                if (category.name === categoryName) {
                    return {
                        ...category,
                        items: [
                            ...category.items,
                            {
                                id: Date.now().toString(),
                                name: newItemName,
                                quantity: newItemQuantity,
                            }
                        ]
                    };
                }
                return category;
            })
        );
        
        setNewItemName('');
        setNewItemQuantity(1);
    };

    const removeItem = (categoryName: string, itemId: string) => {
        setEquipmentCategories(categories => 
            categories.map(category => {
                if (category.name === categoryName) {
                    return {
                        ...category,
                        items: category.items.filter(item => item.id !== itemId)
                    };
                }
                return category;
            })
        );
    };

    const handleCurrencyChange = (currency: string, value: string) => {
        const numValue = value === '' ? 0 : parseInt(value);
        setCurrency(prev => ({
            ...prev,
            [currency]: isNaN(numValue) ? 0 : numValue
        }));
    };

    const [profileImage, setProfileImage] = useState<string | null>(null);
    const fileInputRef = useRef<HTMLInputElement>(null);

    const handleImageUpload = (e: ChangeEvent<HTMLInputElement>) => {
        const file = e.target.files?.[0];
        if (file) {
            const reader = new FileReader();
            reader.onload = () => {
                setProfileImage(reader.result as string);
            };
            reader.readAsDataURL(file);
        }
    };

    const triggerFileInput = () => {
        fileInputRef.current?.click();
    };

    const abilityScoreMapping: Record<AttributeKey, string> = {
        str: "Strength",
        dex: "Dexterity",
        con: "Constitution",
        wis: "Wisdom",
        int: "Intelligence",
        cha: "Charisma",
    };

    const [selectedProficiencyCount, setSelectedProficiencyCount] = useState(2);
    const classLookup = Object.fromEntries(classes.map(cls => [cls.id, cls]));
    const selectedClassName = selectedClass !== null ? classLookup[selectedClass]?.name || "Unknown Class" : "Unknown Class";

    const handleLevelChange = (e: ChangeEvent<HTMLSelectElement>) => {
        updateCharacterLevel(parseInt(e.target.value));
    };
    
    const levels = Array.from({ length: 20 }, (_, i) => i + 1);

    const [expandedFeatures, setExpandedFeatures] = useState<Record<number, boolean>>({});

    const toggleFeatureExpansion = (featureId: number) => {
        setExpandedFeatures(prev => ({
            ...prev,
            [featureId]: !prev[featureId]
        }));
    };

    // Spell Management - Modified to use spells from useCharacterLogic
    const [filteredSpells, setFilteredSpells] = useState<SpellData[]>([]);
    const [spellSearchTerm, setSpellSearchTerm] = useState('');
    const [characterSpells, setCharacterSpells] = useState<CharacterSpell[]>([]);
    const [spellLevelFilter, setSpellLevelFilter] = useState<number | 'all'>('all');
    const [spellSchoolFilter, setSpellSchoolFilter] = useState<string>('all');

    // Filter spells based on search term, level, and school
    useEffect(() => {
        let result = spells;
        
        // Filter by search term
        if (spellSearchTerm) {
            result = result.filter(spell => 
                spell.name.toLowerCase().includes(spellSearchTerm.toLowerCase()) ||
                spell.description.toLowerCase().includes(spellSearchTerm.toLowerCase())
            );
        }
        
        // Filter by level
        if (spellLevelFilter !== 'all') {
            result = result.filter(spell => spell.level === spellLevelFilter);
        }
        
        // Filter by school
        if (spellSchoolFilter !== 'all') {
            result = result.filter(spell => spell.school.toLowerCase() === spellSchoolFilter.toLowerCase());
        }
        
        setFilteredSpells(result);
    }, [spellSearchTerm, spellLevelFilter, spellSchoolFilter, spells]);

    // Add spell to character's spellbook
    const addSpellToCharacter = (spell: SpellData) => {
        if (!characterSpells.some(s => s.spellData.id === spell.id)) {
            setCharacterSpells([...characterSpells, {
                id: Date.now().toString(),
                spellData: spell,
                isPrepared: false
            }]);
        }
    };

    // Remove spell from character's spellbook
    const removeSpellFromCharacter = (spellId: string) => {
        setCharacterSpells(characterSpells.filter(spell => spell.id !== spellId));
    };

    // Toggle prepared status for a spell
    const togglePreparedStatus = (spellId: string) => {
        setCharacterSpells(characterSpells.map(spell => 
            spell.id === spellId 
                ? { ...spell, isPrepared: !spell.isPrepared } 
                : spell
        ));
    };

    // Get unique spell schools for the filter dropdown
    const uniqueSchools = [...new Set(spells.map(spell => spell.school))];

    return (
        <Layout characters={[]} setCharacters={() => { }}>
            <div>
                <form className="charsheet">
                    <h1>Add Character</h1>
                    <header className="header">
                        <div className="profile-section">
                            <div 
                                className="profile-image-container" 
                                onClick={triggerFileInput}
                            >
                                {profileImage ? (
                                    <img 
                                        src={profileImage} 
                                        alt="Character profile" 
                                        className="profile-image" 
                                    />
                                ) : (
                                    <div className="profile-placeholder">
                                        <span>Click to add image</span>
                                    </div>
                                )}
                                <input 
                                    type="file"
                                    ref={fileInputRef}
                                    onChange={handleImageUpload}
                                    accept="image/*"
                                    className="file-input"
                                />
                            </div>
                            <div className="char-name-container">
                                <label htmlFor="charname">Character Name</label>
                                <input id="charname" name="charname" placeholder="Thoradin Fireforge" />
                            </div>
                        </div>
                        <section className="misc">
                            <ul>
                                <li>
                                    <div className="class-level-container">
                                        <div className="form-group">
                                            <label htmlFor="class">Class</label>
                                            <select
                                                id="class"
                                                value={selectedClass || ''}
                                                onChange={(e) => handleClassChange(Number(e.target.value))}
                                            >
                                                <option value="" disabled>
                                                    -- Choose a Class --
                                                </option>
                                                {classes.map((classData) => (
                                                    <option key={classData.id} value={classData.id}>
                                                        {classData.name}
                                                    </option>
                                                ))}
                                            </select>
                                        </div>
                                        <div className="form-group">
                                            <label htmlFor="level">Level</label>
                                            <select
                                                id="level"
                                                value={characterLevel}
                                                onChange={handleLevelChange}
                                                disabled={!selectedClass}
                                                className={!selectedClass ? 'disabled-select' : ''}
                                            >
                                                {selectedClass ? (
                                                    levels.map(level => (
                                                        <option key={level} value={level}>
                                                            {level}
                                                        </option>
                                                    ))
                                                ) : (
                                                    <option value={1}>1</option>
                                                )}
                                            </select>
                                            {!selectedClass && (
                                                <div className="select-hint">Choose a class first</div>
                                            )}
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div className="Race-subRace-container">
                                        <div className="form-group">
                                            <label htmlFor="race">Race</label>
                                            <select
                                                id="race"
                                                value={selectedRace || ''}
                                                onChange={(e) => {
                                                    handleRaceChange(Number(e.target.value));
                                                    setSelectedSubrace(null);
                                                }}
                                            >
                                                <option value="" disabled>
                                                    -- Choose a Race --
                                                </option>
                                                {races.map((raceData) => (
                                                    <option key={raceData.id} value={raceData.id}>
                                                        {raceData.name}
                                                    </option>
                                                ))}
                                            </select>
                                        </div>
                                        <div className="form-group">
                                            <label htmlFor="subrace">Sub-Race</label>
                                            <select
                                                id="subrace"
                                                value={selectedSubrace || ''}
                                                onChange={(e) => handleSubraceChange(Number(e.target.value))}
                                                disabled={!selectedRace || filteredSubraces.length === 0}
                                            >
                                                <option value="" disabled>
                                                    {filteredSubraces.length === 0 
                                                        ? "-- No Subraces Available --" 
                                                        : "-- Choose a Sub Race --"}
                                                </option>
                                                {filteredSubraces.map((subraceData) => (
                                                    <option key={subraceData.id} value={subraceData.id}>
                                                        {subraceData.name}
                                                    </option>
                                                ))}
                                            </select>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <div className="form-group">
                                        <label htmlFor="background">Background</label>
                                        <input
                                            id="background"
                                            name="background"
                                            placeholder="Acolyte"
                                        />
                                    </div>
                                </li>

                                <li>
                                    <div className="form-group">
                                        <label htmlFor="alignment">Alignment</label>
                                        <input
                                            id="alignment"
                                            name="alignment"
                                            placeholder="Lawful Good"
                                        />
                                    </div>
                                </li>

                                <li>
                                    <div className="form-group">
                                        <label htmlFor="playerName">Player Name</label>
                                        <input
                                            id="playerName"
                                            name="playerName"
                                            placeholder="Player McPlayerface"
                                        />
                                    </div>
                                </li>

                                <li>
                                    <div className="form-group">
                                        <label htmlFor="experiencepoints">Experience Points</label>
                                        <input
                                            id="experiencepoints"
                                            name="experiencepoints"
                                            placeholder="3240"
                                        />
                                    </div>
                                </li>
                            </ul>
                        </section>
                    </header>
                    <section className="above">
                        <div className="scores">
                            <ul className="ability-scores">
                                <li className="ability-item">
                                    <div className="label-container">
                                        <label>Available Points</label>
                                        <div className="modifier">
                                            <input
                                                id={`score`}
                                                name={`score`}
                                                value={unusedAbilityPoints}
                                                readOnly
                                            />
                                        </div>
                                    </div>
                                </li>
                                {Object.keys(abilityScores).map((attr) => {
                                    const abilityKey = attr as AttributeKey;
                                    const { baseScore, bonus, modifier } = abilityScores[abilityKey];
                                    const totalScore = baseScore + bonus;

                                    return (
                                        <li key={abilityKey} className="ability-item">
                                            <div className="score">
                                                <label htmlFor={`${abilityKey}score`}>{abilityKey.toUpperCase()}</label>
                                                <input
                                                    id={`${abilityKey}score`}
                                                    name={`${abilityKey}score`}
                                                    value={totalScore}
                                                    readOnly
                                                />
                                            </div>
                                            <div className="modifier">
                                                <input
                                                    name={`${abilityKey}mod`}
                                                    value={modifier >= 0 ? `+${modifier}` : modifier}
                                                    readOnly
                                                />

                                                <div className="modifier-buttons">
                                                    <button
                                                        type="button"
                                                        className="modifier-btn decrement"
                                                        onClick={() => DecreaseAbilityScore(abilityKey)}
                                                    >
                                                        -
                                                    </button>
                                                    <button
                                                        type="button"
                                                        className="modifier-btn increment"
                                                        onClick={() => IncreaseAbilityScore(abilityKey)}
                                                    >
                                                        +
                                                    </button>
                                                </div>
                                            </div>
                                        </li>
                                    );
                                })}
                                
                                <li className="ability-item">
                                    <div className="label-container">
                                        <div className="modifier">
                                            <label>Proficiency Bonus</label>

                                            <input
                                                id="proficiencybonus"
                                                name="proficiencybonus"
                                                value={PoficiencyBonus}
                                                readOnly
                                            />
                                        </div>
                                    </div>
                                </li>
                                <li className="ability-item">
                                    <div className="modifier">
                                        <label htmlFor="speed">Speed</label>
                                        <input
                                            type="text"
                                            id="speed"
                                            name="speed"
                                            value={races.find((race) => race.id === selectedRace)?.speed || 0}
                                            readOnly
                                            />
                                    </div>
                                </li>
                                <li className="hp">
                                    <div className="modifier">
                                        <label htmlFor="maxhp">Hit Die</label>
                                        <input
                                            type="text"
                                            id="maxhp"
                                            name="maxhp"
                                            value={selectedClass !== null ? (classes.find((cls) => cls.id === selectedClass)?.hitDie || 0) + abilityScores.con.modifier : 0}
                                            readOnly
                                            />
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </section>
                    <main className="main-content">
                        <section className="sub-main">
                            <section className="attributes-section">
                                <div className="attr-applications">
                                    <div className="saves list-section box">
                                        <div className="label">Saving Throws</div>
                                        <ul>
                                            {["Strength", "Dexterity", "Constitution", "Wisdom", "Intelligence", "Charisma"].map((attr, index) => {
                                                const abilityKey = attr.toLowerCase().slice(0, 3) as AttributeKey;
                                                const isProficient = classSavingThrows.some((savingThrow) => 
                                                    abilityScoreMapping[savingThrow.abilityScoreName.toLowerCase() as AttributeKey] === attr
                                                );
                                                const modifier = abilityScores[abilityKey]?.modifier + (isProficient ? PoficiencyBonus : 0) || 0;

                                                return (
                                                    <li key={index}>
                                                        <label htmlFor={`${attr}-save`}>{attr}</label>
                                                        <input
                                                            id={`${attr}-save`}
                                                            name={`${attr}-save`}
                                                            type="text"
                                                            value={modifier >= 0 ? `+${modifier}` : modifier}
                                                            readOnly
                                                        />
                                                        <input
                                                            id={`${attr}-save-prof`}
                                                            name={`${attr}-save-prof`}
                                                            type="checkbox"
                                                            checked={isProficient}
                                                            readOnly
                                                        />
                                                    </li>
                                                );
                                            })}
                                        </ul>
                                    </div>
                                    <div className="stat-row">
                                        <div className="saves list-section box">
                                            <div className="modifier">
                                                <label htmlFor="passiveperception">Passive Wisdom</label>
                                                <input
                                                    id="passiveperception"
                                                    name="passiveperception"
                                                    value={abilityScores.wis.modifier}
                                                    readOnly
                                                />
                                            </div>
                                        </div>
                                        <div className="saves list-section box">
                                            <div className="modifier">
                                                <label htmlFor="ac">Armor Class</label>
                                                <input
                                                    type="text"
                                                    id="ac"
                                                    name="ac"
                                                    value={abilityScores.dex.modifier}
                                                    readOnly
                                                />
                                            </div>
                                        </div>
                                        <div className="saves list-section box">
                                            <div className="modifier">
                                                <label htmlFor="initiative">Initiative</label>
                                                <input
                                                    type="text"
                                                    id="initiative"
                                                    name="initiative"
                                                    value={abilityScores.dex.modifier}
                                                    readOnly
                                                />
                                            </div>
                                        </div>
                                    </div>
                                    <div className="otherprofs box textblock">
                                        <label htmlFor="otherprofs">Other Proficiencies and Languages</label>
                                        <textarea
                                            id="otherprofs"
                                            name="otherprofs"
                                        ></textarea>
                                    </div>
                                </div>
                                <div className="skills list-section box">
                                    <div className="label">
                                        Skill, You can choose {selectedProficiencyCount} of the highlighted skills as proficient choosing the {selectedClassName} class.
                                    </div>
                                    <ul>
                                        {[
                                            { name: "Acrobatics", attr: "Dex" },
                                            { name: "Animal Handling", attr: "Wis" },
                                            { name: "Arcana", attr: "Int" },
                                            { name: "Athletics", attr: "Str" },
                                            { name: "Deception", attr: "Cha" },
                                            { name: "History", attr: "Int" },
                                            { name: "Insight", attr: "Wis" },
                                            { name: "Intimidation", attr: "Cha" },
                                            { name: "Investigation", attr: "Int" },
                                            { name: "Medicine", attr: "Wis" },
                                            { name: "Nature", attr: "Int" },
                                            { name: "Perception", attr: "Wis" },
                                            { name: "Performance", attr: "Cha" },
                                            { name: "Persuasion", attr: "Cha" },
                                            { name: "Religion", attr: "Int" },
                                            { name: "Sleight of Hand", attr: "Dex" },
                                            { name: "Stealth", attr: "Dex" },
                                            { name: "Survival", attr: "Wis" }
                                        ].map((skill, index) => {
                                            const abilityKey = skill.attr.toLowerCase().slice(0, 3) as AttributeKey;
                                            const modifier = abilityScores[abilityKey]?.modifier;
                                            let proficientInSkill = false;

                                            classSkills.forEach((classSkill) => {
                                                if (classSkill.skillIndex === skill.name.toLowerCase()) {
                                                    proficientInSkill = true;
                                                }
                                            });

                                            return (
                                                <li key={index}>
                                                    <label htmlFor={skill.name}>
                                                        {skill.name} <span className="skill">({skill.attr})</span>
                                                    </label>
                                                    <input
                                                        id={skill.name}
                                                        name={skill.name}
                                                        type="text"
                                                        value={modifier + (proficientSkills.includes(skill.name.toLowerCase()) ? PoficiencyBonus : 0)}
                                                        readOnly
                                                    />
                                                    <input
                                                        name={`${skill.name}-prof`}
                                                        type="checkbox"
                                                        className={
                                                            proficientInSkill &&
                                                            (selectedProficiencyCount > 0 || proficientSkills.includes(skill.name.toLowerCase()))
                                                                ? "glow-checkbox"
                                                                : ""
                                                        }
                                                        checked={proficientSkills.includes(skill.name.toLowerCase())}
                                                        onChange={(e) => {
                                                            const isChecked = e.target.checked;

                                                            if (isChecked && selectedProficiencyCount > 0) {
                                                                toggleProficiency(skill.name.toLowerCase());
                                                                setSelectedProficiencyCount((count) => count - 1);
                                                            } else if (!isChecked) {
                                                                toggleProficiency(skill.name.toLowerCase());
                                                                setSelectedProficiencyCount((count) => count + 1);
                                                            }
                                                        }}
                                                        disabled={
                                                            !proficientInSkill || 
                                                            (!proficientSkills.includes(skill.name.toLowerCase()) && selectedProficiencyCount == 0)
                                                        }
                                                    />
                                                </li>
                                            );
                                        })}
                                    </ul>
                                </div>
                            </section>
                            <section className="character-features-section">
                                <div className="equipment-container feature-box">
                                    <div className="section-title">Equipment</div>
                                    <div className="equipment-categories">
                                        {equipmentCategories.map((category) => (
                                            <div key={category.name} className="equipment-category">
                                                <div 
                                                    className="category-header" 
                                                    onClick={() => toggleCategory(category.name)}
                                                >
                                                    <h3>{category.name}</h3>
                                                    <button 
                                                        type="button" 
                                                        className="collapse-button"
                                                    >
                                                        {category.isOpen ? '▼' : '►'}
                                                    </button>
                                                </div>
                                                {category.isOpen && (
                                                    <div className="category-content">
                                                        <ul className="item-list">
                                                            {category.items.map((item) => (
                                                                <li key={item.id}>
                                                                    <span>
                                                                        {item.name}
                                                                        <span className="item-quantity">x{item.quantity}</span>
                                                                    </span>
                                                                    <div className="item-actions">
                                                                        <button 
                                                                            type="button" 
                                                                            className="item-delete" 
                                                                            onClick={() => removeItem(category.name, item.id)}
                                                                        >
                                                                            ✕
                                                                        </button>
                                                                    </div>
                                                                </li>
                                                            ))}
                                                        </ul>
                                                        <div className="add-item-form">
                                                            <select 
                                                                value={newItemName}
                                                                onChange={(e) => setNewItemName(e.target.value)}
                                                            >
                                                                <option value="">Select item...</option>
                                                                {equipmentOptions[category.name as keyof typeof equipmentOptions].map((item) => (
                                                                    <option key={item} value={item}>
                                                                        {item}
                                                                    </option>
                                                                ))}
                                                                <option value="custom">Custom...</option>
                                                            </select>
                                                            {newItemName === 'custom' && (
                                                                <input
                                                                    type="text"
                                                                    placeholder="Name"
                                                                    value=""
                                                                    onChange={(e) => setNewItemName(e.target.value)}
                                                                />
                                                            )}
                                                            <input
                                                                type="number"
                                                                min="1"
                                                                value={newItemQuantity}
                                                                onChange={(e) => setNewItemQuantity(parseInt(e.target.value) || 1)}
                                                            />
                                                            <button 
                                                                type="button"
                                                                onClick={() => addItem(category.name)}
                                                            >
                                                                Add
                                                            </button>
                                                        </div>
                                                    </div>
                                                )}
                                            </div>
                                        ))}
                                        
                                        <div className="equipment-category">
                                            <div className="category-header">
                                                <h3>Money</h3>
                                            </div>
                                            <div className="category-content">
                                                <div className="money-section">
                                                    <div className="currency-input">
                                                        <label>CP</label>
                                                        <input
                                                            type="number"
                                                            value={currency.cp}
                                                            onChange={(e) => handleCurrencyChange('cp', e.target.value)}
                                                            min="0"
                                                        />
                                                    </div>
                                                    <div className="currency-input">
                                                        <label>SP</label>
                                                        <input
                                                            type="number"
                                                            value={currency.sp}
                                                            onChange={(e) => handleCurrencyChange('sp', e.target.value)}
                                                            min="0"
                                                        />
                                                    </div>
                                                    <div className="currency-input">
                                                        <label>EP</label>
                                                        <input
                                                            type="number"
                                                            value={currency.ep}
                                                            onChange={(e) => handleCurrencyChange('ep', e.target.value)}
                                                            min="0"
                                                        />
                                                    </div>
                                                    <div className="currency-input">
                                                        <label>GP</label>
                                                        <input
                                                            type="number"
                                                            value={currency.gp}
                                                            onChange={(e) => handleCurrencyChange('gp', e.target.value)}
                                                            min="0"
                                                        />
                                                    </div>
                                                    <div className="currency-input">
                                                        <label>PP</label>
                                                        <input
                                                            type="number"
                                                            value={currency.pp}
                                                            onChange={(e) => handleCurrencyChange('pp', e.target.value)}
                                                            min="0"
                                                        />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                
                                <div className="spells-container feature-box">
                                    <div className="section-title">Spells</div>
                                    
                                    {/* Spell filters and search */}
                                    <div className="spell-filters">
                                        <input
                                            type="text"
                                            placeholder="Search spells..."
                                            value={spellSearchTerm}
                                            onChange={(e) => setSpellSearchTerm(e.target.value)}
                                            className="spell-search"
                                        />
                                        
                                        <div className="filter-row">
                                            <select 
                                                value={spellLevelFilter === 'all' ? 'all' : spellLevelFilter.toString()} 
                                                onChange={(e) => setSpellLevelFilter(e.target.value === 'all' ? 'all' : parseInt(e.target.value))}
                                                className="spell-level-filter"
                                            >
                                                <option value="all">All Levels</option>
                                                {[0, 1, 2, 3, 4, 5, 6, 7, 8, 9].map(level => (
                                                    <option key={level} value={level}>
                                                        {level === 0 ? 'Cantrip' : `Level ${level}`}
                                                    </option>
                                                ))}
                                            </select>
                                            
                                            <select 
                                                value={spellSchoolFilter} 
                                                onChange={(e) => setSpellSchoolFilter(e.target.value)}
                                                className="spell-school-filter"
                                            >
                                                <option value="all">All Schools</option>
                                                {uniqueSchools.map(school => (
                                                    <option key={school} value={school}>
                                                        {school}
                                                    </option>
                                                ))}
                                            </select>
                                        </div>
                                    </div>
                                    
                                    {/* Spell browser */}
                                    <div className="spell-browser">
                                        <div className="spell-list">
                                            <h4>Available Spells</h4>
                                            {isLoadingSpells ? (
                                                <div className="loading-spinner">Loading spells...</div>
                                            ) : filteredSpells.length > 0 ? (
                                                <ul className="available-spells">
                                                    {filteredSpells.map(spell => (
                                                        <li 
                                                            key={spell.id} 
                                                            className="spell-item"
                                                            onClick={() => addSpellToCharacter(spell)}
                                                        >
                                                            <div className="spell-header">
                                                                <span className="spell-name">{spell.name}</span>
                                                                <span className="spell-level-school">
                                                                    {spell.level === 0 ? 'Cantrip' : `Level ${spell.level}`} - {spell.school}
                                                                </span>
                                                            </div>
                                                            <div className="spell-meta">
                                                                <span>{spell.castingTime}</span>
                                                                <span>{spell.range}</span>
                                                                {spell.concentration && <span className="concentration">Concentration</span>}
                                                            </div>
                                                        </li>
                                                    ))}
                                                </ul>
                                            ) : (
                                                <div className="no-spells">No spells match your search criteria.</div>
                                            )}
                                        </div>
                                        
                                        <div className="character-spellbook">
                                            <h4>Your Spellbook</h4>
                                            {characterSpells.length > 0 ? (
                                                <ul className="prepared-spells">
                                                    {characterSpells.map(spell => (
                                                        <li key={spell.id} className="character-spell-item">
                                                            <div className="spell-info">
                                                                <input 
                                                                    type="checkbox"
                                                                    checked={spell.isPrepared}
                                                                    onChange={() => togglePreparedStatus(spell.id)}
                                                                />
                                                                <span className={`spell-name ${spell.isPrepared ? 'prepared' : ''}`}>
                                                                    {spell.spellData.name}
                                                                </span>
                                                            </div>
                                                            <div className="spell-actions">
                                                                <button 
                                                                    type="button" 
                                                                    className="item-delete" 
                                                                    onClick={() => removeSpellFromCharacter(spell.id)}
                                                                >
                                                                    ✕
                                                                </button>
                                                            </div>
                                                        </li>
                                                    ))}
                                                </ul>
                                            ) : (
                                                <div className="empty-spellbook">
                                                    Your spellbook is empty. Click on spells from the list to add them.
                                                </div>
                                            )}
                                        </div>
                                    </div>
                                </div>
                                
                                <div className="abilities-container feature-box">
                                    <div className="section-title">Abilities & Features</div>
                                    {selectedClass === null ? (
                                        <div className="empty-state">Select a class to see available features.</div>
                                    ) : cumulativeFeatures && cumulativeFeatures.length > 0 ? (
                                        <div className="features-container">
                                            {cumulativeFeatures.map(feature => (
                                                <div key={feature.id} className="feature-item">
                                                    <div 
                                                        className="feature-header" 
                                                        onClick={() => toggleFeatureExpansion(feature.id)}
                                                    >
                                                        <div className="feature-name-container">
                                                            <span className={`expand-icon ${expandedFeatures[feature.id] ? 'rotated' : ''}`}>
                                                                ▶
                                                            </span>
                                                            <h4>{feature.name}</h4>
                                                        </div>
                                                    </div>
                                                    <div className={`feature-content ${expandedFeatures[feature.id] ? 'expanded' : ''}`}>
                                                        <p className="feature-description">
                                                            {feature.description || "No description available."}
                                                        </p>
                                                        {feature.prerequisites && (
                                                            <p className="feature-prerequisites">
                                                                <strong>Prerequisites:</strong> {feature.prerequisites}
                                                            </p>
                                                        )}
                                                    </div>
                                                </div>
                                            ))}
                                        </div>
                                    ) : (
                                        <div className="empty-state">
                                            No features available for {classes.find(c => c.id === selectedClass)?.name || ""} at level {characterLevel}.
                                        </div>
                                    )}
                                </div>
                            </section>
                        </section>
                        <section className="sub-main">
                            <section className="combat">
                                {/* Death Saves and Hit Dice sections removed */}
                            </section>
                        </section>
                    </main>
                </form>
            </div>
        </Layout>
    );
}

export default AddCharacter;

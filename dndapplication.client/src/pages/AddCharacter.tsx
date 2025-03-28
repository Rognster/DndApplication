// src/pages/AddCharacter.tsx
import { useState, useRef, ChangeEvent } from 'react';
import Layout from '../components/Layout';
import { useCharacterLogic } from '../hooks/useCharacterLogic';
import { AttributeKey } from '../types/CharacterType';
import '../styles/character.css';

// Equipment types
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
    } = useCharacterLogic();

    // New state for character level
    const [characterLevel, setCharacterLevel] = useState<number>(1);
    
    // Add state for selected subrace
    const [selectedSubrace, setSelectedSubrace] = useState<number | null>(null);

    // Dummy subrace data
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

    // Function to handle subrace change
    const handleSubraceChange = (subraceId: number) => {
        setSelectedSubrace(subraceId);
    };

    // Get filtered subraces based on selected race
    const filteredSubraces = subraces.filter(
        (subrace) => selectedRace !== null && subrace.parentRaceId === selectedRace
    );

    // Equipment state
    const [equipmentCategories, setEquipmentCategories] = useState<EquipmentCategory[]>([
        { name: 'Weapons', items: [], isOpen: true },
        { name: 'Armor', items: [], isOpen: true },
        { name: 'Consumables', items: [], isOpen: true },
        { name: 'Other', items: [], isOpen: true },
    ]);
    
    const [newItemName, setNewItemName] = useState<string>('');
    const [newItemQuantity, setNewItemQuantity] = useState<number>(1);
    const [selectedCategory, setSelectedCategory] = useState<string>('Weapons');
    
    // Currency state
    const [currency, setCurrency] = useState({
        cp: 0, // Copper
        sp: 0, // Silver
        ep: 0, // Electrum
        gp: 0, // Gold
        pp: 0, // Platinum
    });

    // Common equipment options
    const equipmentOptions = {
        Weapons: ['Longsword', 'Short Bow', 'Dagger', 'Greatsword', 'Crossbow', 'Staff', 'Warhammer', 'Rapier'],
        Armor: ['Leather Armor', 'Chain Mail', 'Plate Armor', 'Shield', 'Breastplate', 'Studded Leather'],
        Consumables: ['Potion of Healing', 'Rations (1 day)', 'Antitoxin', 'Holy Water', 'Acid Vial', 'Alchemist Fire'],
        Other: ['Backpack', 'Bedroll', 'Rope', 'Torch', 'Waterskin', 'Spellbook', 'Component Pouch', 'Thieves\' Tools'],
    };

    // Equipment functions
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

    // Function to handle level change
    const handleLevelChange = (e: ChangeEvent<HTMLSelectElement>) => {
        setCharacterLevel(parseInt(e.target.value));
    };
    
    // Generate levels 1-20 for selection
    const levels = Array.from({ length: 20 }, (_, i) => i + 1);

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
                                            >
                                                {levels.map(level => (
                                                    <option key={level} value={level}>
                                                        {level}
                                                    </option>
                                                ))}
                                            </select>
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
                                                    setSelectedSubrace(null); // Reset subrace when race changes
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
                                    <textarea
                                        id="spells"
                                        name="spells"
                                        placeholder="Cantrips, prepared spells, spell slots..."
                                    ></textarea>
                                </div>
                                
                                <div className="abilities-container feature-box">
                                    <div className="section-title">Abilities & Features</div>
                                    <textarea
                                        id="abilities"
                                        name="abilities"
                                        placeholder="Class features, racial traits, feats..."
                                    ></textarea>
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

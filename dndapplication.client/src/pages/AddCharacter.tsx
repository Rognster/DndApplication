// src/pages/AddCharacter.tsx
import { useState } from 'react';
import Layout from '../components/Layout';
import { useCharacterLogic } from '../hooks/useCharacterLogic';
import { AttributeKey } from '../types/CharacterType';
import '../styles/character.css';

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

    return (
        <Layout characters={[]} setCharacters={() => { }}>
            <div>
                <form className="charsheet">
                    <h1>Add Character</h1>
                    <header className="header">
                        <section className="charname">
                            <label htmlFor="charname">Character Name</label>
                            <input id="charname" name="charname" placeholder="Thoradin Fireforge" />
                        </section>
                        <section className="misc">
                            <ul>
                                <li>
                                    <div className="form-group">
                                        <label htmlFor="classlevel">Class & Level</label>
                                        <select
                                            id="classlevel"
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
                                </li>
                                <li>
                                    <div className="form-group">
                                        <label htmlFor="race">Race</label>
                                        <select
                                            id="race"
                                            value={selectedRace || ''}
                                            onChange={(e) => handleRaceChange(Number(e.target.value))}
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
                                    <div className="saves list-section box">
                                        <div className="label-container">
                                            <label htmlFor="passiveperception">Passive Wisdom (Perception)</label>
                                        </div>
                                        <input
                                            id="passiveperception"
                                            name="passiveperception"
                                            value={abilityScores.wis.modifier}
                                            readOnly
                                        />
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
                            <div className="otherprofs box textblock">
                                <label htmlFor="otherprofs">Other Proficiencies and Languages</label>
                                <textarea
                                    id="otherprofs"
                                    name="otherprofs"
                                ></textarea>
                            </div>
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

// src/pages/CharacterPage.tsx

import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import Layout from '../components/Layout';
import { Character } from '../types';
import '../styles/character.css';


// types.ts

export interface Character {
    nickname?: string;
    player: Player; // Required
    xp?: number; // Default: 0, 0
    race: Race; // Required
    classes?: Class[];
    background?: Background;
    details?: CharacterDetails;
    weapon_proficiencies?: string[];
    armor_proficiencies?: string[];
    tool_proficiencies?: string[];
    feats?: Feat[];
    spells?: Spell[];
    weapons?: Weapon[];
    equipment?: Equipment[];
    treasure?: Treasure;
}

export interface Player {
    name?: string; // Default: "NPC"
    id?: string;   // Wizards’ DCI or other identifier
}

export interface Race {
    // Assuming properties based on typical D&D race data
    name: string;
    description?: string;
    speed?: number;
    ability_bonuses?: AbilityBonus[];
    languages?: string[];
    traits?: string[];
}

export interface AbilityBonus {
    ability: string; // e.g., "Strength", "Dexterity"
    bonus: number;
}

export interface Class {
    name: string;
    level: number; // Required
    hit_die?: number;
    class_features?: ClassFeature[];
    subclasses?: Subclass[];
}

export interface ClassFeature {
    name: string;
    description?: string;
}

export interface Subclass {
    name: string;
    description?: string;
    subclass_features?: ClassFeature[];
}

export interface Background {
    name?: string;
    option?: string;
    description?: string;
    source?: Source;
}

export interface Source {
    book?: string;
    page?: number;
}

export interface CharacterDetails {
    age?: number; //  0
    eyes?: string;
    hair?: string;
    skin?: string;
    weight?: number; //  0
    height?: string;
    personality?: string;
    ideal?: string;
    bond?: string;
    flaw?: string;
    backstory?: string;
    physical?: string;
}

export interface Feat {
    name: string;
    description?: string;
    prerequisites?: string[];
}

export interface Spell {
    name: string;
    level: number;
    school?: string;
    casting_time?: string;
    range?: string;
    components?: string[];
    duration?: string;
    description?: string;
    higher_level?: string;
}

export interface Weapon {
    name: string;
    type: string;
    damage: string;
    damage_type?: string;
    properties?: string[];
    weight?: number;
    cost?: string;
    description?: string;
}

export interface Equipment {
    name: string;
    quantity?: number;
    weight?: number;
    cost?: string;
    description?: string;
}

export interface Treasure {
    pp?: number; // Platinum, Default: 0
    ep?: number; // Electrum, Default: 0
    gp?: number; // Gold, Default: 0
    sp?: number; // Silver, Default: 0
    cp?: number; // Copper, Default: 0
}



function CharacterPage() {
    const { id } = useParams<{ id: string }>();
    const navigate = useNavigate();
    const [character, setCharacter] = useState<Character | null>(null);
    const [characters, setCharacters] = useState<Character[]>([]);
    const [error, setError] = useState<string | null>(null);

    // Helper function to calculate ability modifiers
    const calculateModifier = (score: number) => Math.floor((score - 10) / 2);

    // Fetching list of characters
    useEffect(() => {
        async function populateCharacterData() {
            try {
                const response = await fetch('/Character');
                if (response.ok) {
                    const data = await response.json();
                    setCharacters(data);
                } else {
                    console.error('Failed to fetch characters:', response.statusText);
                }
            } catch (error) {
                console.error('Error fetching character data:', error);
            }
        }

        populateCharacterData();
    }, []);

    // Fetching specific character details
    useEffect(() => {
        async function fetchCharacter() {
            try {
                const response = await fetch(`/Character/${id}`);
                if (response.ok) {
                    const data = await response.json();

                    // Set default values for skillsList and proficiencies if undefined
                    setCharacter({
                        ...data,
                        skillsList: data.skillsList || [],
                        proficiencies: data.proficiencies || [],
                    });
                } else {
                    console.error('Failed to fetch character:', response.statusText);
                    setError('Failed to fetch character data.');
                }
            } catch (err) {
                console.error('Error fetching character data:', err);
                setError('An error occurred while fetching character data.');
            }
        }
        fetchCharacter();
    }, [id]);

    const handleBack = () => {
        navigate(-1);
    };

    if (error) {
        return (
            <Layout characters={characters} setCharacters={setCharacters}>
                <div>
                    <p>{error}</p>
                    <button onClick={handleBack}>Back</button>
                </div>
            </Layout>
        );
    }

    if (!character) {
        return (
            <Layout characters={characters} setCharacters={setCharacters}>
                <p>Loading character details...</p>
            </Layout>
        );
    }

    return (
        <Layout characters={characters} setCharacters={setCharacters}>
            <div className="character-sheet">
                {/* Character Header Section */}
                <div className="section-box">
                    <div className="character-header">
                        <h1>{character.name}</h1>
                        <p>
                            Class & Level: <span>{`${character.class} ${character.level}`}</span>
                        </p>
                        <p>
                            Background: <span>{character.background}</span>
                        </p>
                        <p>
                            Player Name: <span>{character.playerName}</span>
                        </p>
                        <p>
                            Race: <span>{character.race}</span>
                        </p>
                        <p>
                            Alignment: <span>{character.alignment}</span>
                        </p>
                        {/* Heroic Inspiration Toggle */}
                        <div className="heroic-inspiration">
                            <label>
                                <input
                                    type="checkbox"
                                    checked={character.heroicInspiration}
                                    onChange={() =>
                                        setCharacter(prev => prev ? { ...prev, heroicInspiration: !prev.heroicInspiration } : prev)
                                    }
                                />
                                Heroic Inspiration
                            </label>
                        </div>
                        {/* Health (Current/Max) */}
                        <div className="health">
                            <label>
                                Health: {character.currentHealth} / {character.maxHealth}
                            </label>
                        </div>
                    </div>
                </div>

                {/* Initiative, AC, Defenses, Condition */}
                <div className="section-box">
                    <div className="character-stats">
                        <div className="stat-block">
                            <h2>{character.initiative}</h2>
                            <p>Initiative</p>
                        </div>
                        <div className="stat-block">
                            <h2>{character.armorClass}</h2>
                            <p>Armor Class</p>
                        </div>
                        <div className="stat-block">
                            <h2>{character.defenses}</h2>
                            <p>Defenses</p>
                        </div>
                        <div className="stat-block">
                            <h2>{character.condition}</h2>
                            <p>Condition</p>
                        </div>
                    </div>
                </div>

                {/* Ability Scores and Saving Throws */}
                <div className="section-box">
                    <h2>Ability Scores & Saving Throws</h2>
                    <div className="character-stats">
                        {Object.entries(character.stats).map(([key, value]) => (
                            <div className="stat-block" key={key}>
                                <h2>{value}</h2>
                                <p>{key.charAt(0).toUpperCase() + key.slice(1)}</p>
                                <p>Modifier: {calculateModifier(value)}</p>
                           </div>
                        ))}
                    </div>
                </div>

                {/* Skills Section */}
                <div className="section-box">
                    <h2>Skills</h2>
                    <table className="skills-table">
                        <thead>
                            <tr>
                                <th>Prof</th>
                                <th>Modifier Stat</th>
                                <th>Skill</th>
                                <th>Bonus</th>
                            </tr>
                        </thead>
                        <tbody>
                            {[
                                { name: 'Acrobatics', stat: 'dexterity' },
                                { name: 'Animal Handling', stat: 'wisdom' },
                                { name: 'Arcana', stat: 'intelligence' },
                                { name: 'Athletics', stat: 'strength' },
                                { name: 'Deception', stat: 'charisma' },
                                { name: 'History', stat: 'intelligence' },
                                { name: 'Insight', stat: 'wisdom' },
                                { name: 'Intimidation', stat: 'charisma' },
                                { name: 'Investigation', stat: 'intelligence' },
                                { name: 'Medicine', stat: 'wisdom' },
                                { name: 'Nature', stat: 'intelligence' },
                                { name: 'Perception', stat: 'wisdom' },
                                { name: 'Performance', stat: 'charisma' },
                                { name: 'Persuasion', stat: 'charisma' },
                                { name: 'Religion', stat: 'intelligence' },
                                { name: 'Sleight of Hand', stat: 'dexterity' },
                                { name: 'Stealth', stat: 'dexterity' },
                                { name: 'Survival', stat: 'wisdom' },
                            ].map((skill) => {
                                const modifierValue = calculateModifier(character.stats[skill.stat]);
                                const proficiencyBonus = character.proficiencies.includes(skill.name)
                                    ? character.proficiencyBonus
                                    : 0;
                                const totalBonus = modifierValue + proficiencyBonus;

                                return (
                                    <tr key={skill.name}>
                                        <td>
                                            <input
                                                type="checkbox"
                                                checked={character.proficiencies.includes(skill.name)}
                                                onChange={() => {
                                                    const updatedProficiencies = character.proficiencies.includes(skill.name)
                                                        ? character.proficiencies.filter(s => s !== skill.name)
                                                        : [...character.proficiencies, skill.name];
                                                    setCharacter(prev => prev ? { ...prev, proficiencies: updatedProficiencies } : prev);
                                                }}
                                            />
                                        </td>
                                        <td>{skill.stat.toUpperCase()}</td>
                                        <td>{skill.name}</td>
                                        <td>{totalBonus >= 0 ? `+${totalBonus}` : totalBonus}</td>
                                    </tr>
                                );
                            })}
                           
                        </tbody>
                    </table>
                </div>

                {/* Senses, Proficiencies & Training */}
                <div className="section-box">
                    <h3>Senses & Proficiencies</h3>
                    <p>Senses: {/*character.senses.join(', ')*/}</p>
                    <p>Languages: {/*character.languages.join(', ')*/}</p>
                    <p>Tools: {/*character.tools.join(', ')*/}</p>
                </div>

                {/* Equipment Section */}
                <div className="section-box">
                    <h3>Equipment</h3>
                    {character.equipment && character.equipment.length > 0 ? (
                        <ul className="equipment">
                            {character.equipment.map((item, index) => (
                                <li key={index}>{item}</li>
                            ))}
                        </ul>
                    ) : (
                        <p>No equipment available.</p>
                    )}
                </div>

                {/* Features & Traits Section */}
                <div className="section-box">
                    <h2>Features & Traits</h2>
                    {character.features && character.features.length > 0 ? (
                        <ul className="features">
                            {character.features.map((feature, index) => (
                                <li key={index}>{feature}</li>
                            ))}
                        </ul>
                    ) : (
                        <p>No features available.</p>
                    )}
                </div>

                {/* Back Button */}
                <div className="back-button">
                    <button type="button" onClick={handleBack}>
                        Back
                    </button>
                </div>
            </div>
        </Layout>
    );
}

export default CharacterPage;

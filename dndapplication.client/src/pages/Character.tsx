import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import Layout from '../components/Layout';
import { Character } from '../types';
import '../styles/character.css';

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
                const response = await fetch('/Characters');
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
                console.log(response);
                if (response.ok) {
                    const data = await response.json();
                    setCharacter(data);
                    console.log(data);
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

    // Define arrays for attributes and skills
    const attributes = ["Strength", "Dexterity", "Constitution", "Wisdom", "Intelligence", "Charisma"];

    const skills = [
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
        { name: "Survival", attr: "Wis" },
    ];

    return (
        <Layout characters={characters} setCharacters={setCharacters}>
            <form className="charsheet">
                <header className="header">
                    <section className="charname">
                        <label htmlFor="charname">Character Name</label>
                        <input
                            id="charname"
                            name="charname"
                            placeholder="Thoradin Fireforge"
                            defaultValue={character.name}
                        />
                    </section>
                    <section className="misc">
                        <ul>
                            <li>
                                <label htmlFor="classlevel">Class & Level</label>
                                <input
                                    id="classlevel"
                                    name="classlevel"
                                    placeholder="Paladin 2"
                                    defaultValue={character.class}
                                />
                            </li>
                            <li>
                                <label htmlFor="background">Background</label>
                                <input
                                    id="background"
                                    name="background"
                                    placeholder="Acolyte"
                                    defaultValue={character.background}
                                />
                            </li>
                            <li>
                                <label htmlFor="playername">Player Name</label>
                                <input
                                    id="playername"
                                    name="playername"
                                    placeholder="Player McPlayerface"
                                    defaultValue={character.player}
                                />
                            </li>
                            <li>
                                <label htmlFor="race">Race</label>
                                <input
                                    id="race"
                                    name="race"
                                    placeholder="Half-elf"
                                    defaultValue={character.race}
                                />
                            </li>
                            <li>
                                <label htmlFor="alignment">Alignment</label>
                                <input
                                    id="alignment"
                                    name="alignment"
                                    placeholder="Lawful Good"
                                    defaultValue={character.alignment}
                                />
                            </li>
                            <li>
                                <label htmlFor="experiencepoints">Experience Points</label>
                                <input
                                    id="experiencepoints"
                                    name="experiencepoints"
                                    placeholder="3240"
                                    defaultValue={character.experiencepoints}
                                />
                            </li>
                        </ul>
                    </section>
        
                </header>

                <section className="above">
                    <div className="scores">
                        <ul className="ability-scores">
                            {["Strength", "Dexterity", "Constitution", "Wisdom", "Intelligence", "Charisma"].map((attr, index) => (
                                <li key={index} className="ability-item">
                                    <div className="score">
                                        <label htmlFor={`${attr}score`}>{attr}</label>
                                        <input
                                            id={`${attr}score`}
                                            name={`${attr}score`}
                                            placeholder="10"
                                            value={character.abilityScores[index]}
                                            onChange={(e) => handleAbilityScoreChange(index, Number(e.target.value))}
                                        />
                                    </div>
                                    <div className="modifier">
                                        <input
                                            name={`${attr}mod`}
                                            placeholder="+0"
                                            value={calculateModifier(character.abilityScores[index])}
                                            readOnly
                                        />
                                    </div>
                                </li>
                            ))}
                            <li className="ability-item">
                                <div className="label-container">
                                    <label>Proficiency Bonus</label>
                                
                                <input
                                    id="proficiencybonus"
                                    name="proficiencybonus"
                                    placeholder="+2"
                                    defaultValue={character.proficiencybonus}
                                    />
                                </div>
                            </li>
                            <li className="ability-item">
                                <label htmlFor="speed">Speed</label>
                                <input
                                    type="text"
                                    id="speed"
                                    name="speed"
                                    placeholder="30"
                                    defaultValue={character.speed}
                                />
                            </li>
                            <li className="ability-item">
                                <div className="label-container">
                                    <label htmlFor="inspiration">Inspiration</label>
                                </div>
                                <input
                                    id="inspiration"
                                    name="inspiration"
                                    type="checkbox"
                                    defaultChecked={character.inspiration}
                                />
                            </li>
                            <li className="hp">
                                <div className="regular">
                                    <div className="max">
                                        <label htmlFor="maxhp">Hit Point Maximum</label>
                                        <input
                                            type="text"
                                            id="maxhp"
                                            name="maxhp"
                                            placeholder="10"
                                            defaultValue={character.maxhp}
                                        />
                                    </div>
                                    <div className="current">
                                        <label htmlFor="currenthp">Current Hit Points</label>
                                        <input
                                            type="text"
                                            id="currenthp"
                                            name="currenthp"
                                            defaultValue={character.currenthp}
                                        />
                                    </div>
                                </div>
                                <div className="temporary">
                                    <label htmlFor="temphp">Temporary Hit Points</label>
                                    <input
                                        type="text"
                                        id="temphp"
                                        name="temphp"
                                        defaultValue={character.temphp}
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
                                        <ul>
                                            {["Str", "Dex", "Con", "Wis", "Int", "Cha"].map((attr, index) => (
                                                <li key={index}>
                                                    <label htmlFor={`${attr}-save`}>{attr}</label>
                                                    <input
                                                        id={`${attr}-save`}
                                                        name={`${attr}-save`}
                                                        type="text"
                                                        placeholder="+0"
                                                        defaultValue={character[`${attr.toLowerCase()}Save`]}
                                                    />
                                                    <input
                                                        name={`${attr}-save-prof`}
                                                        type="checkbox"
                                                        defaultChecked={character[`${attr.toLowerCase()}SaveProf`]}
                                                    />
                                                </li>
                                            ))}
                                        </ul>
                                        <div className="label">Saving Throws</div>
                                    </div>
                                </div>
                            </section>

                            <div className="passive-perception box">
                                <div className="label-container">
                                    <label htmlFor="passiveperception">Passive Wisdom (Perception)</label>
                                </div>
                                <input
                                    id="passiveperception"
                                    name="passiveperception"
                                    placeholder="10"
                                    defaultValue={character.passiveperception}
                                />
                            </div>

                            <div className="otherprofs box textblock">
                                <label htmlFor="otherprofs">Other Proficiencies and Languages</label>
                                <textarea
                                    id="otherprofs"
                                    name="otherprofs"
                                    defaultValue={character.otherprofs}
                                ></textarea>
                            </div>
                        </section>
                        <section className="sub-main">
                            <section className="skills list-section box">
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
                                        { name: "Survival", attr: "Wis" },
                                    ].map((skill, index) => (
                                        <li key={index}>
                                            <label htmlFor={skill.name}>
                                                {skill.name} <span className="skill">({skill.attr})</span>
                                            </label>
                                            <input
                                                id={skill.name}
                                                name={skill.name}
                                                type="text"
                                                placeholder="+0"
                                                defaultValue={character[skill.name]}
                                            />
                                            <input
                                                name={`${skill.name}-prof`}
                                                type="checkbox"
                                                defaultChecked={character[`${skill.name}-prof`]}
                                            />
                                        </li>
                                    ))}
                                </ul>
                                <div className="label">Skills</div>
                            </section>
                        </section>
                        {/* Combat Section */}
                        <section className="sub-main">
                            <section className="combat">
                                <div className="armorclass">
                                    <label htmlFor="ac">Armor Class</label>
                                    <input
                                        type="text"
                                        id="ac"
                                        name="ac"
                                        placeholder="10"
                                        defaultValue={character.ac}
                                    />
                                </div>

                                <div className="initiative">
                                    <label htmlFor="initiative">Initiative</label>
                                    <input
                                        type="text"
                                        id="initiative"
                                        name="initiative"
                                        placeholder="+0"
                                        defaultValue={character.initiative}
                                    />
                                </div>

            

                                <div className="hitdice">
                                    <div className="total">
                                        <label htmlFor="totalhd">Total</label>
                                        <input
                                            type="text"
                                            id="totalhd"
                                            name="totalhd"
                                            placeholder="2d10"
                                            defaultValue={character.totalhd}
                                        />
                                    </div>
                                    <div className="remaining">
                                        <label htmlFor="remaininghd">Hit Dice</label>
                                        <input
                                            type="text"
                                            id="remaininghd"
                                            name="remaininghd"
                                            defaultValue={character.remaininghd}
                                        />
                                    </div>
                                </div>

                                <div className="deathsaves">
                                    <div className="label">
                                        <label>Death Saves</label>
                                    </div>
                                    <div className="marks">
                                        <div className="deathsuccesses">
                                            <label>Successes</label>
                                            <div className="bubbles">
                                                {[1, 2, 3].map((i) => (
                                                    <input
                                                        key={i}
                                                        type="checkbox"
                                                        name={`deathsuccess${i}`}
                                                        defaultChecked={character[`deathsuccess${i}`]}
                                                    />
                                                ))}
                                            </div>
                                        </div>
                                        <div className="deathfails">
                                            <label>Failures</label>
                                            <div className="bubbles">
                                                {[1, 2, 3].map((i) => (
                                                    <input
                                                        key={i}
                                                        type="checkbox"
                                                        name={`deathfail${i}`}
                                                        defaultChecked={character[`deathfail${i}`]}
                                                    />
                                                ))}
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </section>
                    </section>
                </main>
                    {/* Flavor Section */}
                    <section className="flavor">
                        <div className="personality">
                            <label htmlFor="personality">Personality</label>
                            <textarea
                                id="personality"
                                name="personality"
                                defaultValue={character.personality}
                            ></textarea>
                        </div>

                        <div className="ideals">
                            <label htmlFor="ideals">Ideals</label>
                            <textarea
                                id="ideals"
                                name="ideals"
                                defaultValue={character.ideals}
                            ></textarea>
                        </div>

                        <div className="bonds">
                            <label htmlFor="bonds">Bonds</label>
                            <textarea
                                id="bonds"
                                name="bonds"
                                defaultValue={character.bonds}
                            ></textarea>
                        </div>

                        <div className="flaws">
                            <label htmlFor="flaws">Flaws</label>
                            <textarea
                                id="flaws"
                                name="flaws"
                                defaultValue={character.flaws}
                            ></textarea>
                        </div>
                    </section>

                    <section className="features">
                        <div>
                            <label htmlFor="features">Features & Traits</label>
                            <textarea
                                id="features"
                                name="features"
                                defaultValue={character.features}
                            ></textarea>
                        </div>
                    </section>
                
            </form>
        </Layout>
    );
}

export default CharacterPage;

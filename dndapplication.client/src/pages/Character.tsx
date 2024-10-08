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
                const response = await fetch(`/Characters/${id}`);
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

    return (
        <Layout characters={characters} setCharacters={setCharacters}>
            <div className="character-sheet">
                {/* Character Header Section */}
                <div className="section-box">
                    <div className="character-header">
                        <h1>{character.name}</h1>
                        <p>nickname: {character.nickname}</p>   
                        <p>Player: {character.player}</p>
                        <p>Race: {character.race}</p>
                        <p>subrace: {character.subrace}</p>
                        <p>Class: {character.class}</p>
                        <p>subclass: {character.subclass}</p>
                        <p>alignment: {character.alignment}</p>                     
                    </div>
                </div>

                {/* Ability Scores Section */}
                <div className="section-box">
                    <h2>Ability Scores</h2>
                    <ul>
                        {character.abilityScores?.map((score, index) => (
                            <li key={index}>
                                Score: {score} - Modifier: {calculateModifier(score)}
                            </li>
                        ))}
                    </ul>
                </div>

                {/* Equipment Section */}
                <div className="section-box">
                    <h2>Equipment</h2>
                    <ul>
                        {character.equipments?.map((item, index) => (
                            <li key={index}>{item}</li>
                        ))}
                    </ul>
                </div>

                {/* Feats Section */}
                <div className="section-box">
                    <h2>Feats</h2>
                    <ul>
                        {character.feats?.map((item, index) => (
                            <li key={index}>{item}</li>
                        ))}
                    </ul>
                </div>
                {/* Features Section */}
                <div className="section-box">
                    <h2>Features</h2>
                    <ul>
                        {character.features?.map((item, index) => (
                            <li key={index}>{item}</li>
                        ))}
                    </ul>
                </div>
                {/* Languages Section */}
                <div className="section-box">
                    <h2>Languages</h2>
                    <ul>
                        {character.languages?.map((item, index) => (
                            <li key={index}>{item}</li>
                        ))}
                    </ul>
                </div>
                {/* proficiencies Section */}
                <div className="section-box">
                    <h2>proficiencies</h2>
                    <ul>
                        {character.proficiencies?.map((item, index) => (
                            <li key={index}>{item}</li>
                        ))}
                    </ul>
                </div>
                {/* skills Section */}
                <div className="section-box">
                    <h2>skills</h2>
                    <ul>
                        {character.skills?.map((item, index) => (
                            <li key={index}>{item}</li>
                        ))}
                    </ul>
                </div>
                {/* spells Section */}
                <div className="section-box">
                    <h2>spells</h2>
                    <ul>
                        {character.spells?.map((item, index) => (
                            <li key={index}>{item}</li>
                        ))}
                    </ul>
                </div>
                {/* traits Section */}
                <div className="section-box">
                    <h2>traits</h2>
                    <ul>
                        {character.traits?.map((item, index) => (
                            <li key={index}>{item}</li>
                        ))}
                    </ul>
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

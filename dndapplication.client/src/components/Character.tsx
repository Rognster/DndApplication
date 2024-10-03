import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';

export interface CharacterStats {
    strength: number;
    dexterity: number;
    constitution: number;
    intelligence: number;
    wisdom: number;
    charisma: number;
}

export interface Character {
    id: number;
    name: string;
    stats: CharacterStats;
}

function Character() {
    const { id } = useParams<{ id: string }>(); // Get the character ID from the URL
    const navigate = useNavigate(); // Initialize the navigate function
    const [character, setCharacter] = useState<Character | null>(null);

    // Fetch character data when the component is mounted
    useEffect(() => {
        async function fetchCharacter() {
            try {
                const response = await fetch(`/Character/${id}`);
                if (response.ok) {
                    const data = await response.json();
                    setCharacter(data);
                } else {
                    console.error('Failed to fetch character:', response.statusText);
                }
            } catch (error) {
                console.error('Error fetching character data:', error);
            }
        }
        fetchCharacter();
    }, [id]);

    const handleCancel = () => {
        navigate('/'); // Navigate back to the home page when cancelling
    };

    if (!character) {
        return <p>Loading character details...</p>;
    }

    return (
        <div style={{ textAlign: 'center' }}>
            <div className="form-wrapper" style={{ display: 'inline-block', textAlign: 'left' }}>
                <h2 style={{textAlign: 'center' }}>{character.name}</h2>
                <table style={{ margin: '0 auto', borderCollapse: 'collapse', width: '30px' }}>
                    <tbody>
                        <tr>
                             <td style={{ padding: '10px', border: '1px solid #ddd' }}>{character.stats.strength}</td>
                        </tr>
                        <tr>
                            <td style={{ padding: '10px', border: '1px solid #ddd' }}>{character.stats.dexterity}</td>
                        </tr>
                        <tr>
                           <td style={{ padding: '10px', border: '1px solid #ddd' }}>{character.stats.constitution}</td>
                        </tr>
                        <tr>
                           <td style={{ padding: '10px', border: '1px solid #ddd' }}>{character.stats.intelligence}</td>
                        </tr>
                        <tr>
                            <td style={{ padding: '10px', border: '1px solid #ddd' }}>{character.stats.wisdom}</td>
                        </tr>
                        <tr>
                           <td style={{ padding: '10px', border: '1px solid #ddd' }}>{character.stats.charisma}</td>
                        </tr>
                    </tbody>
                </table>
                <div style={{ textAlign: 'center', marginTop: '20px' }}>
                    <button type="button" onClick={handleCancel}>Back</button>
                </div>
            </div>
        </div>
    );
}

export default Character;

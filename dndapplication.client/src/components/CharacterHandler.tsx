import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

export interface CharacterStats {
    strength: number;
    dexterity: number;
    constitution: number;
    intelligence: number;
    wisdom: number;
    charisma: number;
}

function AddCharacter() {
    const [name, setName] = useState('');
    const [stats, setStats] = useState<CharacterStats>({
        strength: 10,
        dexterity: 10,
        constitution: 10,
        intelligence: 10,
        wisdom: 10,
        charisma: 10,
    });

    const navigate = useNavigate();

    const handleStatsChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setStats(prevStats => ({
            ...prevStats,
            [name]: Number(value),
        }));
    };

    const handleCreateCharacter = async () => {
        const newCharacter = {
            name,
            stats,
        };

        try {
            const response = await fetch('Character', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(newCharacter),
            });

            if (response.ok) {
                alert('Character created successfully!');
                navigate('/'); // Navigate back to the home page after creation
            } else {
                alert('Failed to create character. Please try again.');
            }
        } catch (error) {
            console.error('Error creating character:', error);
            alert('An error occurred while creating the character.');
        }
    };

    const handleCancel = () => {
        navigate('/'); // Navigate back to the home page when cancelling
    };

    return (
        <div>
            <div className="form-wrapper">
                <h2>Add New Character</h2>
                <form>
                    <label>
                        Name:
                        <input
                            type="text"
                            value={name}
                            onChange={(e) => setName(e.target.value)}
                            required
                        />
                    </label>
                    {Object.keys(stats).map((key) => (
                        <div className="form-group" key={key}>
                            <label htmlFor={key}>
                                {key.charAt(0).toUpperCase() + key.slice(1)}:
                            </label>
                            <input
                                id={key}
                                type="number"
                                name={key}
                                value={stats[key as keyof CharacterStats]}
                                onChange={handleStatsChange}
                                required
                            />
                        </div>
                    ))}
                    <div>
                        <button type="button" onClick={handleCreateCharacter}>Create</button>
                        <button type="button" onClick={handleCancel}>Cancel</button>
                    </div>
                </form>
            </div>

        </div>
    );
}

export default AddCharacter;

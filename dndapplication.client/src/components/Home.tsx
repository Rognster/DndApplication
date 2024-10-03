import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom'; // Import useNavigate from React Router

export interface Character {
    id: number;
    name: string;
    stats: {
        strength: number;
        dexterity: number;
        constitution: number;
        intelligence: number;
        wisdom: number;
        charisma: number;
    };
}

function Home() {
    const [characters, setCharacters] = useState<Character[] | undefined>([]);
    const navigate = useNavigate(); // Initialize navigate from useNavigate hook

    useEffect(() => {
        populateCharacterData();
    }, []);

    const contents = characters === undefined || characters.length === 0
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started.</em></p>
        : <div> </div>;

    const handleDeleteCharacter = async () => {
        if (characters && characters.length > 0) {
            const characterToDelete = characters[characters.length - 1];

            try {
                const response = await fetch(`Character/${characterToDelete.id}`, {
                    method: 'DELETE',
                });

                if (response.ok) {
                    const updatedCharacters = characters.filter(c => c.id !== characterToDelete.id);
                    setCharacters(updatedCharacters);
                    alert('Character deleted!');
                } else {
                    alert('Failed to delete character. Please try again.');
                }
            } catch (error) {
                console.error('Error deleting character:', error);
                alert('An error occurred while deleting the character.');
            }
        } else {
            alert('No characters to delete.');
        }
    };

    return (
        <div>
            
            <h1 id="tableLabel">Home</h1>
            <p>This is going to be an application for playing DnD online.</p>
            {contents}

            <div style={{ textAlign: 'center', marginTop: '20px' }}>
                {characters.map(character => (
                        <button onClick={() => navigate(`/character/${character.id}`)}> {character.name}</button>
                    ))}
            </div>

            <div style={{ textAlign: 'center', marginTop: '20px' }}>
                <button onClick={() => navigate('/add-character')}>Add Character</button>
                <button onClick={handleDeleteCharacter}>Delete Character</button>
            </div>
        </div>
    );

    async function populateCharacterData() {
        try {
            const response = await fetch('Character');
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
}

export default Home;
// src/pages/Home.tsx

import { useEffect, useState } from 'react';
import Layout from '../components/Layout';
import { CharacterType } from '../types/CharacterType';

function Home() {
    const [characters, setCharacters] = useState<CharacterType[]>([]);

    useEffect(() => {
        populateCharacterData();
    }, []);

    async function populateCharacterData() {
        try {
            const response = await fetch('/Character');
            console.log(response);
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

    return (
        <Layout characters={characters} setCharacters={setCharacters}>
            <div className="content-wrapper">
                <h1>DnD Application</h1>
                <p>This is going to be an application for playing DnD online.</p>
            </div>
        </Layout>
    );
}

export default Home;

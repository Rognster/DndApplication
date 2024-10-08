// src/pages/Home.tsx

import React, { useEffect, useState } from 'react';
import Layout from '../components/Layout';
import { Character } from '../types';

function Home() {
    const [characters, setCharacters] = useState<Character[]>([]);

    useEffect(() => {
        populateCharacterData();
    }, []);

    async function populateCharacterData() {
        try {
            const response = await fetch('/Characters');
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
            <h1>DnD Application</h1>
            <p>This is going to be an application for playing DnD online.</p>
        </Layout>
    );
}

export default Home;

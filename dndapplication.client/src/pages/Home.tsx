import React, { useEffect, useState } from 'react';
import { Helmet } from 'react-helmet';
import Sidebar, { Character } from '../components/Sidebar';
import '../styles/sidebar.css';

function Home() {
    const [characters, setCharacters] = useState<Character[]>([]);

    useEffect(() => {
        populateCharacterData();
    }, []);

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

    return (
        <div>
            <Helmet>
                <link
                    href="https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css"
                    rel="stylesheet"
                />
            </Helmet>
            <div className="sidebar-container">
                <Sidebar characters={characters} setCharacters={setCharacters} />
                <div className="main-content">
                    <h1>DnD Application</h1>
                    <p>This is going to be an application for playing DnD online.</p>
                </div>
            </div>
        </div>
    );
}

export default Home;

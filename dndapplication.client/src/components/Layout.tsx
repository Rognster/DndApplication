// src/components/Layout.tsx

import React from 'react';
import Sidebar from './Sidebar'; // Adjust the import path as necessary
import { Character } from '../types'; // Import types if needed
import { Helmet } from 'react-helmet';


interface LayoutProps {
    children: React.ReactNode;
    characters: Character[];
    setCharacters: React.Dispatch<React.SetStateAction<Character[]>>;
}

const Layout: React.FC<LayoutProps> = ({ children, characters, setCharacters }) => {
    return (
        <div><Helmet>
                <link
                    href="https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css"
                    rel="stylesheet"
                />
            </Helmet>
        <div className="sidebar-container">
            <Sidebar characters={characters} setCharacters={setCharacters} />
            <div className="main-content">
                {children}
            </div>
            </div>
        </div>
    );
};

export default Layout;

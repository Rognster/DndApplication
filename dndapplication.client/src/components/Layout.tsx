// src/components/Layout.tsx

import React from 'react';
import Sidebar from './Sidebar'; // Adjust the import path as necessary
import { CharacterType } from '../types/CharacterType'; // Adjust the import path as necessary
import { Helmet } from 'react-helmet-async';

interface LayoutProps {
    children: React.ReactNode;
    characters: CharacterType[];
    setCharacters: React.Dispatch<React.SetStateAction<CharacterType[]>>;
}

const Layout: React.FC<LayoutProps> = ({ children, characters, setCharacters }) => {
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
                    {children}
                </div>
            </div>
        </div>
    );
};

export default Layout;

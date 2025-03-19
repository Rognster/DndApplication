// src/components/Layout.tsx

import React from 'react';
import Sidebar from './Sidebar'; // Adjust the import path as necessary
import { Helmet } from 'react-helmet-async';

interface Character {
  id: number;
  name: string;
  // add other character properties as needed
}

interface LayoutProps {
  children: React.ReactNode;
  characters: Character[];
  setCharacters: React.Dispatch<React.SetStateAction<Character[]>>;
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

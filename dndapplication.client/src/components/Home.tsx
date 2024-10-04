<<<<<<< HEAD
import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom'; // Import useNavigate from React Router
=======
import React, { useEffect, useRef, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Helmet } from 'react-helmet';
import '../styles/sidebar.css';
>>>>>>> 3821b9d (more frontend changes to the sidebar menu)

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
<<<<<<< HEAD
    const [characters, setCharacters] = useState<Character[] | undefined>([]);
    const navigate = useNavigate(); // Initialize navigate from useNavigate hook
=======
    const [characters, setCharacters] = useState<Character[]>([]);
    const [isSidebarActive, setIsSidebarActive] = useState(false);
    const [isCharacterDropdownOpen, setIsCharacterDropdownOpen] = useState(false);
    const [dropdownHeight, setDropdownHeight] = useState(0);
    const dropdownRef = useRef<HTMLUListElement>(null);
    const navigate = useNavigate();
>>>>>>> 3821b9d (more frontend changes to the sidebar menu)

    useEffect(() => {
        populateCharacterData();
    }, []);

<<<<<<< HEAD
    const contents = characters === undefined || characters.length === 0
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started.</em></p>
        : <div> </div>;

    const handleDeleteCharacter = async () => {
        if (characters && characters.length > 0) {
=======
    // Sidebar Toggle Function
    const toggleSidebar = () => {
        setIsSidebarActive(!isSidebarActive);
    };

    const toggleCharacterDropdown = () => {
        if (dropdownRef.current) {
            if (isCharacterDropdownOpen) {
                // Closing the dropdown
                const currentHeight = dropdownRef.current.scrollHeight;
                // Set the current height as a fixed height, then set to 0 to trigger transition
                dropdownRef.current.style.maxHeight = `${currentHeight}px`;

                // Trigger a reflow
                dropdownRef.current.offsetHeight;

                // Then set the max-height to 0 to close it
                dropdownRef.current.style.maxHeight = '0';
            } else {
                // Opening the dropdown
                const scrollHeight = dropdownRef.current.scrollHeight;
                dropdownRef.current.style.maxHeight = `${scrollHeight}px`;
            }
        }

        setIsCharacterDropdownOpen((prev) => !prev);
    };

    return (
        <div>
            <Helmet>
                <link
                    href="https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css"
                    rel="stylesheet"
                />
            </Helmet>

            <div className="sidebar-container">
                <div className={`sidebar ${isSidebarActive ? 'active' : ''}`}>
                    <div className="top">
                        <div className="logo">
                            <i className="bx bx-user"></i>
                            <span>DM</span>
                        </div>
                        <button
                            className="sidebar-toggle"
                            id="btn"
                            onClick={toggleSidebar}
                            aria-label="Toggle Sidebar"
                        >
                            <i className="bx bx-menu"></i>
                        </button>
                    </div>
                    <div className="user"></div>
                    <ul>
                        <li>
                            <button className="menu-item" onClick={() => navigate('/dicebox')}>
                                <i className="bx bxs-dice-6"></i>
                                <span className="nav-item">Dicebox</span>
                            </button>
                            <span className="tooltip">Dicebox</span>
                        </li>
                        <li>
                            <button className="menu-item" onClick={() => navigate('/screen')}>
                                <i className="bx bxs-book-reader"></i>
                                <span className="nav-item">Screen</span>
                            </button>
                            <span className="tooltip">DM screen</span>
                        </li>
                        {/* Characters Section with Dropdown */}
                        <li className={`dropdown-parent ${isCharacterDropdownOpen ? 'expanded' : ''}`}>
                            <button
                                className="dropdown-toggle"
                                onClick={toggleCharacterDropdown}
                                aria-expanded={isCharacterDropdownOpen}
                                aria-label="Toggle Characters Dropdown"
                            >
                                <div style={{ display: 'flex', alignItems: 'center' }}>
                                    <i className="bx bxs-id-card"></i>
                                    <span className="nav-item">Characters</span>
                                </div>
                                <i
                                    className={`bx dropdown-icon ${isCharacterDropdownOpen ? 'bx-chevron-up' : 'bx-chevron-down'
                                        }`}
                                ></i>
                            </button>
                            <span className="tooltip">Characters</span>
                            <ul
                                className="dropdown"
                                ref={dropdownRef}
                            >
                                {characters.map((character) => (
                                    <li key={character.id}>
                                        <button
                                            className="dropdown-item"
                                            onClick={() => navigate(`/character/${character.id}`)}
                                        >
                                            <i className="bx bxs-user"></i>
                                            <span>{character.name}</span>
                                        </button>
                                    </li>
                                ))}
                                <button
                                    className="dropdown-item"
                                    onClick={() => navigate('/add-character')}
                                >
                                    <i className="bx bxs-user-plus"></i>
                                    <span>Add Character</span>
                                </button>
                            </ul>
                        </li>
                        <li>
                            <button className="menu-item" onClick={() => navigate('/notes')}>
                                <i className="bx bxs-food-menu"></i>
                                <span className="nav-item">Notes</span>
                            </button>
                            <span className="tooltip">Notes</span>
                        </li>
                        <li>
                            <button className="menu-item" onClick={() => navigate('/customers')}>
                                <i className="bx bxs-map-pin"></i>
                                <span className="nav-item">Customers</span>
                            </button>
                            <span className="tooltip">Customers</span>
                        </li>
                        <li>
                            <button className="menu-item" onClick={() => navigate('/settings')}>
                                <i className="bx bxs-cog"></i>
                                <span className="nav-item">Settings</span>
                            </button>
                            <span className="tooltip">Settings</span>
                        </li>
                        <li>
                            <button className="menu-item" onClick={() => navigate('/logout')}>
                                <i className="bx bxs-log-out"></i>
                                <span className="nav-item">Logout</span>
                            </button>
                            <span className="tooltip">Logout</span>
                        </li>
                    </ul>
                </div>
                <div className="main-content">
                    <h1>DnD Application</h1>
                    <p>This is going to be an application for playing DnD online.</p>
                    

                    <div className="character-actions">
                        <button onClick={() => handleDeleteCharacter()}>Delete Character</button>
                    </div>
                </div>
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

    async function handleDeleteCharacter() {
        if (characters.length > 0) {
>>>>>>> 3821b9d (more frontend changes to the sidebar menu)
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
<<<<<<< HEAD
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
=======
>>>>>>> 3821b9d (more frontend changes to the sidebar menu)
    }
}

export default Home;
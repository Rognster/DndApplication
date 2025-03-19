import React, { useState, useRef } from 'react';
import { useNavigate } from 'react-router-dom';
import { CharacterType } from '../types/CharacterType';
import '../styles/sidebar.css';

interface SidebarProps {
    characters: CharacterType[];
    setCharacters: React.Dispatch<React.SetStateAction<CharacterType[]>>;
}

const Sidebar: React.FC<SidebarProps> = ({ characters, setCharacters }) => {
    const [isSidebarActive, setIsSidebarActive] = useState(false);
    const [isCharacterDropdownOpen, setIsCharacterDropdownOpen] = useState(false);
    const dropdownRef = useRef<HTMLUListElement>(null);
    const navigate = useNavigate();

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
                //dropdownRef.current.offsetHeight;

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

    // Function to delete a character
    const handleDeleteCharacter = async (characterId: number) => {
        try {
            const response = await fetch(`https://localhost:5001/api/Character/${characterId}`, {
                method: 'DELETE',
            });

            if (response.ok) {
                const updatedCharacters = characters.filter((c) => c.id !== characterId);
                setCharacters(updatedCharacters);
                alert('Character deleted!');
            } else {
                alert(
                    `Failed to delete character. Please try again. Error: ${response.statusText}`
                );
            }
        } catch (error) {
            console.error('Error deleting character:', error);
            alert('An error occurred while deleting the character.');
        }
    };

    return (
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
                            <li key={character.id} className="dropdown-item">
                                <div
                                    className="character-info"
                                    onClick={() => navigate(`/character/${character.id}`)}
                                >
                                    <i className="bx bxs-user"></i>
                                    <span>{character.name}</span>
                                </div>
                                <i
                                    className="bx bxs-trash delete-icon"
                                    onClick={(event) => {
                                        event.stopPropagation();
                                        handleDeleteCharacter(character.id);
                                    }}
                                ></i>
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
    );
};

export default Sidebar;

//import React from 'react';
import { Routes, Route, useNavigate } from 'react-router-dom';
import Home from './components/Home';
import AddCharacter from './components/CharacterHandler';
import Character from './components/Character';
/*import './styles/main.css';
import './styles/buttons.css';
import './styles/forms.css';
import './styles/table.css';*/




function App() {
    const navigate = useNavigate();

    return (
        <div style={{ textAlign: 'center' }} >
            <h1>DnD application</h1>
            <Routes>
                <Route path="/" element={<Home navigate={navigate} />} />
                <Route path="/add-character" element={<AddCharacter />} />
                <Route path="/character/:id" element={<Character />} /> 
            </Routes>
        </div>
    );
}

export default App;

//import React from 'react';
import { Routes, Route, useNavigate } from 'react-router-dom';
import Home from './pages/Home';
import AddCharacter from './pages/AddCharacter';
import Character from './pages/Character';

function App() {
    const navigate = useNavigate();

    return (
        <div style={{ textAlign: 'center' }} >
            <Routes>
                <Route path="/" element={<Home navigate={navigate} />} />
                <Route path="/add-character" element={<AddCharacter />} />
                <Route path="/character/:id" element={<Character />} /> 
            </Routes>
        </div>
    );
}

export default App;

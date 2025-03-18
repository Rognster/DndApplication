import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { HelmetProvider } from 'react-helmet-async';
import Home from './pages/Home';
import AddCharacter from './pages/AddCharacter';
import Character from './pages/Character';

function App() {
    return (
        <HelmetProvider>
            <Router>
                <div style={{ textAlign: 'center' }}>
                    <Routes>
                        <Route path="/" element={<Home />} />
                        <Route path="/add-character" element={<AddCharacter />} />
                        <Route path="/character/:id" element={<Character />} />
                    </Routes>
                </div>
            </Router>
        </HelmetProvider>
    );
}

export default App;

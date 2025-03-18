import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { HelmetProvider } from 'react-helmet-async';
import Home from './pages/Home';
import AddCharacter from './pages/AddCharacter';
import Character from './pages/Character';
import ErrorBoundary from './components/ErrorBoundary';

function App() {
    return (
        <HelmetProvider>
            <ErrorBoundary>
                <Router>
                    <div style={{ textAlign: 'center' }}>
                        <Routes>
                            <Route path="/" element={<Home />} />
                            <Route path="/add-character" element={<AddCharacter />} />
                            <Route path="/character/:id" element={<Character />} />
                        </Routes>
                    </div>
                </Router>
            </ErrorBoundary>
        </HelmetProvider>
    );
}

export default App;

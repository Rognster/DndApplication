import { CharacterType } from '../types/CharacterType';

const API_BASE_URL = 'https://localhost:5001/api';

export const api = {
    async fetchCharacters(): Promise<CharacterType[]> {
        const response = await fetch(`${API_BASE_URL}/Character`);
        if (!response.ok) throw new Error('Failed to fetch characters');
        return response.json();
    },

    async fetchCharacter(id: string): Promise<CharacterType> {
        const response = await fetch(`${API_BASE_URL}/Character/${id}`);
        if (!response.ok) throw new Error('Failed to fetch character');
        return response.json();
    },

    async fetchClasses() {
        const response = await fetch(`${API_BASE_URL}/Class`);
        if (!response.ok) throw new Error('Failed to fetch classes');
        return response.json();
    },

    async fetchRaces() {
        const response = await fetch(`${API_BASE_URL}/Race`);
        if (!response.ok) throw new Error('Failed to fetch races');
        return response.json();
    }
};

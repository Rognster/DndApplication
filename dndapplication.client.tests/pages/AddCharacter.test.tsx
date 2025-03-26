import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import AddCharacter from '../../dndapplication.client/src/pages/AddCharacter';
import { BrowserRouter } from 'react-router-dom';
import '@testing-library/jest-dom';

// Mock fetch API
global.fetch = jest.fn();

describe('AddCharacter Component', () => {
  beforeEach(() => {
    // Reset mocks between tests
    jest.resetAllMocks();
    
    // Mock responses for API calls
    (global.fetch as jest.Mock).mockImplementation((url) => {
      if (url.includes('/api/Race')) {
        return Promise.resolve({
          ok: true,
          json: () => Promise.resolve([{ id: 1, name: 'Elf' }, { id: 2, name: 'Human' }]),
        });
      }
      if (url.includes('/api/Class')) {
        return Promise.resolve({
          ok: true,
          json: () => Promise.resolve([{ id: 1, name: 'Fighter', hitDie: 10 }, { id: 2, name: 'Wizard', hitDie: 6 }]),
        });
      }
      return Promise.reject(new Error('Not found'));
    });
  });

  test('loads races and classes on mount', async () => {
    // Test should:
    // 1. Arrange: Render the AddCharacter component
    // 2. Act: Wait for API calls to resolve
    // 3. Assert: Verify races and classes are loaded in the dropdowns
  });

  test('updates ability scores when modified', () => {
    // Test should:
    // 1. Arrange: Render the AddCharacter component
    // 2. Act: Click on ability score increment/decrement buttons
    // 3. Assert: Verify ability scores and available points are updated correctly
  });

  test('toggles skill proficiency when clicked', async () => {
    // Test should:
    // 1. Arrange: Render the AddCharacter component and select a class
    // 2. Act: Click on a skill proficiency checkbox
    // 3. Assert: Verify proficiency is toggled and available proficiency points are updated
  });

  test('calculates derived stats correctly', async () => {
    // Test should:
    // 1. Arrange: Render the AddCharacter component
    // 2. Act: Set ability scores and select race/class
    // 3. Assert: Verify that HP, skill modifiers, etc. are calculated correctly
  });
});

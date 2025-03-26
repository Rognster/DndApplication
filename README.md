# D&D Character Creator Application

## Overview
This application is a Dungeons & Dragons character creation tool that allows users to build and manage their D&D characters. It provides an intuitive interface for selecting character classes, races, abilities, and skills while automatically calculating modifiers and tracking proficiencies.

## Technology Stack
- **Frontend**: React with TypeScript, built using Vite
- **Backend**: ASP.NET Core Web API (.NET 8)
- **Database**: SQL Server
- **Deployment**: Azure

## Setup Instructions

### Prerequisites
- Node.js and npm for the client application
- .NET 8 SDK
- SQL Server (local or cloud instance)

### Development Setup
1. Clone the repository:
   ```
   git clone <repository-url>
   cd DndApplication
   ```

2. Set up the backend:
   ```
   cd DndApplication.Server
   dotnet restore
   dotnet build
   dotnet run
   ```

3. Set up the frontend:
   ```
   cd ../dndapplication.client
   npm install
   npm run dev
   ```

4. The application should now be running with the React frontend on port 5173 and the .NET backend on port 7080.

## Features
- **Character Class Selection**: Choose from standard D&D classes with their specific traits
- **Race Selection**: Select character races with corresponding ability bonuses
- **Ability Score Management**: Allocate points to different abilities using the point-buy system
- **Skill Proficiencies**: Select and track skill proficiencies based on class options
- **Automatic Calculations**: Ability modifiers and skill bonuses are calculated automatically
- **Saving Throws**: Track class-based saving throw proficiencies

## API Endpoints
The backend API is available at `https://rpapi-czd4aub3fzcrd9ce.swedencentral-01.azurewebsites.net/api/` with the following endpoints:

- `GET /api/Class/` - Retrieve all available classes
- `GET /api/Race/` - Retrieve all available races
- `GET /api/ClassSavingThrow/{classId}` - Get saving throw proficiencies for a specific class
- `GET /api/ClassSkill/{classId}` - Get skill options for a specific class
- `GET /api/RaceAbilityBonus/{raceId}` - Get ability score bonuses for a specific race

## Project Structure
```
DndApplication/
│
├── DndApplication.Server/      # Backend ASP.NET Core API
│   ├── Controllers/            # API endpoints
│   ├── Models/                 # Data models
│   └── Services/               # Business logic
│
└── dndapplication.client/      # React frontend
    ├── public/                 # Static assets
    └── src/
        ├── components/         # React components
        ├── hooks/              # Custom React hooks
        │   └── useCharacterLogic.ts  # Character creation logic
        ├── interfaces/         # TypeScript interfaces
        └── types/              # TypeScript type definitions
```

## Contributing
Please follow the existing code style and structure when contributing to the project. All pull requests should be made to the development branch.

## License
[License information]

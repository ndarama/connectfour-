# Connect Four - Blazor Game

A classic Connect Four game built with Blazor Web App (.NET 8) for CSE325.

## AUTHOR

**NDARAMA Mark**, Student at BYU IDAHO - 2026

## Features

- **Interactive gameplay**: Two players alternate placing pieces
- **Win detection**: Automatically detects horizontal, vertical, and diagonal wins
- **Animated pieces**: Game pieces drop with smooth animations
- **Customizable colors**: Board and player colors can be configured
- **Error handling**: Prevents invalid moves and displays helpful messages
- **Reset functionality**: Start a new game anytime

## Project Structure

```
ConnectFour/
├── Components/
│   ├── Board.razor              # Main game board component
│   ├── Board.razor.css          # Board styling and animations
│   ├── Layout/
│   │   ├── MainLayout.razor     # Main layout component
│   │   └── MainLayout.razor.css
│   ├── Pages/
│   │   └── Home.razor           # Home page with Board component
│   ├── App.razor                # Root component
│   ├── Routes.razor             # Routing configuration
│   └── _Imports.razor           # Global using statements
├── wwwroot/
│   └── app.css                  # Global styles
├── GameState.cs                 # Game logic and state management
├── Program.cs                   # App configuration and DI setup
└── ConnectFour.csproj           # Project file
```

## How to Run

### Prerequisites
- .NET 8 SDK installed
- Visual Studio 2022, VS Code, or any .NET-compatible IDE

### Running the Application

1. **Using Visual Studio 2022:**
   - Open the folder or project file
   - Press `F5` to run the application
   - The browser should automatically open to the game

2. **Using Command Line:**
   ```powershell
   dotnet restore
   dotnet run
   ```
   - Navigate to `http://localhost:5000` or `https://localhost:5001`

3. **Using Hot Reload:**
   - After starting the app, any changes to `.razor` or `.cs` files will automatically refresh
   - Enable "Hot Reload on File Save" for even faster development

## How to Play

1. Two players take turns (Player 1: Green, Player 2: Purple by default)
2. Click on the 🔽 arrows above each column to drop a piece
3. First player to connect four pieces horizontally, vertically, or diagonally wins!
4. Click "Reset the game" to start over

## Customization

### Change Colors

Edit the `Home.razor` file to customize board and player colors:

```razor
<Board @rendermode="InteractiveServer"
     BoardColor="System.Drawing.Color.Yellow"
     Player1Color="System.Drawing.Color.Red"
     Player2Color="System.Drawing.Color.Blue" />
```

### Game Logic

The `GameState.cs` file contains all game logic:
- `ResetBoard()`: Clears the board
- `PlayPiece(column)`: Places a piece in the specified column
- `CheckForWin()`: Checks for win conditions

## Learning Objectives Covered

✅ Create an app in Blazor  
✅ Manage state in your app  
✅ Customize appearance using CSS  
✅ Build a "Connect Four" game  

## Key Blazor Concepts Demonstrated

- **Components**: Reusable UI elements (`Board.razor`)
- **CSS Isolation**: Component-specific styles (`Board.razor.css`)
- **Dependency Injection**: Singleton service for game state
- **Event Handling**: `@onclick` for user interactions
- **Parameters**: Customizable component properties
- **Interactive Render Mode**: Server-side interactivity
- **State Management**: Separating logic from UI

## Next Steps / Challenges

- Add sound effects when pieces drop
- Add visual indicator when column is full
- Implement AI opponent
- Add networking for multiplayer
- Track win/loss statistics
- Create different board sizes
- Add themes and color presets

## Course Information

**Course**: CSE325 - .NET Software Development  
**Term**: BYU Fall 2026  
**Week**: 4

---

Happy coding! 🎮

# Clappy Bird 🐦

A Unity-based clone of the classic Flappy Bird game, built from scratch in Unity using C# to recreate the original's physics, controls, and gameplay mechanics with custom visual assets.

## About the Project

Clappy Bird is a faithful recreation of Flappy Bird developed in Unity as a learning exercise in 2D game development. The project focuses on implementing core game mechanics including physics-based movement, collision detection, procedural obstacle generation, and score tracking.

## Technical Implementation

This project demonstrates key Unity and C# game development concepts:
- **Physics-based movement** using Unity's Rigidbody2D system
- **Collision detection** for game-over conditions
- **Procedural generation** of obstacles and scrolling background
- **Input handling** for responsive player controls
- **Game state management** (menu, playing, game over)
- **Score tracking and UI** system

## Getting Started

### Prerequisites

- Unity 2019.4 LTS or higher
- Basic understanding of Unity Editor

### Installation

```bash
git clone https://github.com/robinfins/clappybird.git
cd clappybird
```

Open the project in Unity:
1. Launch Unity Hub
2. Click "Add" and select the clappybird folder
3. Open the project
4. Navigate to the main scene in the Assets folder
5. Press Play to run the game

### Building the Game

1. Go to File > Build Settings
2. Select your target platform
3. Click "Build" and choose output location

## Gameplay

- **Objective**: Navigate through gaps between pipes without colliding
- **Controls**: 
  - Space bar / Mouse click - Flap wings
  - Gravity pulls the bird down continuously
- **Scoring**: Each pipe successfully passed awards one point

## Technical Highlights

### Physics Implementation
The bird uses Unity's Rigidbody2D component with custom gravity settings to replicate the original game's "feel". Each tap applies an upward force while gravity creates the characteristic falling arc.

### Procedural Generation
Pipes are spawned at regular intervals with randomized vertical positions, ensuring unique gameplay each session. Objects are recycled using an object pooling pattern for performance optimization.

### State Management
The game implements a finite state machine to handle transitions between menu, active gameplay, and game-over states, ensuring clean scene management and proper resource handling.

## Learning Outcomes

This project demonstrates:
- Unity 2D development workflow
- C# scripting for game logic
- Understanding of game physics and feel
- UI/UX implementation in Unity
- Asset management and organization
- Game state management patterns
- Performance optimization techniques (object pooling)

## Author

**Robin**
- GitHub: [@robinfins](https://github.com/robinfins)

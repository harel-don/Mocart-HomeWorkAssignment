# Unity 3D Shelf Display Project

This Unity project is designed to showcase a 3D shelf display that dynamically loads and updates product information fetched from an external server.
The project is suitable for WebGL export and offers an interface for modifying product details, compatible with desktop and mobile browsers.

## Table of Contents
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [How to Run](#how-to-run)
- [Future Enhancements](#future-enhancements)

## Features
- **Dynamic Product Display**: Fetches product data from an external API and displays it in a 3D environment.
- **Interactive UI**: Allows real-time updates to product names and prices.
- **Cross-Platform Compatibility**: Designed to work on desktop and mobile browsers.
- **WebGL Export Ready**: Configured for WebGL builds to run directly in web browsers.

## Technologies Used
- **Unity**: Used for building the 3D environment and handling interactions.
- **C# Scripting**: Used for backend logic and data handling.
- **TextMeshPro**: Used for UI text rendering.
- **UnityWebRequest**: For fetching data from the server.

## Project Structure
Assets/ |-- Scripts/ | |-- ProductManager.cs | |-- CubeTextManager.cs |-- Prefabs/ | |-- ProductPrefab.prefab |-- Scenes/ | |-- MainScene.unity |-- UI/ | |-- TextMeshPro Elements |-- Materials/ | |-- ShelfMaterial.mat


## Getting Started
### Prerequisites
- Unity 2021.3 or higher.
- Basic knowledge of Unity and C#.
- Internet connection to fetch product data.

### Installation
1. Clone this repository:
   ```bash
   git clone [https://github.com/username/repository-name](https://github.com/harel-don/Mocart-HomeWorkAssignment).git
2. Open the project in Unity.

### How to Run

1. Open the MainScene in Unity.
2. Ensure the API URL in ProductManager.cs is correct and accessible.
3. Press Play in the Unity Editor to start the application.

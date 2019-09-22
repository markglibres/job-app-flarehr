# Battleship

A simple battleship programming exercise using C# dotnetcore. The project includes a simple battle simulator.

## Simulator Screenshot Output
![Simulator Output](https://github.com/markglibres/job-app-flarehr/blob/master/assets/simulator-output.png?raw=true)

## PreRequisites 
* DotNetCore >= 2.2 

## Project Structure 
* BattleShip = console app that calls simulator and contains the DI container. 
* Application = implementation of simulator and application logic. 
* Domain = domain logic for board and ship. 

## Implementation Detail
* Board = implemented as a 2D array of strings. Value stored is the shipId (UUID) 
* Ship = contains the details of the ship such as all coordinates on the 2D plane and its status (HIT or ACTIVE), ship status (OPERATIONAL or SUNK) 
* BoardServiceWith1XNShipSize = service class for board. dictates the application logic (such as ship with size 1xN).
* SimpleSimulator = a simulator for the battle game for 1 board. will randomly generate number of ships based on board size (defined on DI container). will then select random points from the 2D plane and attack. displays attack, board and ship status. 

## How to run test 
1. open console 
2. navigate to project src folder "[project root]\src" 
3. run tests
  ```
  dotnet test
  ``` 

## How to run 
1. open console 
2. navigate to project app folder "[project root]\src\BattleShip" 
3. build project 
  ```
  dotnet build
  ``` 
4. run project
  ```
  dotnet run
  ```




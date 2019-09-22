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




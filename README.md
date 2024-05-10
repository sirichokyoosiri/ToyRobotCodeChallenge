
---

# Toy Robot Console App

This repository contains a console application for simulating a toy robot moving on a table top, along with unit tests using .NET 8.0 and xUnit.

## Setup

1. **Install .NET 8.0 SDK:**
   - Make sure you have the .NET 8.0 SDK installed. You can download it from [here](https://dotnet.microsoft.com/download).

2. **Clone the Repository:**
   ```powershell
   git clone https://github.com/sirichokyoosiri/ToyRobotCodeChallenge.git
   ```

3. **Navigate to Project Directory:**
   ```powershell
   cd ToyRobotCodeChallenge
   ```

## Usage

### Console Application

The console application allows you to control the toy robot using commands of the following form:

- `PLACE X,Y,F`: Places the toy robot on the table at position (X,Y) and facing `NORTH`, `SOUTH`, `EAST`, or `WEST`.
- `MOVE`: Moves the toy robot one unit forward in the direction it is currently facing.
- `LEFT`: Rotates the robot 90 degrees to the left without changing its position.
- `RIGHT`: Rotates the robot 90 degrees to the right without changing its position.
- `REPORT`: Displays the current position (X,Y) and facing direction of the robot.

#### Additional Information

- The table top dimensions are 5 units x 5 units.
- The origin (0,0) can be considered the SOUTH WEST most corner of the table.
- It is required that the first command issued to the robot is a `PLACE` command.
- After the initial `PLACE` command, any sequence of commands may be issued in any order, including another `PLACE` command.
- The application will discard all commands in the sequence until a valid `PLACE` command has been executed.
- The toy robot must not fall off the table during movement, and any move that would cause the robot to fall is ignored.
- You can use the command `EXIT` to exit the application.

#### Example Commands

```plaintext
PLACE 0,0,NORTH
MOVE
REPORT
```
Output: `Output: 0,1,NORTH`

```plaintext
PLACE 0,0,NORTH
LEFT
REPORT
```
Output: `Output: 0,0,WEST`

```plaintext
PLACE 1,2,EAST
MOVE
MOVE
LEFT
MOVE
REPORT
```
Output: `Output: 3,3,NORTH`

### Running the Application

To run the toy robot console application, use the following command:

```powershell
dotnet run --project src\ToyRobotApp\ToyRobotApp.csproj
```

![alt text](./screenshots/example-dotnet-run.png?raw=true "dotnet run")

### Running Unit Tests

To run the unit tests for the toy robot, use the following command:

```powershell
dotnet test tests\ToyRobotApp.Tests
```

This command will execute all the unit tests in the solution using xUnit.

![alt text](./screenshots/example-dotnet-test.png?raw=true "dotnet test")

---

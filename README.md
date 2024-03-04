**Maze Game**

This C# maze game allows users to solve randomly generated mazes using arrow keys for navigation. Additionally, it features an optimal path displayed after solving the maze using the Breadth-First Search (BFS) algorithm. The game also tracks the time taken by the user to complete the maze and provides a notification upon successful completion.

**Installation**

Clone the repository to your local machine.
Open the solution in Visual Studio 2022.
Build the solution to ensure all dependencies are resolved.
Run the application.

**How to Play**

Upon starting the game, there is a menu in which the user can choose to manually solve, using arrow keys, a randomly generated maze that will be displayed.
The user provides the input for the size of the randomly generated maze.
Navigate to the exit marked 'E' while avoiding walls represented by '#' characters.
Once the exit is reached, a notification will appear indicating completion and the time taken to solve the maze.
Alternatively they can choose to solve a randomly generated maze using a Breadth First Search Algorithm

**Features**

Randomly generated mazes: Each time a new game starts, a unique maze is generated for the user to solve.
Arrow key navigation: Users can navigate through the maze using the arrow keys on their keyboard.
Optimal path visualization: After solving the maze using the BFS algorithm, the optimal path will be displayed in the maze.
Time tracking: The game tracks the time taken by the user to solve the maze and displays it upon completion.
Completion notification: Upon reaching the exit of the maze, users receive a notification indicating successful completion along with their time taken.

**Dependencies**

.NET 6

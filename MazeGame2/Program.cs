using MazeGame2;

Console.WriteLine("Welcome to Maze Solver!");

var factory = new MazeFactory();
var menu = new MazeSolverMenu(factory);
var solver = new MazeSolver(new BreadthFirstSearchSolver());

while (true)
{
    menu.DisplayMenu();
    int choice = menu.GetChoice(1, 3);

    if (choice == 3)
        break;

    Maze maze = factory.GetMazeGenerator().GenerateMaze(20, 20);

    switch (choice)
    {
        case 1:
            solver.ManualSolve(maze);
            break;
        case 2:
            solver.SolveWithAlgorithm(maze);
            break;
    }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey(true);
    Console.Clear();
}

Console.WriteLine("Exiting Maze Solver. Goodbye!");
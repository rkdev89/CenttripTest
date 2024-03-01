using MazeGame2;

Console.WriteLine("Welcome to Maze Solver!");

while (true)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("\nChoose an option:");
    Console.WriteLine("1. Solve the maze manually");
    Console.WriteLine("2. Solve the maze using an algorithm");
    Console.WriteLine("3. Exit");
    Console.ResetColor();

    int choice = GetChoice(1, 3);

    if (choice == 3)
        break;

    MazeFactory factory = new MazeFactory();
    IMazeGenerator generator = factory.GetMazeGenerator();
    Maze maze = generator.GenerateMaze(20, 20);

    switch (choice)
    {
        case 1:
            ManualSolve(maze);
            break;
        case 2:
            SolveWithAlgorithm(maze);
            break;
    }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey(true);
    Console.Clear();
}

Console.WriteLine("Exiting Maze Solver. Goodbye!");

static int GetChoice(int min, int max)
{
    int choice;
    while (true)
    {
        Console.Write("Enter your choice: ");
        if (int.TryParse(Console.ReadLine(), out choice) && choice >= min && choice <= max)
            break;
        Console.WriteLine($"Please enter a number between {min} and {max}.");
    }
    return choice;
}

static void ManualSolve(Maze maze)
{
    Console.WriteLine("\nSolving the maze manually...");
    maze.Display();

    DateTime startTime = DateTime.Now;

    while (true)
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        switch (keyInfo.Key)
        {
            case ConsoleKey.UpArrow:
                maze.MovePlayer(0, -1);
                break;
            case ConsoleKey.DownArrow:
                maze.MovePlayer(0, 1);
                break;
            case ConsoleKey.LeftArrow:
                maze.MovePlayer(-1, 0);
                break;
            case ConsoleKey.RightArrow:
                maze.MovePlayer(1, 0);
                break;
            case ConsoleKey.Escape:
                return;
        }

        if (maze.ReachedExit())
        {
            TimeSpan elapsedTime = DateTime.Now - startTime; // Calculate elapsed time
            maze.Display();
            Console.WriteLine($"\nCongratulations! You reached the exit in {elapsedTime.TotalSeconds:F2} seconds.");
            return;
        }

        maze.Display();
    }
}

static void SolveWithAlgorithm(Maze maze)
{
    Console.WriteLine("\nSolving the maze using an algorithm...");
    var solver = new BreadthFirstSearchSolver();
    solver.SolveMaze(maze);
}

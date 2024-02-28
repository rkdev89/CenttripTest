// Create maze factory
using MazeGame2;

//MazeFactory factory = new MazeFactory();
//IMazeGenerator generator = factory.GetMazeGenerator();

//// Generate maze
//Maze maze = generator.GenerateMaze(20, 10);

//// Display maze
//maze.Display();

//// Choose solving algorithm
//IMazeSolver solver = new BreadthFirstSearchSolver();

//// Solve maze
//solver.SolveMaze(maze);

//// Manual solving using arrow keys
//ManualSolve(maze);

//Console.ReadLine(); // Keep console open

//static void ManualSolve(Maze maze)
//{
//    ConsoleKeyInfo keyInfo;
//    do
//    {
//        maze.Display();
//        keyInfo = Console.ReadKey(true);
//        switch (keyInfo.Key)
//        {
//            case ConsoleKey.UpArrow:
//                maze.MovePlayer(0, -1);
//                break;
//            case ConsoleKey.DownArrow:
//                maze.MovePlayer(0, 1);
//                break;
//            case ConsoleKey.LeftArrow:
//                maze.MovePlayer(-1, 0);
//                break;
//            case ConsoleKey.RightArrow:
//                maze.MovePlayer(1, 0);
//                break;
//        }
//        if (maze.ReachedExit())
//        {
//            maze.Display();
//            Console.WriteLine("Congratulations! You reached the exit.");
//            return;
//        }
//    } while (keyInfo.Key != ConsoleKey.Escape);
//}

Console.WriteLine("Welcome to Maze Solver!");

while (true)
{
    Console.WriteLine("\nChoose an option:");
    Console.WriteLine("1. Solve the maze manually");
    Console.WriteLine("2. Solve the maze using an algorithm");
    Console.WriteLine("3. Exit");

    int choice = GetChoice(1, 3);

    if (choice == 3)
        break;

    MazeFactory factory = new MazeFactory();
    IMazeGenerator generator = factory.GetMazeGenerator();
    Maze maze = generator.GenerateMaze(40, 20);

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
            maze.Display();
            Console.WriteLine("\nCongratulations! You reached the exit.");
            return;
        }
        maze.Display();
    }
}

static void SolveWithAlgorithm(Maze maze)
{
    Console.WriteLine("\nSolving the maze using an algorithm...");
    IMazeSolver solver = new BreadthFirstSearchSolver();
    solver.SolveMaze(maze);
}

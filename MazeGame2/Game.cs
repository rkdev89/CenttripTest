namespace MazeGame2;
public class Game
{
    public void Start()
    {
        Console.Title = "Centtrip Maze";
        Console.WriteLine("Welcome to Centtrip's Maze Game!");

        var factory = new MazeFactory();
        var menu = new MazeSolverMenu(factory);
        var solver = new User(new BreadthFirstSearchSolver());

        while (true)
        {
            menu.DisplayMenu();
            int choice = menu.GetChoice(1, 3);

            if (choice == 3)
                break;

            // Prompt user for maze size
            Console.WriteLine("Enter the size of the maze (width height):");
            Console.Write("Width: ");
            int width = int.Parse(Console.ReadLine());
            Console.Write("Height: ");
            int height = int.Parse(Console.ReadLine());

            var maze = factory.GetMazeGenerator().GenerateMaze(width, height);

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
    }
}

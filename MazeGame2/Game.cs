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

            var maze = factory.GetMazeGenerator().GenerateMaze(20, 20);

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

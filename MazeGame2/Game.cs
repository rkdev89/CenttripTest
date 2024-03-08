using MazeGame.Interfaces;

namespace MazeGame2;
public class Game
{
    private readonly IMazeFactory _factory;
    private readonly IMazeSolverMenu _menu;
    private readonly IUser _user;

    public Game(IMazeFactory factory, IMazeSolverMenu menu, IUser user)
    {
        _factory = factory;
        _menu = menu;
        _user = user;
    }
    public void Start()
    {
        Console.Title = "Centtrip Maze";
        Console.WriteLine("Welcome to Centtrip's Maze Game!");

        while (true)
        {
            _menu.DisplayMenu();
            int choice = _menu.GetChoice(1, 3);

            if (choice == 3)
                break;

            // Prompt user for maze size. Maybe this can go in its own private method
            Console.WriteLine("Enter the size of the maze (width height):");
            Console.Write("Width: ");
            int width = int.Parse(Console.ReadLine());
            Console.Write("Height: ");
            int height = int.Parse(Console.ReadLine());

            var maze = _factory.GetMazeGenerator().GenerateMaze(width, height);

            switch (choice)
            {
                case 1:
                    _user.ManualSolve(maze);
                    break;
                case 2:
                    _user.SolveWithAlgorithm(maze);
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }

        Console.WriteLine("Exiting Maze Solver. Goodbye!");
    }
}

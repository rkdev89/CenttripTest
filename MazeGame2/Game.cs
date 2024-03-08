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
        SetWindowTitleAndDisplayWelcomeMessage();

        while (true)
        {
            _menu.DisplayMenu();
            int choice = _menu.GetChoice(1, 3);

            if (choice == 3)
                break;

            var (width, height) = GetUserInputForMazeSize();
            var maze = _factory.GetMazeGenerator().GenerateMaze(width, height);

            UserChoice(choice, maze);

            GetUserInputAndClearTerminal();
        }

        Console.WriteLine("Exiting Maze Solver. Goodbye!");
    }

    #region HelperMethods
    private (int width, int height) GetUserInputForMazeSize()
    {
        Console.WriteLine("Enter the size of the maze (width height):");
        Console.Write("Width: ");
        int width = int.Parse(Console.ReadLine());
        Console.Write("Height: ");
        int height = int.Parse(Console.ReadLine());
        return (width, height);
    }

    private void SetWindowTitleAndDisplayWelcomeMessage()
    {
        Console.Title = "Centtrip Maze";
        Console.WriteLine("Welcome to Centtrip's Maze Game!");
    }
    private void UserChoice(int choice, Maze maze)
    {
        switch (choice)
        {
            case 1:
                _user.ManualSolve(maze);
                break;
            case 2:
                _user.SolveWithAlgorithm(maze);
                break;
        }
    }

    private void GetUserInputAndClearTerminal()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey(true);
        Console.Clear();
    }
    #endregion
}

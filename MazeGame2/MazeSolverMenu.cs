namespace MazeGame2;
public class MazeSolverMenu
{
    private readonly MazeFactory _factory;

    public MazeSolverMenu(MazeFactory factory)
    {
        _factory = factory;
    }

    public void DisplayMenu()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\nChoose an option:");
        Console.WriteLine("1. Solve the maze manually");
        Console.WriteLine("2. Solve the maze using an algorithm");
        Console.WriteLine("3. Exit");
        Console.ResetColor();
    }

    public int GetChoice(int min, int max)
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
}

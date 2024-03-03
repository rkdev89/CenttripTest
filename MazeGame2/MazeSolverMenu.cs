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
        Console.WriteLine("\nChoose an option:");
        Console.WriteLine("1. Solve a random maze by user input");
        Console.WriteLine("2. Solve a random maze using an algorithm");
        Console.WriteLine("3. Exit");
        Console.ResetColor();
    }

    public int GetChoice(int min, int max)
    {
        int choice;
        do
        {
            Console.Write($"Enter your choice({min}-{max}): ");
        } while (!int.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max);

        return choice;
    }
}

namespace MazeGame2;
public class Maze
{
    private readonly char[,] grid;
    private readonly int width;
    private readonly int height;
    private readonly Random random;
    private int playerX;
    private int playerY;

    public int Width => width;
    public int Height => height;
    public char[,] Grid => grid;

    public Maze(int width, int height)
    {
        this.width = width;
        this.height = height;
        grid = new char[width, height];
        random = new Random();
        playerX = 0;
        playerY = 0;
    }

    // Initialize the maze with walls and open spaces
    public void Initialize()
    {
        // Dummy implementation: create a maze with random walls
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (random.Next(100) < 20) // 30% chance to be a wall
                    grid[i, j] = '#';
                else
                    grid[i, j] = ' ';
            }
        }
        // Set exit
        grid[width - 1, height - 1] = 'E';
    }

    // Display the maze
    public void Display()
    {
        Console.Clear();
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (playerX == j && playerY == i)
                    Console.Write('P'); // Player
                else
                    Console.Write(grid[j, i]);
            }
            Console.WriteLine();
        }
    }

    // Move player
    public void MovePlayer(int dx, int dy)
    {
        int newX = playerX + dx;
        int newY = playerY + dy;
        if (IsValidPosition(newX, newY))
        {
            playerX = newX;
            playerY = newY;
        }
    }

    // Check if a position is within the maze boundaries and not a wall
    public bool IsValidPosition(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height && grid[x, y] != '#';
    }

    // Check if player reached exit
    public bool ReachedExit()
    {
        return playerX == width - 1 && playerY == height - 1;
    }
}

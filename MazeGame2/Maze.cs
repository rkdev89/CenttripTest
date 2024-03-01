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

    public void Initialize()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (random.Next(100) < 20)
                    grid[i, j] = '#';
                else
                    grid[i, j] = ' ';
            }
        }
        grid[width - 1, height - 1] = 'E';
    }

    public void Display()
    {
        Console.Clear();
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (playerX == j && playerY == i)
                    Console.Write('P');
                else
                    Console.Write(grid[j, i]);
            }
            Console.WriteLine();
        }
    }

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

    public bool IsValidPosition(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height && grid[x, y] != '#';
    }

    public bool ReachedExit()
    {
        return playerX == width - 1 && playerY == height - 1;
    }
}

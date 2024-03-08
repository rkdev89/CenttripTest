namespace MazeGame2;
public class Maze
{
    private readonly char[,] grid;
    private readonly int width;
    private readonly int height;
    private readonly Random random;
    private int positionX;
    private int positionY;

    public int Width => width;
    public int Height => height;
    public char[,] Grid => grid;

    public Maze(int width, int height)
    {
        this.width = width;
        this.height = height;
        grid = new char[width, height];
        random = new Random();
        positionX = 0;
        positionY = 0;
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
        grid[width - 1, height - 1] = 'X';
    }

    public void Display()
    {
        Console.Clear();
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (positionX == j && positionY == i)
                    Console.Write('O');
                else
                    Console.Write(grid[j, i]);
            }
            Console.WriteLine();
        }
    }

    public void MovePlayer(int directionX, int directionY)
    {
        int newX = positionX + directionX;
        int newY = positionY + directionY;
        if (IsValidPosition(newX, newY))
        {
            positionX = newX;
            positionY = newY;
        }
    }

    public bool IsValidPosition(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height && grid[x, y] != '#';
    }

    public bool ReachedExit()
    {
        return positionX == width - 1 && positionY == height - 1;
    }
}

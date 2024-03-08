using MazeGame.Interfaces;

namespace MazeGame2;
public class User : IUser
{
    private readonly IMazeSolver _solver;

    public User(IMazeSolver solver)
    {
        _solver = solver;
    }

    public void ManualSolve(Maze maze)
    {
        Console.WriteLine("\nSolving the maze manually...");
        maze.Display();

        DateTime startTime = DateTime.Now;

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
                TimeSpan elapsedTime = DateTime.Now - startTime;
                maze.Display();
                Console.WriteLine($"\nCongratulations! You reached the exit in {elapsedTime.TotalSeconds:F2} seconds.");
                return;
            }

            maze.Display();
        }
    }

    public void SolveWithAlgorithm(Maze maze)
    {
        Console.WriteLine("\nSolving the maze using an algorithm...");
        _solver.SolveMaze(maze);
    }
}

using System.Diagnostics;
using MazeGame.Interfaces;

namespace MazeGame2;
public class BreadthFirstSearchSolver : IMazeSolver
{
    private Stopwatch _stopwatch;
    public void SolveMaze(Maze maze)
    {
        _stopwatch = Stopwatch.StartNew();
        Console.WriteLine("Solving maze using Breadth First Search...");
        var start = new Tuple<int, int>(0, 0);
        var target = new Tuple<int, int>(maze.Width - 1, maze.Height - 1);

        // Queue for BFS
        var queue = new Queue<Tuple<int, int>>();
        // Dictionary to track visited nodes and their parents
        var visited = new Dictionary<Tuple<int, int>, Tuple<int, int>>();

        queue.Enqueue(start);
        visited[start] = null;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current.Equals(target))
            {
                // Reached the target, construct the path
                ConstructPath(maze, visited, current);
                return;
            }

            int x = current.Item1;
            int y = current.Item2;

            // Check neighbors
            CheckNeighbor(maze,queue, visited, x - 1, y, current); // Left
            CheckNeighbor(maze, queue, visited, x + 1, y, current); // Right
            CheckNeighbor(maze, queue, visited, x, y - 1, current); // Up
            CheckNeighbor(maze, queue, visited, x, y + 1, current); // Down

            maze.Display();
        }

        Console.WriteLine("No path found.");
    }
    private void CheckNeighbor(Maze maze, Queue<Tuple<int, int>> queue, Dictionary<Tuple<int, int>, Tuple<int, int>> visited, int x, int y, Tuple<int, int> parent)
    {
        if (x < 0 || y < 0 || x >= maze.Width || y >= maze.Height) // Check if coordinates are within bounds
            return;

        var neighbor = new Tuple<int, int>(x, y);
        if (visited.ContainsKey(neighbor) || !maze.IsValidPosition(x, y))
            return;

        queue.Enqueue(neighbor);
        visited[neighbor] = parent;
    }
    private void ConstructPath(Maze maze, Dictionary<Tuple<int, int>, Tuple<int, int>> visited, Tuple<int, int> current)
    {

        while (visited[current] != null)
        {
            maze.Grid[current.Item1, current.Item2] = '*';

            // Ensure cursor position stays within the console buffer
            int cursorLeft = Math.Max(0, Math.Min(Console.WindowWidth - 1, current.Item2));
            int cursorTop = Math.Max(0, Math.Min(Console.WindowHeight - 1, current.Item1));

            // Move cursor to the position of the '*'
            Console.SetCursorPosition(cursorLeft, cursorTop);

            // Print '*' character
            Console.Write('*');

            current = visited[current];
        }
        maze.Display();
        Console.WriteLine($"Maze solved using Breadth First Search in {_stopwatch.ElapsedMilliseconds}ms.");
        _stopwatch.Stop();
    }
}
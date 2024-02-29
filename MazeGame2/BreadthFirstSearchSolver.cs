namespace MazeGame2;
public class BreadthFirstSearchSolver : IMazeSolver
{
    public void SolveMaze(Maze maze)
    {
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
            // Save current cursor position
            int cursorLeft = Console.CursorLeft;
            int cursorTop = Console.CursorTop;

            // Move cursor to the position of the '*'
            Console.SetCursorPosition(current.Item2, current.Item1);

            // Set console text color to blue
            Console.ForegroundColor = ConsoleColor.Blue;

            // Print '*' character in blue
            Console.Write('*');

            // Reset console text color to default
            Console.ResetColor();

            // Restore cursor position
            Console.SetCursorPosition(cursorLeft, cursorTop);
            current = visited[current];
        }
        maze.Display();
        Console.WriteLine("Maze solved using Breadth First Search.");
    }
}
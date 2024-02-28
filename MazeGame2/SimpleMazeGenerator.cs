namespace MazeGame2;
public class SimpleMazeGenerator : IMazeGenerator
{
    public Maze GenerateMaze(int width, int height)
    {
        // Create a maze with random walls
        var maze = new Maze(width, height);
        maze.Initialize();
        return maze;
    }
}

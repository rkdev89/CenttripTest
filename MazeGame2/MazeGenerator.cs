using MazeGame.Interfaces;

namespace MazeGame2;
public class MazeGenerator : IMazeGenerator
{
    public Maze GenerateMaze(int width, int height)
    {
        var maze = new Maze(width, height);
        maze.Initialize();
        return maze;
    }
}

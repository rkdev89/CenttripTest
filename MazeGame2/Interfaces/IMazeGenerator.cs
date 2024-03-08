using MazeGame2;

namespace MazeGame.Interfaces;
public interface IMazeGenerator
{
    Maze GenerateMaze(int width, int height);
}

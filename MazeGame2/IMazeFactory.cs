using MazeGame2;

namespace MazeGame;
public interface IMazeFactory
{
    IMazeGenerator GetMazeGenerator();
}

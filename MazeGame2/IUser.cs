using MazeGame2;

namespace MazeGame;
public interface IUser
{
    void ManualSolve(Maze maze);
    void SolveWithAlgorithm(Maze maze);
}

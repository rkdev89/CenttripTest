using MazeGame2;

namespace MazeGame.Interfaces;
public interface IUser
{
    void ManualSolve(Maze maze);
    void SolveWithAlgorithm(Maze maze);
}

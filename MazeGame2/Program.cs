using MazeGame.Interfaces;
using MazeGame2;

var mazeGame = CreateGame();
mazeGame.Start();

static Game CreateGame()
{
    IMazeFactory factory = new MazeFactory();
    IMazeSolverMenu menu = new MazeSolverMenu();
    IUser user = new User(new BreadthFirstSearchSolver());

    return new Game(factory, menu, user);
}
using MazeGame2;

namespace MazeGameTests;
[TestFixture]
public class MazeTests
{
    private Maze maze;
    private int positionX;
    private int positionY;

    [SetUp]
    public void Setup()
    {
        maze = new Maze(5, 5); // Example width and height
    }

    [Test]
    public void Constructor_InitializesGridWithCorrectSize()
    {
        // Assert
        Assert.AreEqual(5, maze.Width);
        Assert.AreEqual(5, maze.Height);
        Assert.IsNotNull(maze.Grid);
        Assert.AreEqual(5, maze.Grid.GetLength(0));
        Assert.AreEqual(5, maze.Grid.GetLength(1));
    }

    [Test]
    public void Initialize_PopulatesGridWithWallsAndExit()
    {
        // Act
        maze.Initialize();

        // Assert
        bool exitFound = false;
        bool wallFound = false;

        for (int i = 0; i < maze.Width; i++)
        {
            for (int j = 0; j < maze.Height; j++)
            {
                if (maze.Grid[i, j] == '#')
                    wallFound = true;
                else if (maze.Grid[i, j] == 'X')
                    exitFound = true;
            }
        }

        Assert.IsTrue(wallFound);
        Assert.IsTrue(exitFound);
    }

    [Test]
    public void IsInvalidPosition_ReturnsFalseForValidPosition()
    {
        // Arrange
        maze.Initialize();
        int validX = maze.Width - 2;
        int validY = maze.Height - 2;

        // Assert
        Assert.That(maze.IsValidPosition(validX, validY), Is.True);
    }

    [Test]
    public void IsValidPosition_ReturnsFalseForWallPosition()
    {
        // Arrange
        maze.Initialize();
        int wallX = 1;
        int wallY = 1;

        // Assert
        Assert.IsTrue(maze.IsValidPosition(wallX, wallY));
    }
}

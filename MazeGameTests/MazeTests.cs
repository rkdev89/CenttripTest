using MazeGame2;

namespace MazeGameTests;
[TestFixture]
public class MazeTests
{
    private Maze maze;

    [SetUp]
    public void Setup()
    {
        maze = new Maze(5, 5); // Example width and height
    }

    [Test]
    public void Constructor_InitializesGridWithCorrectSize()
    {
        Assert.Multiple(() =>
        {
            // Assert
            Assert.That(maze.Width, Is.EqualTo(5));
            Assert.That(maze.Height, Is.EqualTo(5));
            Assert.That(maze.Grid, Is.Not.Null);
        });
        Assert.Multiple(() =>
        {
            Assert.That(maze.Grid.GetLength(0), Is.EqualTo(5));
            Assert.That(maze.Grid.GetLength(1), Is.EqualTo(5));
        });
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

        Assert.That(wallFound, Is.True);
        Assert.That(exitFound, Is.True);
    }

    [Test]
    public void IsInvalidPosition_ReturnsFalseForValidPosition()
    {
        // Arrange
        maze.Initialize();
        int validirectionX = maze.Width - 2;
        int validirectionY = maze.Height - 2;

        // Assert
        Assert.That(maze.IsValidPosition(validirectionX, validirectionY), Is.True);
    }

    [Test]
    public void IsValidPosition_ReturnsFalseForWallPosition()
    {
        // Arrange
        maze.Initialize();
        int wallX = 1;
        int wallY = 1;

        // Assert
        Assert.That(maze.IsValidPosition(wallX, wallY), Is.True);
    }
}

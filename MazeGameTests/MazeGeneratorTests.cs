using MazeGame2;

namespace MazeGameTests;
[TestFixture]
public class MazeGeneratorTests
{
    [Test]
    public void GenerateMaze_ReturnsMazeWithCorrectDimensions()
    {
        // Arrange
        int width = 5;
        int height = 7;
        MazeGenerator mazeGenerator = new MazeGenerator();

        // Act
        Maze maze = mazeGenerator.GenerateMaze(width, height);

        // Assert
        Assert.IsNotNull(maze);
        Assert.AreEqual(width, maze.Width);
        Assert.AreEqual(height, maze.Height);
    }
}

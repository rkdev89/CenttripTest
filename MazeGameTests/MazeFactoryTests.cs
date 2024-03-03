using MazeGame2;

namespace MazeGameTests;
[TestFixture]
public class MazeFactoryTests
{
    [Test]
    public void GetMazeGenerator_ReturnsInstanceOfMazeGenerator()
    {
        // Arrange
        MazeFactory factory = new MazeFactory();

        // Act
        IMazeGenerator mazeGenerator = factory.GetMazeGenerator();

        // Assert
        Assert.IsNotNull(mazeGenerator);
        Assert.IsInstanceOf<MazeGenerator>(mazeGenerator);
    }
}

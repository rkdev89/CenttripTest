namespace MazeGame2;
public class MazeFactory
{
    public IMazeGenerator GetMazeGenerator()
    {
        // Currently, only one generator is implemented
        return new SimpleMazeGenerator();
    }
}

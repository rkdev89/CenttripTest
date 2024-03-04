namespace MazeGame2;
public class MazeFactory
{
    public IMazeGenerator GetMazeGenerator()
    {
        return new MazeGenerator();
    }
}

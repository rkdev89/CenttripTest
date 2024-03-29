﻿using MazeGame.Interfaces;

namespace MazeGame2;
public class MazeFactory : IMazeFactory
{
    public IMazeGenerator GetMazeGenerator()
    {
        return new MazeGenerator();
    }
}

public enum Direction { Left, Up, Right, Down }
internal class ProceduallyGeneratingDungeons
{
    public char[,] Dungeon { get; set; }
    public Random Random { get; set; }
    public int previousY { get; private set; }
    public int previousX { get; private set; }
    public ProceduallyGeneratingDungeons(int height, int width)
    {
        Dungeon = CreateBaseLayout(height, width);
        Random = new();
        previousX = Dungeon.GetLength(1) / 2;
        previousY = Dungeon.GetLength(0) / 2;

    }
    
    public void GenerateNewDungeon()
    {
        for (int i = 0; i < 10; i++)
        {
            RandomWalk();
            CreateCorridor();
        }
        AddElements();
    }
    
    public char[,] CreateBaseLayout(int height, int width)
    {
        int Height = height;
        int Width = width;

        char[,] baseLayout = new char[Height, Width];
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                baseLayout[i, j] = '#';
            }
        }

        return baseLayout;
    }

    public void RandomWalk()
    {
        int steps = Random.Next(70, 120);

        for (int i = 0; i < steps; i++)
        {

            var nextstep = Nextstep(previousY, previousX);

            bool isYInRange = 0 < nextstep.Item1 && nextstep.Item1 < Dungeon.GetLength(0) - 1;
            bool isXInRange = 0 < nextstep.Item2 && nextstep.Item2 < Dungeon.GetLength(1) - 1;

            if (isYInRange && isXInRange)
            {
                previousY = nextstep.Item1;
                previousX = nextstep.Item2;

                Dungeon[previousY, previousX] = ' ';
            }
        }
    }

    public ValueTuple<int, int> Nextstep(int y, int x)
    {
        Direction WalkDirection = (Direction)Random.Next(0, 4);

        switch (WalkDirection)
        {
            case Direction.Left:
                --x;
                break;
            case Direction.Up:
                --y;
                break;
            case Direction.Down:
                ++y;
                break;
            case Direction.Right:
                ++x;
                break;
        }
        (int, int) nextStep = (y, x);
        return nextStep;
    }
    public void CreateCorridor()
    {
        int corridorLength = 12;
        Direction CorridorDirection = (Direction)Random.Next(0, 4);

        switch (CorridorDirection)
        {
            case Direction.Left:
                for (int i = 0; i < corridorLength; i++)
                {
                    if (previousX - 1 > 0)
                    {
                        --previousX;
                    }
                    else
                    {
                        break;
                    }
                    Dungeon[previousY, previousX] = ' ';
                }
                break;
            case Direction.Up:
                for (int i = 0; i < corridorLength; i++)
                {
                    if (previousY - 1 > 0)
                    {
                        --previousY;
                    }
                    else
                    {
                        break;
                    }
                    Dungeon[previousY, previousX] = ' ';
                }
                break;
            case Direction.Down:
                for (int i = 0; i < corridorLength; i++)
                {
                    if (previousY + 1 < Dungeon.GetLength(0) - 1)
                    {
                        ++previousY;
                    }
                    else
                    {
                        break;
                    }
                    Dungeon[previousY, previousX] = ' ';
                }
                break;
            case Direction.Right:
                for (int i = 0; i < corridorLength; i++)
                {
                    if (previousX + 1 < Dungeon.GetLength(1) - 1)
                    {
                        ++previousX;
                    }
                    else
                    {
                        break;
                    }
                    Dungeon[previousY, previousX] = ' ';
                }
                break;
        }
    }
    public void AddElements()
    {
        int numberOfRats = Random.Next(8, 16);
        int numberOfSnakes = Random.Next(5, 11);
        while (true) // Add player startposition
        {
            int Row = Random.Next(1, Dungeon.GetLength(0));
            int Col = Random.Next(1, Dungeon.GetLength(1));

            if (Dungeon[Row, Col] == ' ')
            {
                Dungeon[Row, Col] = '@';
                break;
            }
        }
        while (true) // Add dungeon exit
        {
            int Row = Random.Next(1, Dungeon.GetLength(0));
            int Col = Random.Next(1, Dungeon.GetLength(1));

            if (Dungeon[Row, Col] == ' ')
            {
                Dungeon[Row, Col] = '>';
                break;
            }
        }
        for (int i = 0; i < numberOfRats; i++)
        {
            while (true)
            {
                int Row = Random.Next(1, Dungeon.GetLength(0));
                int Col = Random.Next(1, Dungeon.GetLength(1));

                if (Dungeon[Row, Col] == ' ')
                {
                    Dungeon[Row, Col] = 'r';
                    break;
                }
            }
        }
        for (int i = 0; i < numberOfSnakes; i++)
        {
            while (true)
            {
                int Row = Random.Next(1, Dungeon.GetLength(0));
                int Col = Random.Next(1, Dungeon.GetLength(1));

                if (Dungeon[Row, Col] == ' ')
                {
                    Dungeon[Row, Col] = 's';
                    break;
                }
            }
        }
    }
}





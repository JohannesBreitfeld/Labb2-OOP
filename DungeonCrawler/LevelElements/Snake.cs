
internal class Snake : Enemy
{
    public Snake(Position position)
    {
        Position = position;
        ElementDesign = 's';
        Color = ConsoleColor.Green;
        Name = "Snake";
        Health = 25;
        AttackDice = new Dice(_random, 3, 4, 2);
        DefenceDice = new Dice(_random, 1, 8, 5);
    }

    public override void Update(Position playerPosition, LevelData levelData)
    {
        if (Position.DistanceTo(playerPosition) > 2)
        {
            return;
        }

        bool isCloserHorizontalThanVertical = Position.HorisontalDistanceTo(playerPosition) < Position.VerticalDistanceTo(playerPosition);

        Position newPosition = GetNewPosition(playerPosition, isCloserHorizontalThanVertical);

        bool isNewPositionOccupied = GetNewPositionStatus(levelData, newPosition);

        if (!isNewPositionOccupied)
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(' ');
            Position = newPosition;
        }
            Draw(playerPosition);
    }

    private Position GetNewPosition(Position playerPosition, bool isCloserHorizontalThanVertical)
    {
        Position newPosition = Position;

        if (isCloserHorizontalThanVertical)
        {
            bool isLeftofPlayer = (Position.X - playerPosition.X < 0);

            newPosition = isLeftofPlayer
                ? new Position { X = Position.X - 1, Y = Position.Y }
                : new Position { X = Position.X + 1, Y = Position.Y };
        }
        else
        {
            bool isAbovePlayer = Position.Y - playerPosition.Y < 0;
            newPosition = isAbovePlayer
               ? new Position { X = Position.X, Y = Position.Y - 1 }
               : new Position { X = Position.X, Y = Position.Y + 1 };
        }

        return newPosition;
    }
}
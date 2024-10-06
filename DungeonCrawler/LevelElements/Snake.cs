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

    public override void Update(Player player, LevelData levelData)
    {
        if (Position.DistanceTo(player.Position) > 2)
        {
            return;
        }

        bool isCloserHorizontalThanVertical = Position.HorisontalDistanceTo(player.Position) < Position.VerticalDistanceTo(player.Position);

        Position newPosition = GetNewPosition(player, isCloserHorizontalThanVertical);

        bool isNewPositionOccupied = GetNewPositionStatus(levelData, newPosition);

        if (!isNewPositionOccupied)
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(' ');
            Position = newPosition;
        }
        Draw(player);
    }

    private Position GetNewPosition(Player player, bool isCloserHorizontalThanVertical)
    {
        Position newPosition = Position;

        if (isCloserHorizontalThanVertical)
        {
            bool isLeftofPlayer = (Position.X - player.Position.X < 0);

            newPosition = isLeftofPlayer
                ? new Position { X = Position.X - 1, Y = Position.Y }
                : new Position { X = Position.X + 1, Y = Position.Y };
        }
        else
        {
            bool isAbovePlayer = Position.Y - player.Position.Y < 0;
            newPosition = isAbovePlayer
               ? new Position { X = Position.X, Y = Position.Y - 1 }
               : new Position { X = Position.X, Y = Position.Y + 1 };
        }

        return newPosition;
    }
}
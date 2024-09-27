using System.Xml.Linq;

internal enum MovementDirection { left, right, up, down }

internal class Rat : Enemy
{
    public Rat(Position position)
    {
        Position = position;
        ElementDesign = 'r';
        Color = ConsoleColor.Red;
        Name = "Rat";
        Health = 10;
        _random = new();
    }

    public override void Update(Position playerPosition, LevelData levelData)
    {
        MovementDirection direction = (MovementDirection)_random.Next(0, 4);

        Position newPosition = GetNewPosition(direction);

        bool isNextPositionOccupied = GetNewPositionStatus(levelData, newPosition);

        if (playerPosition.X == newPosition.X && playerPosition.Y == newPosition.Y)
        {
            isNextPositionOccupied = true;
        }

        if (!isNextPositionOccupied)
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(' ');
            Position = newPosition;
            Draw(playerPosition);
        }
    }

    private Position GetNewPosition(MovementDirection direction)
    {
        Position newPosition = Position;
        switch (direction)
        {
            case MovementDirection.left:
                newPosition = new Position { X = Position.X - 1, Y = Position.Y };
                break;
            case MovementDirection.up:
                newPosition = new Position { X = Position.X, Y = Position.Y - 1 };
                break;
            case MovementDirection.down:
                newPosition = new Position { X = Position.X, Y = Position.Y + 1 };
                break;
            case MovementDirection.right:
                newPosition = new Position { X = Position.X + 1, Y = Position.Y };
                break;
        }

        return newPosition;
    }
}
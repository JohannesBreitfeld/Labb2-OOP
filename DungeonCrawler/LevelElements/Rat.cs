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
        AttackDice = new Dice(_random, 1, 6, 3);
        DefenceDice = new Dice(_random, 1, 6, 1);
    }

    public override void Update(Player player, LevelData levelData)
    {
        MovementDirection direction = (MovementDirection)_random.Next(0, 4);

        Position newPosition = GetNewPosition(direction);

        bool isNewPositionOccupied = GetNewPositionStatus(levelData, newPosition);

        if (player.Position.X == newPosition.X && player.Position.Y == newPosition.Y)
        {
            isNewPositionOccupied = true;
            combat.EnemyAttack(player, this, 1);
            combat.PlayerAttack(player, this, 2);
        }

        if (!isNewPositionOccupied)
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(' ');
            Position = newPosition;
        }
            Draw(player);
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
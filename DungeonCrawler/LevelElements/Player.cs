
using System;

internal class Player : LevelElement
{
    public bool NextDungeon { get; set; } = false;
    public Random _random = new Random();
    public string Name { get; set; }
    public int Health { get; set; } = 100;
    public Dice AttackDice { get; } 
    public Dice DefenceDice { get; }
    public Combat combat { get; }
    public Player(Position position, string name)
    {
        Position = position;
        Name = name;
        ElementDesign = '@';
        Color = ConsoleColor.Yellow;
        AttackDice = new Dice(_random, 2, 6, 2);
        DefenceDice = new Dice(_random, 2, 6, 0);
        combat = new();
    }
    public void Update(ConsoleKeyInfo cki, LevelData levelData)
    {
        Position newPosition = NewPosition(cki);
        (bool IsOccupied, Enemy EnemyToAttack)newPositionStatus = CheckNewPosition(levelData, newPosition);
        bool hasMoved = !(newPosition.X == Position.X && newPosition.Y == Position.Y);

        if (newPositionStatus.EnemyToAttack != null)
        {
            combat.PlayerAttack(this, newPositionStatus.EnemyToAttack);
            if (newPositionStatus.EnemyToAttack.Health > 0)
            {
                combat.EnemyAttack(this, newPositionStatus.EnemyToAttack);
            }
        }
        if (!newPositionStatus.IsOccupied && hasMoved)
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(' ');
            Position = newPosition;
            Draw();
        }
    }
    private Position NewPosition(ConsoleKeyInfo cki)
    {
        Position newPosition = Position;
        switch (cki.Key)
        {
            case ConsoleKey.LeftArrow:
                newPosition = new Position { X = Position.X - 1, Y = Position.Y };
                break;
            case ConsoleKey.UpArrow:
                newPosition = new Position { X = Position.X, Y = Position.Y - 1 };
                break;
            case ConsoleKey.DownArrow:
                newPosition = new Position { X = Position.X, Y = Position.Y + 1 };
                break;
            case ConsoleKey.RightArrow:
                newPosition = new Position { X = Position.X + 1, Y = Position.Y };
                break;
            default:
                break;
        }

        return newPosition;
    }
    private ValueTuple<bool, Enemy> CheckNewPosition(LevelData levelData, Position newPosition)
    {
        bool isOccupied = false;
        Enemy enemyToAttack = null;
        foreach (var element in levelData.Elements)
        {
            if (element.Position.X == newPosition.X && element.Position.Y == newPosition.Y)
            {
                isOccupied = true;
                if (element is Enemy enemy)
                {
                    enemyToAttack = enemy;
                } 
                else if (element is DungeonExit)
                {
                    NextDungeon = true;
                }
            }
        }
        var NewPositionStatus = (isOccupied,enemyToAttack);
        return NewPositionStatus;
    }

    public void Draw()
    { 
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.Write(ElementDesign);
        Console.ResetColor();
    }
}
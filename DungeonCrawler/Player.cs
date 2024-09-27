
internal class Player
{
    public Position Position { get; set; }
    public char ElementDesign { get; set; }
    public ConsoleColor Color { get; set; }
    public string Name { get; set; }
    public int Health { get; set; }
    public Dice AttackDice { get; set; }
    public Dice DefenceDice { get; set; }
    public Player(Position position)
    {
        Position = position;
        ElementDesign = '@';
        Color = ConsoleColor.Yellow;
        Name = "Player";
        Health = 100;
    }
    public Position Update(ConsoleKeyInfo cki, LevelData levelData)
    {
        Position newPosition = NewPosition(cki);

        bool isNewPositionOccupied = GetNewPositionStatus(levelData, newPosition);
        bool hasMoved = !(newPosition.X == Position.X && newPosition.Y == Position.Y);

        if (!isNewPositionOccupied && hasMoved)
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(' ');
            Position = newPosition;
            Draw();
        }
        return Position;
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
    private static bool GetNewPositionStatus(LevelData levelData, Position newPosition)
    {
        bool isOccupied = false;
        foreach (var element in levelData.Elements)
        {
            if (element.Position.X == newPosition.X && element.Position.Y == newPosition.Y)
            {
                isOccupied = true;
            }
        }

        return isOccupied;
    }
    public void Draw()
    { 
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.Write(ElementDesign);
        Console.ResetColor();
    }
}
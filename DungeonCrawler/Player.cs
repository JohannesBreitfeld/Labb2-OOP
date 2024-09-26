
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
    public void Update(ConsoleKeyInfo cki, LevelData levelData)
    {
        Position oldPosition = Position;
        bool isOccupied = false;

        switch (cki.Key)
        {
        case ConsoleKey.LeftArrow:
            Position = new Position { X = Position.X - 1, Y = Position.Y };
            break;
        case ConsoleKey.UpArrow:
            Position = new Position { X = Position.X , Y = Position.Y -1 };
            break;
        case ConsoleKey.DownArrow:
            Position = new Position { X = Position.X , Y = Position.Y +1 };
            break;
        case ConsoleKey.RightArrow:
            Position = new Position { X = Position.X +1 , Y = Position.Y };
            break;
        }

        foreach (var item in levelData.Elements)
        {
            if (item.Position.X == Position.X && item.Position.Y == Position.Y)
            {
                isOccupied = true;
            }
        }

        if (!isOccupied)
        {
            Draw();
            Console.SetCursorPosition(oldPosition.X, oldPosition.Y);
            Console.Write(' ');
        }
        else
        {
            Position = oldPosition;
        }
    }
    public void Draw()
    {
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.Write(ElementDesign);
        Console.ResetColor();
    }

}
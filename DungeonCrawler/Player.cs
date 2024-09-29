
internal class Player : LevelElement
{
    public Random _random = new Random();
    public string Name { get; set; }
    public int Health { get; set; } = 100;
    private Dice AttackDice { get; set; } 
    private Dice DefenceDice { get; set; }
    public Player(Position position)
    {
        Position = position;
        Name = "Player";
        ElementDesign = '@';
        Color = ConsoleColor.Yellow;
        AttackDice = new Dice(_random, 2, 6, 2);
        DefenceDice = new Dice(_random, 2, 6, 0);
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
    private bool GetNewPositionStatus(LevelData levelData, Position newPosition)
    {
        bool isOccupied = false;
        foreach (var element in levelData.Elements)
        {
            if (element.Position.X == newPosition.X && element.Position.Y == newPosition.Y)
            {
                isOccupied = true;
                if (element is Enemy enemy)
                {
                    Attack(enemy);
                } 
            }
        }

        return isOccupied;
    }

    private void Attack(Enemy enemy)
    {
        int attackThrow = AttackDice.Throw();
        int defenseThrow = enemy.DefenceDice.Throw();
        int attackDamage = attackThrow - defenseThrow;
        if (attackDamage > 0)
        {
            enemy.Health -= attackDamage;
        }
        Console.SetCursorPosition(0, 1);
        Console.ForegroundColor = Color;
        
        if (enemy.Health <= 0)
        {
            Console.WriteLine($"You (ATK: {AttackDice} => {attackThrow}) attacked the {enemy.Name} " +
                $"(DEF: {enemy.DefenceDice} => {defenseThrow}), killing it instantly.");
        }
        else
        {
            switch (attackDamage)
            {
                case <=0:
                    {
                        Console.WriteLine($"You (ATK: {AttackDice} => {attackThrow}) attacked the {enemy.Name} " +
                            $"(DEF: {enemy.DefenceDice} => {defenseThrow}), without wounding it.");
                        break;
                    }
                case 1: 
                case 2: 
                case 3:
                    {
                        Console.WriteLine($"You (ATK: {AttackDice} => {attackThrow}) attacked the {enemy.Name} " +
                            $"(DEF: {enemy.DefenceDice} => {defenseThrow}), slightly wounding it.");
                        break;
                    }
                case 4: 
                case 5: 
                case 6:
                    {
                        Console.WriteLine($"You (ATK: {AttackDice} => {attackThrow}) attacked the {enemy.Name} " +
                            $"(DEF: {enemy.DefenceDice} => {defenseThrow}), moderatly wounding it.");
                        break;
                    }
                default:
                    {
                        Console.WriteLine($"You (ATK: {AttackDice} => {attackThrow}) attacked the {enemy.Name} " +
                            $"(DEF: {enemy.DefenceDice} => {defenseThrow}), severly wounding it.");
                        break;
                    }
            }
            Thread.Sleep(500);
            Defend(enemy);     
        }

    }

    private void Defend(Enemy enemy)
    {
        int attackThrow = enemy.AttackDice.Throw();
        int defenseThrow = DefenceDice.Throw();
        int attackDamage = attackThrow - defenseThrow;
        if (attackDamage > 0)
        {
            Health -= attackDamage;
        }
        Console.SetCursorPosition(0, 2);
        Console.ForegroundColor = ConsoleColor.Red;

        switch (attackDamage)
        {
            case <=0:
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"The {enemy.Name} (ATK: {enemy.AttackDice} => {attackThrow}) attacked you " +
                        $"(DEF: {DefenceDice} => {defenseThrow}), but did not manage to do any damage.");
                    break;
                }
            case 1:
            case 2:
            case 3:
                {
                    Console.WriteLine($"The {enemy.Name} (ATK: {enemy.AttackDice} => {attackThrow}) attacked you " +
                        $"(DEF: {DefenceDice} => {defenseThrow}), sligthly wounding you.");
                    break;
                }
            case 4:
            case 5:
            case 6:
                {
                    Console.WriteLine($"The {enemy.Name} (ATK: {enemy.AttackDice} => {attackThrow}) attacked you " +
                        $"(DEF: {DefenceDice} => {defenseThrow}), moderately wounding you.");
                    break;
                }
            default:
                {
                    Console.WriteLine($"The {enemy.Name} (ATK: {enemy.AttackDice} => {attackThrow}) attacked you " +
                        $"(DEF: {DefenceDice} => {defenseThrow}), severly wounding you.");
                    break;
                }
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
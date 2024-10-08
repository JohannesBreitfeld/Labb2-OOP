﻿
internal abstract class Enemy : LevelElement
{
    protected Random _random = new Random();
    public string Name { get; set; }
    public int Health { get; set; }
    public Dice AttackDice { get; set; }
    public Dice DefenceDice { get; set; }
    protected Combat combat = new();
    public abstract void Update(Player player, LevelData levelData);
    protected static bool GetNewPositionStatus(LevelData levelData, Position newPosition)
    {
        bool isNextPositionOccupied = false;

        foreach (var element in levelData.Elements)
        {
            if (element.Position.X == newPosition.X && element.Position.Y == newPosition.Y)
            {
                isNextPositionOccupied = true;
            }
        }
        return isNextPositionOccupied;
    }
    public override void Draw(Player player)
    {
        if (player.Position.DistanceTo(Position) < 5)
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(ElementDesign);
            Console.ResetColor();
        }
        else
        { 
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(' ');
        }
    }
}


internal class Wall : LevelElement
{
    public Wall(Position position)
    {
        Position = position;
        ElementDesign = '#';
        Color = ConsoleColor.Gray;
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
    }
}
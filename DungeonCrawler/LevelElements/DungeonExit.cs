
internal class DungeonExit : LevelElement
{
    public DungeonExit(Position position)
    {
        Position = position;
        ElementDesign = '>';
        Color = ConsoleColor.DarkYellow;
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

internal abstract class LevelElement
{
    public Position Position { get; set; }
    public char ElementDesign { get; set; }
    public ConsoleColor Color { get; set; }
    
    public virtual void Draw(Player player)
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

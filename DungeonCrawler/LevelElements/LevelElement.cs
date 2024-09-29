
internal abstract class LevelElement
{
    public Position Position { get; set; }
    public char ElementDesign { get; set; }
    public ConsoleColor Color { get; set; }
    
    public virtual void Draw(Position playerPosition)
    {
        if (playerPosition.DistanceTo(Position) < 5)
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(ElementDesign);
            Console.ResetColor();
        }
    }
}

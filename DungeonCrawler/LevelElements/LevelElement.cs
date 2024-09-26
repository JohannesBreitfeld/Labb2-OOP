
using System.Drawing;
using System.Xml.Linq;

internal abstract class LevelElement
{
    public Position Position { get; set; }
    public char ElementDesign { get; set; }
    public ConsoleColor Color { get; set; }
    
    public void Draw()
    {
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.Write(ElementDesign);
        Console.ResetColor();
    }
}

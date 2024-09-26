
internal class Wall : LevelElement
{
    public Wall(Position position)
    {
        Position = position;
        ElementDesign = '#';
        Color = ConsoleColor.Gray;
    }
}
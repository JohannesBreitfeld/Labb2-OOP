
internal class Snake : Enemy
{
    public Snake(Position position)
    {
        Position = position;
        ElementDesign = 's';
        Color = ConsoleColor.Green;
        Name = "Snake";
        Health = 25;
    }
    public override void Update()
    {
        throw new NotImplementedException();
    }
}
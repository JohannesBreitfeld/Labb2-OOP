
internal class Rat : Enemy
{
    public Rat(Position position)
    {
        Position = position;
        ElementDesign = 'r';
        Color = ConsoleColor.Red;
        Name = "Rat";
        Health = 10;
    }
    public override void Update()
    {
        throw new NotImplementedException();
    }
}
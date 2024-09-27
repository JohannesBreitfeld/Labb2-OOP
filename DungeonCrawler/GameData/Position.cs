
internal struct Position
{
    public int X { get; set; }
    public int Y { get; set; }

    public Position(int XPosition, int YPosition)
    {
        X = XPosition;
        Y = YPosition;
    }
    public int VerticalDistanceTo(Position position) => Math.Abs(position.X - this.X);
    public int HorisontalDistanceTo(Position position) => Math.Abs(position.Y - this.Y);
    public double DistanceTo(Position position)
    {
        int verticalDistance = VerticalDistanceTo(position);
        int horizontalDistance = HorisontalDistanceTo(position);

        double distance = Math.Sqrt(Math.Pow(verticalDistance, 2) + Math.Pow(horizontalDistance, 2));
        return distance;
    }

}

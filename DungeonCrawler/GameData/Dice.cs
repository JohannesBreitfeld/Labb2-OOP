
internal class Dice
{
    public readonly int NumberOfDice;
    public readonly int SidesPerDice;
    public readonly int Modifier;
    private Random _random;

    public Dice(Random random, int numberOfDice, int sidesPerDice, int modifier)
    {
        _random = random;
        NumberOfDice = numberOfDice;
        SidesPerDice = sidesPerDice;
        Modifier = modifier;
    }
    public int Throw()
    {
        int result = Modifier;
        for (int i = 0; i < NumberOfDice; i++)
        {
            result += _random.Next(1, SidesPerDice + 1);
        }
        return result;
    }
    public override string ToString()
    {
        return $"{NumberOfDice}d{SidesPerDice}+{Modifier}";
    }
}
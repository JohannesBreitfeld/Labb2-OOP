
internal class Dice
{
    public readonly int NumberOfDice;
    public readonly int SidesPerDice;
    public readonly int Modifier;
    public readonly Random Random;

    public Dice(Random random, int numberOfDice, int sidesPerDice, int modifier)
    {
        Random = random;
        NumberOfDice = numberOfDice;
        SidesPerDice = sidesPerDice;
        Modifier = modifier;
    }
    public int Throw()
    {
        int result = Modifier;
        for (int i = 0; i < NumberOfDice; i++)
        {
            result += Random.Next(1, SidesPerDice + 1);
        }
        return result;
    }
    public override string ToString()
    {
        return $"{NumberOfDice}d{SidesPerDice}+{Modifier}";
    }
}
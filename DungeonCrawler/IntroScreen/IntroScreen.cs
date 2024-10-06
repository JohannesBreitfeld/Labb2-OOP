internal static class IntroScreen
{
    public static void DrawIntroScreen()
    {
        string path = Path.Combine("..", "..", "..", "IntroScreen", "DungeonCrawler.txt");

        if (File.Exists(path))
            {
            string[] lines = File.ReadAllLines(path);


            for (int row = 0; row < lines.Length; row++)
            {
                Console.WriteLine(lines[row].PadLeft(85));
            }
        }
        else
        {
            return;
        }
    }

    public static string GetPlayerName()
    {
        Console.Write("Enter your name: ".PadLeft(48));
        string name = Console.ReadLine();
        return name;
    }
}


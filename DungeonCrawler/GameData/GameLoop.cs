internal class GameLoop
{
    public GameLoop(LevelData levelData, string playerName)
    {
        LevelData = levelData;
        PlayerName = playerName;
    }

    public LevelData LevelData { get; }
    public string PlayerName { get; }

    public void Run()
    {
        Console.CursorVisible = false;
        Position playerPosition = LevelData.Load();
        Player player = new(playerPosition, PlayerName);

        LevelData.Draw(player);
        player.Draw();

        int turnCounter = 0;

        while (true)
        {
            turnCounter++;
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"{player.Name}  -  HP: {player.Health}/100  -  Turn: {turnCounter}".PadRight(65, ' '));
            Console.ResetColor();
            Console.Write($"Press ESC to quit" + Environment.NewLine);


            ConsoleKeyInfo cki = Console.ReadKey(true);
            Console.WriteLine("".PadLeft(100, ' '));
            Console.WriteLine("".PadLeft(100, ' '));

            if (cki.Key == ConsoleKey.Escape)
            {
                break;
            }

            player.Update(cki, LevelData);

            Enemy deadEnemy = null;

            foreach (var element in LevelData.Elements)
            {
                element.Draw(player);

                if (element is Enemy enemy)
                {
                    enemy.Update(player, LevelData);

                    if (enemy.Health <= 0)
                    {
                        deadEnemy = enemy;
                    }
                }
            }
            if (deadEnemy != null)
            {
                LevelData.RemoveEnemy(deadEnemy);
            }
            if (player.Health <= 0)
            {
                player.Color = ConsoleColor.DarkGray;
                player.Draw();
                break;
            }
        }
    }
}




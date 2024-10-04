internal class GameLoop
{
    public Position PlayerPosition { get; set; }
    public Player Player { get; set; }
    public GameLoop(LevelData levelData, string playerName)
    {
        LevelData = levelData;
        PlayerName = playerName;
        PlayerPosition = LevelData.Load();
        Player = new(PlayerPosition, PlayerName);
    }

    public LevelData LevelData { get; }
    public string PlayerName { get; }

    public void Run()
    {
        Console.CursorVisible = false;
        Console.Clear();

        LevelData.Draw(Player);
        Player.Draw();

        int turnCounter = 0;
       
        while (Player.Health > 0 && Player.NextDungeon == false)
        {
            turnCounter++;
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"{Player.Name}  -  HP: {Player.Health}/100  -  Turn: {turnCounter}".PadRight(65, ' '));
            Console.ResetColor();
            Console.Write($"Press ESC to quit" + Environment.NewLine);


            ConsoleKeyInfo cki = Console.ReadKey(true);
            Console.WriteLine("".PadLeft(100, ' '));
            Console.WriteLine("".PadLeft(100, ' '));

            if (cki.Key == ConsoleKey.Escape)
            {
                break;
            }

            Player.Update(cki, LevelData);

            Enemy deadEnemy = null;

            foreach (var element in LevelData.Elements)
            {
                element.Draw(Player);

                if (element is Enemy enemy)
                {
                    enemy.Update(Player, LevelData);

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
        }
        if (Player.NextDungeon == false) // if game over
        {
            Player.Color = ConsoleColor.DarkGray;
            Player.Draw();
        }
        else // if player should move to a new dungeon
        {
            ProceduallyGeneratingDungeons pcd = new(20, 60);
            pcd.GenerateNewDungeon();
            Player.Position = LevelData.Load(pcd.Dungeon);
            Player.NextDungeon = false;
            Run();
        }
    }
}




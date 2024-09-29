Console.CursorVisible = false;

string path = Path.Combine("..", "..", "..", "Levels", "Level1.txt");
LevelData levelData = new();
Position playerPosition = levelData.Load(path);
Player player = new(playerPosition);

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

    playerPosition = player.Update(cki, levelData);

    Enemy deadEnemy = null;
    bool isEnemyDead = false;

    foreach (var element in levelData.Elements)
    {
        element.Draw(playerPosition);
        
        if (element is Enemy enemy)
        {
            enemy.Update(playerPosition, levelData);
            
            if (enemy.Health <= 0)
            {
                deadEnemy = enemy;
                isEnemyDead = true;
            }
        } 
    }
    if (isEnemyDead)
    {
        levelData.RemoveEnemy(deadEnemy);
    }
}


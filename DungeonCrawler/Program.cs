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
    Console.WriteLine($"{player.Name} - HP: {player.Health}/100 - Turn: {turnCounter}");
    
    
    
    ConsoleKeyInfo cki = Console.ReadKey(true);
    playerPosition = player.Update(cki, levelData);

    foreach (var element in levelData.Elements)
    {
        if (element is Enemy enemy)
        {
            enemy.Update(playerPosition, levelData);
        }
        element.Draw(playerPosition);
    }

}

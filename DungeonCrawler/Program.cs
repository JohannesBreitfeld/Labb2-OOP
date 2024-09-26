Console.CursorVisible = false;

string path = Path.Combine("..", "..", "..", "Levels", "Level1.txt");
LevelData levelData = new();
Position playerPosition = levelData.Load(path);
Player player = new(playerPosition);
player.Draw();

while (true)
{
    ConsoleKeyInfo cki = Console.ReadKey(true);
    player.Update(cki, levelData);
}

IntroScreen.DrawIntroScreen();
string playerName = IntroScreen.GetPlayerName();

string path = Path.Combine("..", "..", "..", "Levels", "Level1.txt");
LevelData levelData = new LevelData(path);

GameLoop gameLoop = new GameLoop(levelData, playerName);
Console.Clear();
gameLoop.Run();


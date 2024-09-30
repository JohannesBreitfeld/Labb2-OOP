Console.WriteLine("Enter your name:");


string playerName = Console.ReadLine();

string path = Path.Combine("..", "..", "..", "Levels", "Level1.txt");
LevelData levelData = new LevelData(path);

GameLoop gameLoop = new GameLoop(levelData, playerName);
Console.Clear();
gameLoop.Run();



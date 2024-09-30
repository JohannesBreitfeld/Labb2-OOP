
internal class LevelData
{
    private string _path;
    private List<LevelElement> _elements;
    public IReadOnlyList<LevelElement> Elements => _elements.AsReadOnly();

    public LevelData(string path)
    {
        _elements = new List<LevelElement>();
        _path = path;
     }
    public Position Load()
    {
        if (!File.Exists(_path))
        {
            throw new FileNotFoundException("File could not be found.", _path);
        }

        Position playerPosition = new Position(0, 0);

        string[] lines = File.ReadAllLines(_path);

        for (int y = 3; y < lines.Length + 3; y++) //Setting y to 3 to create an overhead
        {
            string line = lines[y - 3];
            for (int x = 0; x < line.Length; x++)
            {
                char c = line[x];
                LevelElement element = null;

                switch (c)
                {
                    case '#':
                        element = new Wall(new Position(x, y));
                        break;
                    case 'r':
                        element = new Rat(new Position(x, y));
                        break;
                    case 's':
                        element = new Snake(new Position(x, y));
                        break;
                    case '@':
                        playerPosition.X = x;
                        playerPosition.Y = y;
                        break;
                }

                if (element != null)
                {
                    _elements.Add(element);
                }
            }
        }
        return playerPosition;
    }

    public void Draw(Player player)
    {
        foreach (var element in Elements)
        {
            element.Draw(player);
        }
    }

    public void RemoveEnemy(Enemy enemy)
    {
        Console.SetCursorPosition(enemy.Position.X, enemy.Position.Y);
        Console.Write(' ');
        _elements.Remove(enemy);
    }
}
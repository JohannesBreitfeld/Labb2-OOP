
internal class LevelData
{
    private List<LevelElement> _elements;
    public IReadOnlyList<LevelElement> Elements => _elements.AsReadOnly();

    public LevelData()
    {
        _elements = new List<LevelElement>();
    }
    public Position Load(string filename)
    {
        if (!File.Exists(filename))
        {
            throw new FileNotFoundException("File could not be found.", filename);
        }
        
        Position playerPosition = new Position(0,0);

        string[] lines = File.ReadAllLines(filename);
        
        for (int y = 3; y < lines.Length + 3; y++) //Setting y to 3 to create an overhead
        {
            string line = lines[y -3];
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
        foreach (var element in Elements)
        {
            //if (element.Position.DistanceTo(playerPosition) < 5)
            element.Draw(playerPosition);
        }
        return playerPosition;
    }
}
public class Maze
{
    private readonly Dictionary<(int, int), bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<(int, int), bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    public void MoveLeft()
    {
        var currentPos = (_currX, _currY);
        if (_mazeMap.ContainsKey(currentPos) && _mazeMap[currentPos][0])
            _currX--;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    public void MoveRight()
    {
        var currentPos = (_currX, _currY);
        if (_mazeMap.ContainsKey(currentPos) && _mazeMap[currentPos][1])
            _currX++;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    public void MoveUp()
    {
        var currentPos = (_currX, _currY);
        if (_mazeMap.ContainsKey(currentPos) && _mazeMap[currentPos][2])
            _currY--;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    public void MoveDown()
    {
        var currentPos = (_currX, _currY);
        if (_mazeMap.ContainsKey(currentPos) && _mazeMap[currentPos][3])
            _currY++;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    public string GetStatus() => $"Current location (x={_currX}, y={_currY})";
}
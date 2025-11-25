// DO NOT MODIFY THIS FILE

public class Maze
{
    public int Width { get; }
    public int Height { get; }

    public readonly int[] Data;

    public Maze(int width, int height, int[] data)
    {
        this.Width = width;
        this.Height = height;
        this.Data = data;
    }

    /// <summary>
    /// I provide this helper function to determine if the (x,y) position is at 
    /// the end of the maze.
    /// </summary>
    public bool IsEnd(int x, int y)
    {
        return Data[y * Height + x] == 2;
    }

    /// <summary>
    /// I provide this helper function to determine if the (x,y) position is a valid
    /// place to move given the size of the maze, the content of the maze,
    /// and the current path already traversed.
    /// </summary>
    public bool IsValidMove(List<ValueTuple<int, int>> currPath, int x, int y)
    {
        // I can't go outside of the maze boundary (i assume maze is a square)
        if (x > Width - 1 || x < 0)
            return false;
        if (y > Height - 1 || y < 0)
            return false;
        // I can't go through a wall
        if (Data[y * Height + x] == 0)
            return false;
        // I can't go if i have already been there (i don't go in circles)
        if (currPath.Contains((x, y)))
            return false;
        // Otherwise, i am good to move
        return true;
    }
}
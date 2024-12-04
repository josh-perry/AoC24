using System.Text.RegularExpressions;

namespace AoC24.Days;

public class Day4 : IDay
{
    public int Day => 4;

    public string Part1(string input)
    {
        var grid = input.Split("\n").Select(row => row.Trim().ToList()).ToList();

        var needleString = "XMAS";
        var xmasCount = 0;

        for (var y = 0; y < grid.Count; y++)
        {
            var row = grid[y];

            for (var x = 0; x < row.Count; x++)
            {
                xmasCount += CountNeedles(needleString, grid, x, y);
            }
        }

        return xmasCount.ToString();
    }

    private int CountNeedles(string needleString, List<List<char>> grid, int x, int y)
    {
        var needles = 0;
        var maxHeight = grid.Count - 1;
        var maxWidth = grid[0].Count - 1;
        
        var directions = new List<(int x, int y)>
        {
            (1, 0),
            (0, 1),
            (-1, 0),
            (0, -1),
            (1, 1),
            (-1, -1),
            (1, -1),
            (-1, 1)
        };
        
        foreach (var direction in directions)
        {
            for (var i = 0; i < needleString.Length; i++)
            {
                var newX = x + direction.x * i;
                var newY = y + direction.y * i;

                if (newX < 0 || newX > maxWidth || newY < 0 || newY > maxHeight)
                {
                    break;
                }

                if (grid[newY][newX] != needleString[i])
                {
                    break;
                }
                
                if (i == needleString.Length - 1)
                {
                    needles++;
                }
            }
        }

        return needles;
    }

    public string Part2(string input)
    {
        return string.Empty;
    }
}
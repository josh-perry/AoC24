using System.Text.RegularExpressions;

namespace AoC24.Days;

public class Day4 : IDay
{
    public int Day => 4;
    
    private List<List<char>> ParseInput(string input)
    {
        return input.Split("\n").Select(row => row.Trim().ToList()).ToList();
    }

    public string Part1(string input)
    {
        var grid = ParseInput(input);

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

    public string Part2(string input)
    {
        var grid = ParseInput(input);
        var diagonalNeighbours = new List<(int x, int y)>
        {
            (1, 1),
            (-1, -1),
            (1, -1),
            (-1, 1)
        };

        var total = 0;
        
        for (var y = 0; y < grid.Count; y++)
        {
            var row = grid[y];

            for (var x = 0; x < row.Count; x++)
            {
                if (grid[y][x] != 'A')
                {
                    continue;
                }

                var neighbours = new List<(char c, int x, int y)>();
                
                foreach (var (dx, dy) in diagonalNeighbours)
                {
                    var newX = x + dx;
                    var newY = y + dy;

                    if (newX < 0 || newX >= grid[0].Count || newY < 0 || newY >= grid.Count)
                    {
                        continue;
                    }

                    neighbours.Add((grid[newY][newX], newX, newY));
                }

                var ems = neighbours.Where(x => x.c == 'M').ToList();
                var esses = neighbours.Where(x => x.c == 'S').ToList();
                
                if (ems.Count != 2 || esses.Count != 2)
                {
                    continue;
                }
                
                if (ems[0].x == ems[1].x || ems[0].y == ems[1].y)
                {
                    total++;
                }
            }
        }

        return total.ToString();
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
        
        foreach (var (dx, dy) in directions)
        {
            for (var i = 0; i < needleString.Length; i++)
            {
                var newX = x + dx * i;
                var newY = y + dy * i;

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
}
namespace AoC24.Days;

public class Day2 : IDay
{
    public int Day => 2;

    private enum Direction
    {
        Decreasing,
        Increasing
    }

    public string Part1(string input)
    {
        var reports = input.Split("\n");
        var safeReports = 0;

        foreach (var report in reports)
        {
            var numbers = report.Split(" ").Select(int.Parse);
            int? lastNumber = null;
            var safe = true;
            Direction? direction = null;

            foreach (var number in numbers)
            {
                if (lastNumber is null)
                {
                    lastNumber = number;
                    continue;
                }
                
                var difference = lastNumber.Value - number;
                lastNumber = number;
                
                var newDirection = difference switch
                {
                    < 0 => Direction.Increasing,
                    > 0 => Direction.Decreasing,
                    _ => direction
                };
                
                direction ??= newDirection;
                
                if (direction != newDirection)
                {
                    safe = false;
                    break;
                }

                if (Math.Abs(difference) is >= 1 and <= 3)
                {
                    continue;
                }
                
                safe = false;
            }
            
            safeReports += safe ? 1 : 0;
        }

        return safeReports.ToString();
    }

    public string Part2(string input)
    {
        return string.Empty;
    }
}
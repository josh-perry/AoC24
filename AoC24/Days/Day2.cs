namespace AoC24.Days;

public class Day2 : IDay
{
    public int Day => 2;

    private enum Direction
    {
        Decreasing,
        Increasing
    }
    
    private List<List<int>> ParseInput(string input)
    {
        var reports = input.Split("\n");
        var parsedReports = new List<List<int>>();

        foreach (var report in reports)
        {
            var numbers = report.Split(" ").Select(int.Parse).ToList();
            parsedReports.Add(numbers);
        }

        return parsedReports;
    }

    private bool IsReportSafe(List<int> report)
    {
        int? lastNumber = null;
        Direction? direction = null;

        for (var index = 0; index < report.Count; index++)
        {
            var number = report[index];
            
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
                return false;
            }

            if (Math.Abs(difference) is >= 1 and <= 3)
            {
                continue;
            }

            return false;
        }

        return true;
    }

    public string Part1(string input)
    {
        var reports = ParseInput(input);
        var safeReports = 0;

        foreach (var report in reports)
        {
            var safe = IsReportSafe(report);
            safeReports += safe ? 1 : 0;
        }

        return safeReports.ToString();
    }

    public string Part2(string input)
    {
        var reports = ParseInput(input);
        var safeReports = 0;

        foreach (var report in reports)
        {
            for (var retry = -1; retry < report.Count; retry++)
            {
                var adjustedReport = report;
                
                if (retry != -1)
                {
                    adjustedReport = new List<int>(report);
                    adjustedReport.RemoveAt(retry);
                }

                if (!IsReportSafe(adjustedReport))
                {
                    continue;
                }
                
                safeReports += 1;
                break;
            }
        }

        return safeReports.ToString();
    }
}
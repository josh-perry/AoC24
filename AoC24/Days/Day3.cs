using System.Text.RegularExpressions;

namespace AoC24.Days;

public class Day3 : IDay
{
    public int Day => 3;

    private int CalculateTotal(string input, bool togglesEnabled)
    {
        var regex = new Regex(@"mul\((?<first>\d+),(?<second>\d+)\)|(?<do>do\(\))|(?<dont>don't\(\))");
        
        var matches = regex.Matches(input);
        var total = 0;
        var enabled = true;
        
        foreach (Match match in matches)
        {
            if (togglesEnabled)
            {
                if (match.Groups["do"].Success)
                {
                    enabled = true;
                    continue;
                }

                if (match.Groups["dont"].Success)
                {
                    enabled = false;
                    continue;
                }

                if (!enabled)
                {
                    continue;
                }
            }
            
            if (!int.TryParse(match.Groups["first"].Value, out var first) ||
                !int.TryParse(match.Groups["second"].Value, out var second))
            {
                continue;
            }

            total += first * second;
        }

        return total;
    }

    public string Part1(string input)
    {
        return CalculateTotal(input, false).ToString();
    }

    public string Part2(string input)
    {
        return CalculateTotal(input, true).ToString();
    }
}
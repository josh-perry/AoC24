using System.Text.RegularExpressions;

namespace AoC24.Days;

public class Day3 : IDay
{
    public int Day => 3;

    public string Part1(string input)
    {
        var regex = new Regex(@"mul\((\d+),(\d+)\)");
        
        var matches = regex.Matches(input);
        var total = 0;
        
        foreach (Match match in matches)
        {
            var firstNumber = int.Parse(match.Groups[1].Value);
            var secondNumber = int.Parse(match.Groups[2].Value);

            total += firstNumber * secondNumber;
        }

        return total.ToString();
    }

    public string Part2(string input)
    {
        return string.Empty;
    }
}
namespace AoC24.Days;

public class Day1 : IDay
{
    public int Day => 1;

    private (List<int>, List<int>) ParseInput(string input)
    {
        var leftSideNumbers = new List<int>();
        var rightSideNumbers = new List<int>();
        
        foreach(var line in input.Split("\n"))
        {
            var numbers = line.Split("   ");
            var left = int.Parse(numbers[0]);
            var right = int.Parse(numbers[1]);
            
            leftSideNumbers.Add(left);
            rightSideNumbers.Add(right);
        }
        
        return (leftSideNumbers, rightSideNumbers);
    }

    public string Part1(string input)
    {
        var (leftSideNumbers, rightSideNumbers) = ParseInput(input);
        
        var orderedLeftSideNumbers = leftSideNumbers.OrderBy(x => x).ToList();
        var orderedRightSideNumbers = rightSideNumbers.OrderBy(x => x).ToList();
        
        var totalDifference = 0;

        for (var index = 0; index < orderedLeftSideNumbers.Count; index++)
        {
            var leftSide = orderedLeftSideNumbers[index];
            var rightSide = orderedRightSideNumbers[index];

            var difference = Math.Abs(leftSide - rightSide);
            totalDifference += difference;
        }

        return totalDifference.ToString();
    }

    public string Part2(string input)
    {
        var (leftSideNumbers, rightSideNumbers) = ParseInput(input);
        var totalValue = 0;

        foreach (var leftSideNumber in leftSideNumbers)
        {
            totalValue += leftSideNumber * rightSideNumbers.Count(x => x == leftSideNumber);
        }
        
        return totalValue.ToString();
    }
}
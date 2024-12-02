namespace AoC24.Test;

public class Day2
{
    [Fact]
    public void should_give_expected_result_for_mini_input_part1()
    {
        // Arrange
        var input = """
                    7 6 4 2 1
                    1 2 7 8 9
                    9 7 6 2 1
                    1 3 2 4 5
                    8 6 4 4 1
                    1 3 6 7 9
                    """;
        
        var day = new Days.Day2();

        // Act
        var result = day.Part1(input);

        // Assert
        Assert.Equal("2", result);
    }
    
    [Fact]
    public void should_give_expected_result_for_mini_input_part2()
    {
        // Arrange
        var input = """
                    7 6 4 2 1
                    1 2 7 8 9
                    9 7 6 2 1
                    1 3 2 4 5
                    8 6 4 4 1
                    1 3 6 7 9
                    """;

        
        var day = new Days.Day2();

        // Act
        var result = day.Part2(input);

        // Assert
        Assert.Equal("4", result);
    }
}
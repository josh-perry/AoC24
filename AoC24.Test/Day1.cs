namespace AoC24.Test;

public class Day1
{
    [Fact]
    public void should_give_expected_result_for_mini_input_part1()
    {
        // Arrange
        var input = """
                    3   4
                    4   3
                    2   5
                    1   3
                    3   9
                    3   3
                    """;
        
        var day = new Days.Day1();

        // Act
        var result = day.Part1(input);

        // Assert
        Assert.Equal("11", result);
    }
}
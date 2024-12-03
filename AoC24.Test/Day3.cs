namespace AoC24.Test;

public class Day3
{
    [Fact]
    public void should_give_expected_result_for_mini_input_part1()
    {
        // Arrange
        var input = """
                    xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))
                    """;
        
        var day = new Days.Day3();

        // Act
        var result = day.Part1(input);

        // Assert
        Assert.Equal("161", result);
    }
    
    [Fact]
    public void should_give_expected_result_for_mini_input_part2()
    {
        // Arrange
        var input = """
                    xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))
                    """;
        
        var day = new Days.Day3();

        // Act
        var result = day.Part2(input);

        // Assert
        Assert.Equal("48", result);
    }
}
namespace AoC24.Test;

public class Day4
{
    [Fact]
    public void should_give_expected_result_for_mini_input_part1()
    {
        // Arrange
        var input = """
                    MMMSXXMASM
                    MSAMXMSMSA
                    AMXSXMAAMM
                    MSAMASMSMX
                    XMASAMXAMM
                    XXAMMXXAMA
                    SMSMSASXSS
                    SAXAMASAAA
                    MAMMMXMMMM
                    MXMXAXMASX
                    """;
        
        var day = new Days.Day4();

        // Act
        var result = day.Part1(input);

        // Assert
        Assert.Equal("18", result);
    }
    
    [Fact]
    public void should_give_expected_result_for_mini_input_part2()
    {
        // Arrange
        var input = """
                    
                    """;
        
        var day = new Days.Day4();

        // Act
        var result = day.Part2(input);

        // Assert
    }
}
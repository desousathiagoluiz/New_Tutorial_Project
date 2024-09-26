using MyLibrary;

namespace MyTests;

public class WeatherCalculatorTests
{
    [Theory]
    [InlineData(3, "Spring")]
    [InlineData(4, "Spring")]
    [InlineData(5, "Spring")]
    [InlineData(6, "Summer")]
    [InlineData(7, "Summer")]
    [InlineData(8, "Summer")]
    [InlineData(9, "Autumn")]
    [InlineData(10, "Autumn")]
    [InlineData(11, "Autumn")]
    [InlineData(12, "Winter")]
    [InlineData(1, "Winter")]
    [InlineData(2, "Winter")]
    public void DetermineSeason_ShouldReturnCorrectSeason(int month, string expectedSeason)
    {
        // Arrange
        var date = new DateOnly(2023, month, 1);

        // Act
        var season = WeatherCalculator.DetermineSeason(date);

        // Assert
        Assert.Equal(expectedSeason, season);
    }
}
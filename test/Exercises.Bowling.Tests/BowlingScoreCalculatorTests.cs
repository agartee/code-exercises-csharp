using FluentAssertions;

namespace Exercises.Bowling.Tests
{
    public class BowlingScoreCalculatorTests
    {
        [Fact]
        public void Score_WithOpenFrame_ReturnsSumOfRolls()
        {
            // arrange
            var bowlingScoreCalculator = new BowlingScoreCalculator();
            var rolls = new[] { 1, 2 };

            // act
            var result = bowlingScoreCalculator.Score(rolls);

            // assert
            result.Should().Be(3);
        }

        [Fact]
        public void Score_WithSingleFrameSpare_ReturnsNull()
        {
            // arrange
            var bowlingScoreCalculator = new BowlingScoreCalculator();
            var rolls = new[] { 1, 9 };

            // act
            var result = bowlingScoreCalculator.Score(rolls);

            // assert
            result.Should().BeNull();
        }

        [Fact]
        public void Score_WithSpareAndSubsequentRoll_ReturnsExpectedScoreWithBonus()
        {
            // arrange
            var bowlingScoreCalculator = new BowlingScoreCalculator();
            var rolls = new[] { 1, 9, 2 };

            // act
            var result = bowlingScoreCalculator.Score(rolls);

            // assert
            result.Should().Be(14);
        }
    }
}

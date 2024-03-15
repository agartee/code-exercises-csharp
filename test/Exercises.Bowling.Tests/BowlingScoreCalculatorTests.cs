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

        [Fact]
        public void Score_WithSingleFrameStrike_ReturnsNull()
        {
            // arrange
            var bowlingScoreCalculator = new BowlingScoreCalculator();
            var rolls = new[] { 10 };

            // act
            var result = bowlingScoreCalculator.Score(rolls);

            // assert
            result.Should().BeNull();
        }

        [Fact]
        public void Score_WithStrikeAndTwoSubsequentRolls_ReturnsExpectedScoreWithBonus()
        {
            // arrange
            var bowlingScoreCalculator = new BowlingScoreCalculator();
            var rolls = new[] { 10, 1, 1 };

            // act
            var result = bowlingScoreCalculator.Score(rolls);

            // assert
            result.Should().Be(14);
        }

        [Fact]
        public void Score_WithStrikeAndFollowingStrike_ReturnsExpectedScoreWithBonus()
        {
            // arrange
            var bowlingScoreCalculator = new BowlingScoreCalculator();
            var rolls = new[] { 10, 10, 1, 1 };

            // act
            var result = bowlingScoreCalculator.Score(rolls);

            // assert
            result.Should().Be(
                21 // first frame 
                + 12 // second frame 
                + 2); // third frame
        }
        
        [Fact]
        public void Score_WithStrikeAndFollowingStrikeAndFollowingSpare_ReturnsExpectedScoreWithBonus()
        {
            // arrange
            var bowlingScoreCalculator = new BowlingScoreCalculator();
            var rolls = new[] { 10, 10, 10, 9, 1, 1 };

            // act
            var result = bowlingScoreCalculator.Score(rolls);

            // assert
            result.Should().Be(
                30 // first frame 
                + 29 // second frame 
                + 20 // third frame 
                + 11 // forth frame
                + 1); // fifth frame
        }

        // todo: 10 frame game (last frame has special rules)

        // todo: perfect game
    }
}

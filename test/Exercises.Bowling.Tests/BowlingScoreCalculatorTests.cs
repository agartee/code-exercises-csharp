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

        [Fact]
        public void Score_WithFullGameAndNoBonuses_ReturnsExpectedScore()
        {
            // arrange
            var bowlingScoreCalculator = new BowlingScoreCalculator();
            var rolls = new[] { 
                9,0, // first frame
                9,0, // second frame
                9,0, // third frame
                9,0, // forth frame
                9,0, // fifth frame
                9,0, // sixth frame
                9,0, // seventh frame
                9,0, // eighth frame
                9,0, // ninth frame
                9,0 // tenth frame
            };

            // act
            var result = bowlingScoreCalculator.Score(rolls);

            // assert
            result.Should().Be(90);
        }

        [Fact]
        public void Score_WithFullGameOfSpares_ReturnsExpectedScoreWithOneExtraRollInLastFrame()
        {
            // arrange
            var bowlingScoreCalculator = new BowlingScoreCalculator();
            var rolls = new[] {
                5,5, // first frame
                5,5, // second frame
                5,5, // third frame
                5,5, // forth frame
                5,5, // fifth frame
                5,5, // sixth frame
                5,5, // seventh frame
                5,5, // eighth frame
                5,5, // ninth frame
                5,5, 5 // tenth frame
            };

            // act
            var result = bowlingScoreCalculator.Score(rolls);

            // assert
            result.Should().Be(
                15 + // first frame
                15 + // second frame
                15 + // third frame
                15 + // forth frame
                15 + // fifth frame
                15 + // sixth frame
                15 + // seventh frame
                15 + // eighth frame
                15 + // ninth frame
                15); // tenth frame;
        }

        [Fact]
        public void Score_WithPerfectGame_ReturnsExpectedScoreWithTwoExtraRollsInLastFrame()
        {
            // arrange
            var bowlingScoreCalculator = new BowlingScoreCalculator();
            var rolls = new[] {
                10, // first frame
                10, // second frame
                10, // third frame
                10, // forth frame
                10, // fifth frame
                10, // sixth frame
                10, // seventh frame
                10, // eighth frame
                10, // ninth frame
                10, 10, 10 // tenth frame
            };

            // act
            var result = bowlingScoreCalculator.Score(rolls);

            // assert
            result.Should().Be(300);
        }

        // todo: perfect game
    }
}

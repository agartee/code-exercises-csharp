using FluentAssertions;

namespace Exercises.Bowling.Tests
{
    public class FrameTests
    {
        [Fact]
        public void IsComplete_WithFirstRollOnly_ReturnsFalse()
        {
            // arrange
            var frame = new Frame {  FirstRoll = 1 };

            // act
            var result = frame.IsComplete();

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsComplete_WithFirstAndSecondRoll_ReturnsTrue()
        {
            // arrange
            var frame = new Frame { FirstRoll = 1, SecondRoll = 1 };

            // act
            var result = frame.IsComplete();

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsSpare_WithFirstRollOnly_ReturnsFalse()
        {
            // arrange
            var frame = new Frame { FirstRoll = 1 };

            // act
            var result = frame.IsSpare();

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsSpare_WithFirstAndSecondRollNotTotalling10_ReturnsFalse()
        {
            // arrange
            var frame = new Frame { FirstRoll = 1, SecondRoll = 2 };

            // act
            var result = frame.IsSpare();

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsSpare_WithFirstAndSecondRollTotalling10_ReturnsTrue()
        {
            // arrange
            var frame = new Frame { FirstRoll = 1, SecondRoll = 9 };

            // act
            var result = frame.IsSpare();

            // assert
            result.Should().BeTrue();
        }
    }
}

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
        public void IsComplete_WithStrike_ReturnsTrue()
        {
            // arrange
            var frame = new Frame { FirstRoll = 10 };

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

        [Fact]
        public void AddRoll_WhenEmpty_SetsFirstRoll()
        {
            var frame = new Frame();

            frame.AddRoll(1);

            frame.FirstRoll.Should().Be(1);
            frame.SecondRoll.Should().BeNull();
        }

        [Fact]
        public void AddRoll_WhenHasFirstRoll_SetsSecondRoll()
        {
            var frame = new Frame {  FirstRoll = 1 };

            frame.AddRoll(2);

            frame.FirstRoll.Should().Be(1);
            frame.SecondRoll.Should().Be(2);
        }

        [Fact]
        public void AddRoll_WhenIsComplete_Throws()
        {
            var frame = new Frame { FirstRoll = 10 };

            var roll = 2;
            var action = () => frame.AddRoll(roll);

            action.Should().Throw<InvalidOperationException>()
                .WithMessage($"*{roll}*")
                .WithMessage("*Frame is already complete*");
        }
    }
}

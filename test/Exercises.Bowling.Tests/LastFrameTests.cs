using FluentAssertions;

namespace Exercises.Bowling.Tests
{
    public class LastFrameTests
    {
        [Fact]
        public void IsComplete_WithFirstRollOnlyAndIsOpenFrame_ReturnsFalse()
        {
            // arrange
            var frame = new LastFrame { FirstRoll = 1 };

            // act
            var result = frame.IsComplete();

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsComplete_WithFirstAndSecondRollAndIsOpenFrame_ReturnsTrue()
        {
            // arrange
            var frame = new LastFrame { FirstRoll = 1, SecondRoll = 1 };

            // act
            var result = frame.IsComplete();

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsComplete_WithFirstAndSecondRollAndIsSpare_ReturnsFalse()
        {
            // arrange
            var frame = new LastFrame { FirstRoll = 9, SecondRoll = 1 };

            // act
            var result = frame.IsComplete();

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsComplete_WithFirstSecondAndThirdRollAndIsSpare_ReturnsTrue()
        {
            // arrange
            var frame = new LastFrame { FirstRoll = 9, SecondRoll = 1 , ThirdRoll = 1 };

            // act
            var result = frame.IsComplete();

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsComplete_WithFirstRollOnlyAndIsStrike_ReturnsFalse()
        {
            // arrange
            var frame = new LastFrame { FirstRoll = 10 };

            // act
            var result = frame.IsComplete();

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsComplete_WithFirstAndSecondRollAndIsStrike_ReturnsFalse()
        {
            // arrange
            var frame = new LastFrame { FirstRoll = 10, SecondRoll = 1 };

            // act
            var result = frame.IsComplete();

            // assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsComplete_WithFirstSecondAndThirdRollAndIsStrike_ReturnsTrue()
        {
            // arrange
            var frame = new LastFrame { FirstRoll = 10, SecondRoll = 1, ThirdRoll = 1 };

            // act
            var result = frame.IsComplete();

            // assert
            result.Should().BeTrue();
        }

        [Fact]
        public void AddRoll_WhenEmpty_SetsFirstRoll()
        {
            var frame = new LastFrame();

            frame.AddRoll(1);

            frame.FirstRoll.Should().Be(1);
            frame.SecondRoll.Should().BeNull();
        }

        [Fact]
        public void AddRoll_WhenHasFirstRoll_SetsSecondRoll()
        {
            var frame = new LastFrame { FirstRoll = 1 };

            frame.AddRoll(2);

            frame.FirstRoll.Should().Be(1);
            frame.SecondRoll.Should().Be(2);
        }

        [Fact]
        public void AddRoll_WhenHasSecondRoll_SetsThirdRoll()
        {
            var frame = new LastFrame { FirstRoll = 10, SecondRoll = 2 };

            frame.AddRoll(3);

            frame.FirstRoll.Should().Be(10);
            frame.SecondRoll.Should().Be(2);
            frame.ThirdRoll.Should().Be(3);
        }

        [Fact]
        public void AddRoll_WhenIsComplete_Throws()
        {
            var frame = new LastFrame { FirstRoll = 1, SecondRoll = 2 };

            var roll = 3;
            var action = () => frame.AddRoll(roll);

            action.Should().Throw<InvalidOperationException>()
                .WithMessage($"*{roll}*")
                .WithMessage("*Frame is already complete*");
        }
    }
}

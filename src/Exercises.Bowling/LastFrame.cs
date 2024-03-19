
namespace Exercises.Bowling
{
    public class LastFrame : Frame
    {
        public int? ThirdRoll { get; set; }

        public override void AddRoll(int roll)
        {
            if (IsComplete())
                throw new InvalidOperationException($"Unable to add roll if {roll} to frame. Frame is already complete.");

            if (FirstRoll == null)
                FirstRoll = roll;
            else if (SecondRoll == null)
                SecondRoll = roll;
            else
                ThirdRoll = roll;
        }

        public override bool IsComplete()
        {
            return (IsStrike() && SecondRoll != null && ThirdRoll != null)
                || (IsSpare() && ThirdRoll != null)
                || (!IsStrike() && !IsSpare() && FirstRoll != null && SecondRoll != null);
        }
    }
}

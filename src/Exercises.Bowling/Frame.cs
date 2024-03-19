
namespace Exercises.Bowling
{
    public class Frame
    {
        public int Index { get; set; }
        public int? FirstRoll { get; set; }
        public int? SecondRoll { get; set; }

        public virtual void AddRoll(int roll)
        {
            if (IsComplete())
                throw new InvalidOperationException($"Unable to add roll if { roll } to frame. Frame is already complete.");

            if (FirstRoll == null)
                FirstRoll = roll;
            else
                SecondRoll = roll;
        }

        public virtual bool IsComplete()
        {
            return FirstRoll == 10 || SecondRoll != null;
        }

        public bool IsSpare()
        {
            return SecondRoll != null && FirstRoll + SecondRoll == 10;
        }

        public bool IsStrike()
        {
            return FirstRoll == 10;
        }
    }
}

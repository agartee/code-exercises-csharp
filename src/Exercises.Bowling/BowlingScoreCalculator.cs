
namespace Exercises.Bowling
{
    public class BowlingScoreCalculator
    {
        public int? Score(int[] rolls)
        {
            var frames = CreateFrames(rolls);

            var score = 0;
            foreach (var frame in frames)
            {
                if (frame.IsSpare())
                {
                    // add score with bonus
                    var nextFrame = frames
                        .FirstOrDefault(f => f.Index == frame.Index + 1);

                    if (nextFrame == null)
                        return null;

                    score += frame.FirstRoll + frame.SecondRoll!.Value + nextFrame.FirstRoll;
                }
                else
                {
                    score += frame.FirstRoll + (frame.SecondRoll ?? 0);
                }
            }

            return score;
        }

        private static List<Frame> CreateFrames(int[] rolls)
        {
            var frames = new List<Frame>();

            var frameIdx = 0;
            Frame? currentFrame = null;
            foreach (var roll in rolls)
            {
                if (currentFrame == null || currentFrame.IsComplete())
                {
                    currentFrame = new Frame { Index = frameIdx, FirstRoll = roll };
                    frames.Add(currentFrame);
                    frameIdx++;
                }
                else
                {
                    currentFrame.SecondRoll = roll;
                }
            }

            return frames;
        }
    }

    public class Frame
    {
        public int Index { get; set; }
        public int FirstRoll { get; set; }
        public int? SecondRoll { get; set; }

        public bool IsComplete()
        {
            return SecondRoll != null;
        }

        public bool IsSpare()
        {
            return SecondRoll != null && FirstRoll + SecondRoll == 10;
        }
    }
}

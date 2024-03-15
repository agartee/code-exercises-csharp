
namespace Exercises.Bowling
{
    public class BowlingScoreCalculator
    {
        public int? Score(int[] rolls)
        {
            var frames = CreateFrames();
            PopulateFrames(frames, rolls);

            var score = 0;
            foreach (var frame in frames)
            {
                var nextFrame = frames
                    .FirstOrDefault(f => f.Index == frame.Index + 1);

                var nextNextFrame = frames
                    .FirstOrDefault(f => f.Index == frame.Index + 2);

                if (frame.IsSpare())
                {
                    var bonus = nextFrame?.FirstRoll;

                    if (bonus == null)
                        return null;
                    
                    score += frame.FirstRoll!.Value + frame.SecondRoll!.Value + bonus!.Value;
                }
                else if(frame.IsStrike())
                {
                    if (nextFrame == null)
                        return null;

                    var bonus = nextFrame.IsStrike()
                        ? nextFrame.FirstRoll + nextNextFrame?.FirstRoll
                        : nextFrame.FirstRoll + nextFrame.SecondRoll;

                    if (bonus == null)
                        return null;

                    score += frame.FirstRoll!.Value + bonus!.Value;
                }
                else // Open Frame
                {
                    score += (frame.FirstRoll ?? 0) + (frame.SecondRoll ?? 0);
                }
            }
            
            return score;
        }

        private static Frame[] CreateFrames()
        {
            return Enumerable.Range(1, 10).Select(i => new Frame {  Index = i }).ToArray();
        }

        private static Frame[] PopulateFrames(Frame[] frames, int[] rolls)
        {
            var currentFrame = frames.First();
            foreach (var roll in rolls)
            {
                if (currentFrame.IsComplete())
                    currentFrame = frames.First(f => f.Index == currentFrame.Index + 1);

                currentFrame.AddRoll(roll);
            }

            return frames;
        }
    }
}

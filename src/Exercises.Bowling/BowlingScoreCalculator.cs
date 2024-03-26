
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
                if (frame.IsSpare())
                {
                    var bonus = frame is LastFrame 
                        ? GetSpareBonusFromLastFrame(frames)
                        : GetSpareBonusFromNextFrame(frames, frame.Index);

                    if (bonus == null)
                        return null;

                    score += frame.FirstRoll!.Value + frame.SecondRoll!.Value + bonus!.Value;
                }
                else if(frame.IsStrike())
                {
                    var bonus = frame is LastFrame
                        ? GetStrikeBonusFromLastFrame(frames)
                        : GetStrikeBonusFromNextFrames(frames, frame.Index);

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

        private int? GetSpareBonusFromNextFrame(IEnumerable<Frame> frames, int currentFrameIdx)
        {
            var nextFrame = frames
                .FirstOrDefault(f => f.Index == currentFrameIdx + 1);

            return nextFrame?.FirstRoll;
        }

        private int? GetSpareBonusFromLastFrame(IEnumerable<Frame> frames)
        {
            var lastFrame = frames
                .OfType<LastFrame>()
                .Single();

            return lastFrame.ThirdRoll;
        }

        private int? GetStrikeBonusFromNextFrames(IEnumerable<Frame> frames, int currentFrameIdx)
        {
            var nextFrame = frames
                .First(f => f.Index == currentFrameIdx + 1);

            if(nextFrame is LastFrame)
                return nextFrame.FirstRoll + nextFrame?.SecondRoll;

            var nextNextFrame = frames
                .FirstOrDefault(f => f.Index == currentFrameIdx + 2);

            return nextFrame!.IsStrike()
                ? nextFrame.FirstRoll + nextNextFrame?.FirstRoll
                : nextFrame.FirstRoll + nextFrame.SecondRoll;
        }

        private int? GetStrikeBonusFromLastFrame(IEnumerable<Frame> frames)
        {
            var lastFrame = frames
                .OfType<LastFrame>()
                .Single();

            return lastFrame.SecondRoll + lastFrame.ThirdRoll;
        }


        private static Frame[] CreateFrames()
        {
            var frames = Enumerable.Range(1, 9)
                .Select(i => new Frame {  Index = i })
                .ToList();

            frames.Add(new LastFrame { Index = 10 });

            return frames.ToArray();
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

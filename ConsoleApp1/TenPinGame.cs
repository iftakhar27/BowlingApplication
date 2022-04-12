using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class TenPinGame : IGame
    {
        public const int MaxFrameNumber = 10;
        public const int StartingPinsNumber = 10;
        public List<Frame> Frames { get; } = new List<Frame>();

        private string[] framesStringArray;
        public static string bonusSubsctring;


        public TenPinGame(string gameInput)
        {
            string framesSubstring = ParseGame(gameInput);
            framesStringArray = Utilities.SplitFramesString(framesSubstring, MaxFrameNumber);
            FrameRepository.ProcessFrameString(framesStringArray, Frames, MaxFrameNumber, StartingPinsNumber);
        }

        /// <summary>
        /// Splitting input string into 2 parts: Frames and Bonus throws
        /// </summary>
        /// <param name="gameInput"></param>
        internal string ParseGame(string gameInput)
        {
            string framesSubstring = "";

            if (gameInput.Contains("||"))
            {
                int index = gameInput.IndexOf("||");
                framesSubstring = gameInput.Substring(0, index);
                bonusSubsctring = gameInput.Substring(index + 2);
            }
            return framesSubstring;
        }


        /// <summary>
        /// Calculate the Total score for the whole game/line.
        /// </summary>
        /// <returns></returns>
        public int Score()
        {
            int score = 0;
            foreach (var frame in Frames)
            {
                int frameIndex = Frames.IndexOf(frame);
                if (!frame.IsLastFrame && frame.IsStrike)
                {
                    if (Frames[frameIndex + 1].Throws.Count == 1)
                        score += 10 + Frames[frameIndex + 1].Throws[0] + Frames[frameIndex + 2].Throws[0];
                    else if (Frames[frameIndex + 1].Throws.Count == 2 || Frames[frameIndex + 1].Throws.Count == 3)
                        score += 10 + Frames[frameIndex + 1].Throws[0] + Frames[frameIndex + 1].Throws[1];
                    //else
                    //    throw new ArgumentException($"The next frame has invalid throws count {Frames[frameIndex + 1].Throws.Count}.");
                }
                else if (!frame.IsLastFrame && frame.IsSpare)
                {
                    score += 10 + Frames[frameIndex + 1].Throws[0];
                }
                else if (frame.IsLastFrame && frame.IsStrike)
                {
                    score += 10 + Frames[frameIndex].Throws[1] + Frames[frameIndex].Throws[2];
                }
                else if (frame.IsLastFrame && frame.IsSpare)
                {
                    score += 10 + Frames[frameIndex].Throws[1];
                }
                else
                {
                    score += frame.Throws[0] + frame.Throws[1];
                }
            }

            return score;
        }

    }
}

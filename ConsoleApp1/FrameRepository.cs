using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class FrameRepository
    {
        /// <summary>
        /// Process each frame-string in the frames string array, to determine the pins count for each frame
        /// </summary>
        /// <param name="framesList"></param>
        public static void ProcessFrameString(string[] framesList, List<Frame> Frames, int MaxFrameNumber, int StartingPinsNumber)
        {
            foreach (var frame in framesList)
            {
                if (!Frames.Any() || Frames.Last().IsFrameOver)
                {
                    var isLastFrame = Frames.Count == MaxFrameNumber - 1;
                    Frames.Add(new Frame(isLastFrame));
                }

                char[] frameCharArr = frame.ToCharArray();
                foreach (char c in frameCharArr)
                {
                    Frames.Last().KnokcedDownPinsCount = Utilities.ProcessCharArray(c, Frames.Last(), StartingPinsNumber);

                    if (!Frames.Last().IsLastFrame && Frames.Last().Throws.Count == 2)
                    {
                        Frames.Last().IsFrameOver = true;
                    }
                }

                if (Frames.Count == MaxFrameNumber)
                {
                    Frames.Last().IsLastFrame = true;
                    char[] bonusCharArr = TenPinGame.bonusSubsctring.ToCharArray();
                    if (Frames.Last().IsStrike)
                    {
                        if (bonusCharArr.Length > 2)
                        {
                            throw new ArgumentException($"The number of bonus throws {bonusCharArr.Length}, is over allowed for the Last Strike. Please check.");
                        }
                        Frames.Last().IsBonusAllowed = true;
                        foreach (char c in bonusCharArr)
                        {
                            Frames.Last().KnokcedDownPinsCount = Utilities.ProcessCharArray(c, Frames.Last(), StartingPinsNumber);
                        }
                    }
                    else if (Frames.Last().IsSpare)
                    {
                        if (bonusCharArr.Length != 1)
                        {
                            throw new ArgumentException($"The number of bonus throws {bonusCharArr.Length}, is over allowed for the Last Spare. Please check.");
                        }
                        Frames.Last().IsBonusAllowed = true;
                        Frames.Last().KnokcedDownPinsCount = Utilities.ProcessCharArray(bonusCharArr[0], Frames.Last(), StartingPinsNumber);
                    }
                }
            }
        }
    }
}

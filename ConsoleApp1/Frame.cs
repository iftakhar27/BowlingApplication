using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Frame
    {
        public List<int> Throws = new List<int>();
        public int KnokcedDownPinsCount { get; set; }
        public bool IsStrike { get; set; }
        public bool IsSpare { get; set; }
        public bool IsLastFrame { get; set; }
        public bool IsBonusAllowed { get; set; }
        public bool IsFrameOver { get; set; }



        public Frame(bool isLastFrame = false)
        {
            this.IsLastFrame = isLastFrame;
        }


        public void ValidateEachThrow()
        {
            if (TenPinGame.StartingPinsNumber == 0)
            {
                throw new InvalidOperationException("Sorry, no pins are left standing.");
            }
            if (KnokcedDownPinsCount < 0)
            {
                throw new InvalidOperationException($"Sorry, the # of knocked down pins {KnokcedDownPinsCount} is out of range.");
            }
            else if (KnokcedDownPinsCount > TenPinGame.StartingPinsNumber)
            {
                throw new InvalidOperationException($"Sorry, the # of knocked down pins {KnokcedDownPinsCount} is is more than {TenPinGame.StartingPinsNumber} still standing pins.");
            }
        }

    }
}

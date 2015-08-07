using System;

namespace OOCamp
{
    public class Length
    {
        public Unit Unit { get; private set; }
        public int Value { get; private set; }

        public Length(Unit unit, int value)
        {
            Unit = unit;
            Value = value;
        }

        public Length GetLongerCompareWith(Length compareLength)
        {
            return Value * (int)Unit >= compareLength.Value * (int)compareLength.Unit ? this : compareLength;
        }

    }

    public enum Unit
    {
        M = 100,
        DM = 10,
        CM = 1,
    }

}

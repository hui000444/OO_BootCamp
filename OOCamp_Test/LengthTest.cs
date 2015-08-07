using System;
using OOCamp;
using Xunit;

namespace OOCamp_Test
{
    public class LengthTest
    {
        [Fact]
        public void when_give_length_value_3_and_2_with_unit_m()
        {
            var shortGold = new Length(Unit.M, 2);
            var longerGold = new Length(Unit.M, 3);

            var longerLength = shortGold.GetLongerCompareWith(longerGold);
            Assert.Equal(longerLength.Value, 3);
            Assert.Equal(longerLength.Unit, Unit.M);
        }

        [Fact]
        public void when_give_length_value_2_and_3_with_unit_m()
        {
            var shortGold = new Length(Unit.M, 2) ;
            var longerGold = new Length(Unit.M, 3) ;

            var longerLength = shortGold.GetLongerCompareWith(longerGold);
            Assert.Equal(longerLength.Value, 3);
            Assert.Equal(longerLength.Unit, Unit.M);
        }

        [Fact]
        public void when_give_length_value_3_and_3_with_unit_m()
        {
            var gold = new Length(Unit.M, 3) ;
            var sameLengthGold = new Length(Unit.M, 3) ;

            var longerLength = gold.GetLongerCompareWith(sameLengthGold);
            Assert.Equal(longerLength.Value, 3);
            Assert.Equal(longerLength.Unit, Unit.M);
        }

        [Fact]
        public void when_give_length_value_1_with_unit_m_and_length_value_1_with_unit_cm()
        {
            var shortGold = new Length(Unit.CM, 1) ;
            var longerGold = new Length(Unit.M, 1);

            var longerLength = shortGold.GetLongerCompareWith(longerGold);
            Assert.Equal(1, longerLength.Value);
            Assert.Equal(Unit.M, longerLength.Unit);
        }

        [Fact]
        public void when_give_length_value_1_with_unit_m_and_length_value_1_with_unit_dm()
        {
            var shortGold = new Length(Unit.DM, 1) ;
            var longerGold = new Length(Unit.M, 1);

            var longerLength = shortGold.GetLongerCompareWith(longerGold);
            Assert.Equal(1, longerLength.Value);
            Assert.Equal(Unit.M, longerLength.Unit);
        }

        [Fact]
        public void when_give_length_value_1_with_unit_cm_and_length_value_1_with_unit_dm()
        {
            var shortGold = new Length(Unit.CM, 1) ;
            var longerGold = new Length(Unit.DM, 1) ;

            var longerLength = shortGold.GetLongerCompareWith(longerGold);
            Assert.Equal(1, longerLength.Value);
            Assert.Equal(Unit.DM, longerLength.Unit);
        }

    }
}

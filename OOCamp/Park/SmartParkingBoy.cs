using System;
using System.Linq;

namespace OOCamp.Park
{
    public class SmartParkingBoy : ParkingBoyBase
    {

        public SmartParkingBoy(params Park[] parks)
            : base(parks)
        {
        }

        public override bool StopCar(Car car)
        {
            return ChooseParkBy(car, r => r.GetEmptyPositionCount());
        }
    }
}
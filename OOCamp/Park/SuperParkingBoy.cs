using System.Linq;

namespace OOCamp.Park
{
    public class SuperParkingBoy : ParkingBoyBase
    {
        public SuperParkingBoy(params Park[] parks)
            : base(parks)
        {
        }

        public override bool StopCar(Car car)
        {
            return ChooseParkBy(car, r => r.GetEmptyRate());
        }
    }

    
}
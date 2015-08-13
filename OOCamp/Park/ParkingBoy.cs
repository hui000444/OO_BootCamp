using System.Linq;

namespace OOCamp.Park
{
    public class ParkingBoy : ParkingBoyBase
    {
        public ParkingBoy(params Park[] parks)
            : base(parks)
        {
        }

        public override bool StopCar(Car car)
        {
            var park = ParkList.FirstOrDefault(p => p.StopCar(car));
            return park != null;
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace OOCamp.Park
{
    public class ParkingManager : ParkingBoyBase
    {
        private readonly List<ParkingBoyBase> boys;

        public ParkingManager(params Park[] park)
            : base(park)
        {

        }

        public ParkingManager(params ParkingBoyBase[] boys)
        {
            this.boys = new List<ParkingBoyBase>();
            this.boys.AddRange(boys);
        }

        public override bool StopCar(Car car)
        {
            var park = ParkList.FirstOrDefault(p => p.StopCar(car));
            return park != null;
        }

        public void AskBoyStopCar(Car car)
        {
            foreach (var boy in boys)
            {
                if (boy.StopCar(car)) return;
            }
        }

        public Car AskBoyPickCar(string carNumber)
        {
            foreach (var boy in boys)
            {
                var car = boy.PickUpCar(carNumber);
                if (car != null) return car;
            }
            return null;
        }
    }
}
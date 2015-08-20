using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOCamp.Park
{
    public class ParkingManager : ParkingBoyBase
    {
        public readonly List<ParkingBoyBase> Boys;

        public ParkingManager(List<Park> parks, List<ParkingBoyBase> boys)
        {
            ParkList = new List<Park>();
            if (parks != null)
                ParkList.AddRange(parks);

            this.Boys = new List<ParkingBoyBase>();
            if (boys != null)
                this.Boys.AddRange(boys);
        }


        public override bool StopCar(Car car)
        {
            if (ParkList != null && ParkList.Any(p => p.StopCar(car))) return true;

            return Boys.Any(b => b.StopCar(car));
        }

        public override Car PickUpCar(string carNumber)
        {
            var car = base.PickUpCar(carNumber);
            if (car != null) return car;

            foreach (var boy in Boys)
            {
                car = boy.PickUpCar(carNumber);
                if (car != null) return car;
            }
            return null;
        }

        public override string CalculateParkingReport()
        {
            StringBuilder builder = new StringBuilder();
            ParkList.ForEach(
               p =>
               {
                   builder.AppendLine(
                       string.Format(
                           "{0}P {1} {2}",
                           Utils.SpaceTwo,
                           p.GetEmptyPositionCount(),
                           p.ParkPositionTotalNumber));
               }
               );
            return builder.ToString();
        }
    }
}
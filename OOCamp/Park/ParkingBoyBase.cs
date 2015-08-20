using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOCamp.Park
{
    public abstract class ParkingBoyBase
    {
        protected List<Park> ParkList { get; set; }

        protected ParkingBoyBase(params Park[] parks)
        {
            ParkList = parks.ToList();
        }

        public abstract bool StopCar(Car car);

        public virtual Car PickUpCar(string carNumber)
        {
            foreach (var park in ParkList)
            {
                var carResult = park.PickUpCar(carNumber);
                if (carResult != null)
                {
                    return carResult;
                }
            }
            return null;
        }

        public int GetEmptyPosition()
        {
            return ParkList.Sum(p => p.GetEmptyPositionCount());
        }

        public int GetParkPositionTotalNumber()
        {
            return ParkList.Sum(p => p.ParkPositionTotalNumber);
        }

        public virtual string CalculateParkingReport()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Format("{0}B {1} {2}", Utils.SpaceTwo, GetEmptyPosition(), GetParkPositionTotalNumber()));
            ParkList.ForEach(
               p =>
               {
                   builder.AppendLine(
                       string.Format(
                           "{0}P {1} {2}",
                           Utils.SpaceFour,
                           p.GetEmptyPositionCount(),
                           p.ParkPositionTotalNumber));
               }
               );
            return builder.ToString();
        }

        protected bool ChooseParkBy<T>(Car car, Func<Park, T> selector)
        {
            var park = ParkList
                .OrderByDescending(selector)
                .FirstOrDefault();
            if (park == null) return false;
            return park.StopCar(car);
        }
    }
}